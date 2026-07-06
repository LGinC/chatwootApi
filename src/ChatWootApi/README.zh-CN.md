# ChatWootApi

Chatwoot API 的强类型 .NET 客户端接口与数据模型，基于 [Refit](https://github.com/reactiveui/refit) 构建，覆盖 Application、Client 和 Platform API。

## 安装

仅安装 API 接口与模型：

```bash
dotnet add package ChatWootApi
```

推荐同时安装依赖注入扩展：

```bash
dotnet add package ChatWootApi.Extensions
```

## 使用依赖注入

`ChatWootApi.Extensions` 会配置 Refit、`HttpClient`、JSON 序列化以及 `api_access_token` 请求头。

在 `appsettings.json` 中配置 Chatwoot 地址和令牌：

```json
{
  "ChatWootApi": {
    "BaseAddress": "https://app.chatwoot.com/",
    "AccountAccessToken": "your-account-access-token",
    "PlatformAccessToken": "your-platform-access-token"
  }
}
```

按需注册 API：

```csharp
using ChatWootApi.Extensions;

builder.Services.AddChatWootApplicationApi(builder.Configuration);
builder.Services.AddChatWootClientApi(builder.Configuration);
builder.Services.AddChatWootPlatformApi(builder.Configuration);
```

注入对应接口后即可调用：

```csharp
using ChatWootApi.Application;

public sealed class ContactService(IApplicationContactsApi contactsApi)
{
    public Task<ContactsListResponse> GetContactsAsync(
        long accountId,
        CancellationToken cancellationToken = default)
    {
        return contactsApi.ContactListAsync(accountId, cancellationToken);
    }
}
```

Application API 还提供聚合接口 `IChatWootApplicationApi`，可以通过单个服务访问所有已实现的 Application API。

## 处理 Chatwoot Webhook

Chatwoot Webhook 是账号级 HTTP 回调。你可以在 Chatwoot 控制台进入 **Settings → Integrations → Webhooks**，添加一个接收 `POST` 请求的 URL，并选择需要订阅的事件。Chatwoot 会把事件名称放在 JSON 的 `event` 字段中，例如 `message_created`、`conversation_updated`、`conversation_status_changed`、`message_updated`、`webwidget_triggered`、`conversation_typing_on` 和 `conversation_typing_off`。

`ChatWootApi.Application.WebhookRequest` 用于接收这些 webhook payload。模型覆盖 Chatwoot 文档中的 Account、Inbox、Contact/User、Conversation、Message、`changed_attributes` 和 `event_info`，并通过 `ExtensionData` 保留未来新增或未显式建模的字段。Chatwoot 文档里部分数字字段可能以字符串或数字返回，`WebhookRequest` 已兼容这两种格式。

### Controller 示例

下面示例使用 ASP.NET Core Controller：先用原始请求体校验 Chatwoot 签名，再反序列化为 `WebhookRequest` 并按事件分发。

```csharp
using System.Text.Json;
using ChatWootApi.Application;
using ChatWootApi.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

public sealed class ChatwootWebhookOptions
{
    public required string Secret { get; init; }
}

[ApiController]
[Route("api/chatwoot/webhooks")]
public sealed class ChatwootWebhookController(
    IOptions<ChatwootWebhookOptions> options,
    ILogger<ChatwootWebhookController> logger) : ControllerBase
{
    private static readonly TimeSpan SignatureTolerance = TimeSpan.FromMinutes(5);

    [HttpPost]
    public async Task<IActionResult> PostAsync(CancellationToken cancellationToken)
    {
        Request.EnableBuffering();

        byte[] rawBody;
        using (var buffer = new MemoryStream())
        {
            await Request.Body.CopyToAsync(buffer, cancellationToken);
            rawBody = buffer.ToArray();
        }

        Request.Body.Position = 0;

        if (!ChatwootWebhookSignatureHelper.VerifySignature(
            Request.Headers["X-Chatwoot-Signature"].ToString(),
            Request.Headers["X-Chatwoot-Timestamp"].ToString(),
            rawBody,
            options.Value.Secret,
            DateTimeOffset.UtcNow,
            SignatureTolerance))
        {
            return Unauthorized();
        }

        var webhook = JsonSerializer.Deserialize(
            rawBody,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationWebhookRequest);

        if (webhook is null || string.IsNullOrWhiteSpace(webhook.Event))
        {
            return BadRequest();
        }

        switch (webhook.Event)
        {
            case "message_created":
            case "message_updated":
                await HandleMessageAsync(webhook, cancellationToken);
                break;

            case "conversation_created":
            case "conversation_updated":
            case "conversation_status_changed":
                await HandleConversationAsync(webhook, cancellationToken);
                break;

            case "webwidget_triggered":
                await HandleWebWidgetTriggeredAsync(webhook, cancellationToken);
                break;

            case "conversation_typing_on":
            case "conversation_typing_off":
                await HandleTypingAsync(webhook, cancellationToken);
                break;

            default:
                logger.LogInformation("Ignored Chatwoot webhook event {Event}", webhook.Event);
                break;
        }

        return Ok();
    }


    private Task HandleMessageAsync(WebhookRequest webhook, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Chatwoot message {MessageId} in conversation {ConversationDisplayId}: {Content}",
            webhook.Id,
            webhook.Conversation?.DisplayId ?? webhook.DisplayId,
            webhook.Content);

        return Task.CompletedTask;
    }

    private Task HandleConversationAsync(WebhookRequest webhook, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Chatwoot conversation {ConversationId} status changed to {Status}",
            webhook.Id,
            webhook.Status);

        if (webhook.ChangedAttributes is not null)
        {
            foreach (var changedAttribute in webhook.ChangedAttributes)
            {
                if (changedAttribute is null)
                {
                    continue;
                }

                foreach (var (name, value) in changedAttribute)
                {
                    logger.LogInformation(
                        "Changed {Name}: {PreviousValue} -> {CurrentValue}",
                        name,
                        value.PreviousValue,
                        value.CurrentValue);
                }
            }
        }

        return Task.CompletedTask;
    }

    private Task HandleWebWidgetTriggeredAsync(WebhookRequest webhook, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Chatwoot widget opened by contact {ContactId} from {Referer}",
            webhook.Contact?.Id,
            webhook.EventInfo?.Referer);

        return Task.CompletedTask;
    }

    private Task HandleTypingAsync(WebhookRequest webhook, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Chatwoot typing event {Event} by {UserName}; private note: {IsPrivate}",
            webhook.Event,
            webhook.User?.Name,
            webhook.IsPrivate);

        return Task.CompletedTask;
    }
}
```

### 签名校验要点

- 必须使用原始请求体参与签名计算，不能先反序列化再序列化。JSON 字段顺序、空白和 Unicode 转义改变都会导致签名不同。
- Chatwoot 签名格式为 `sha256=HMAC-SHA256(secret, "{timestamp}.{raw_body}")`。
- 请求头：`X-Chatwoot-Signature`、`X-Chatwoot-Timestamp`，以及可用于幂等处理的 `X-Chatwoot-Delivery`。
- 使用 `CryptographicOperations.FixedTimeEquals` 做常量时间比较，避免计时攻击。
- 建议拒绝超过 5 分钟的 timestamp，降低重放攻击风险。

### 事件与模型字段对应

| Chatwoot 事件 | 主要读取字段 |
| --- | --- |
| `message_created` / `message_updated` | `Id`、`Content`、`MessageType`、`ContentType`、`ContentAttributes`、`Sender`、`Contact`、`Conversation`、`Account`、`Inbox` |
| `conversation_created` / `conversation_status_changed` | `Id`、`DisplayId`、`Status`、`Channel`、`CanReply`、`UnreadCount`、`AccountId`、`InboxId`、`AdditionalAttributes` |
| `conversation_updated` | 上述会话字段，加上 `ChangedAttributes` 获取变更前后的值 |
| `webwidget_triggered` | `Contact`、`Inbox`、`Account`、`CurrentConversation`、`SourceId`、`EventInfo` |
| `conversation_typing_on` / `conversation_typing_off` | `Conversation`、`User`、`IsPrivate` |

未识别字段会进入对应对象的 `ExtensionData`，因此 Chatwoot 增加字段时不会导致反序列化失败。

## Application API 临时切换 Access Token

Application API 的 `api_access_token` 是用户级令牌，常见场景是每次请求根据当前用户切换。安装 `ChatWootApi.Extensions` 后，可以注入默认的 `AccessTokenProvider`，用 `using` 将 Application access token 限定在当前异步调用范围内：

```csharp
using ChatWootApi.Application;
using ChatWootApi.Extensions;

app.MapGet("/contacts", async (
    long accountId,
    string userAccessToken,
    AccessTokenProvider accessTokenProvider,
    IApplicationContactsApi contactsApi,
    CancellationToken cancellationToken) =>
{
    using var applicationAccessToken = accessTokenProvider.UseApplicationAccessToken(userAccessToken);

    return await contactsApi.ContactListAsync(accountId, cancellationToken);
});
```

该 scope 使用 `AsyncLocal` 保存当前 Application token：内层 scope 会临时覆盖外层 token，释放后恢复外层 token；Platform API 仍然使用配置中的 `PlatformAccessToken`。若没有 scope 且未配置 `AccountAccessToken`，Application API 调用会抛出配置缺失异常。

若令牌需要完全由租户上下文或请求上下文动态获取，也可以自行实现 `IAccessTokenProvider`，并在调用 ChatWoot 注册扩展前注册。扩展使用 `TryAddSingleton`，因此不会覆盖已有实现：

```csharp
builder.Services.AddSingleton<IAccessTokenProvider, TenantAccessTokenProvider>();
builder.Services.AddChatWootApplicationApi(builder.Configuration);
builder.Services.AddChatWootPlatformApi(builder.Configuration);
```

Client API 使用公开 inbox 标识，不需要 Account 或 Platform access token。

## 已实现的 API

以下列表按 Chatwoot API Tag 分类

<details>
<summary><strong>Application API</strong></summary>

- `IChatWootApplicationApi`：所有 Application API 的聚合接口
- `IApplicationAccountApi`：Account
- `IApplicationAccountAgentBotsApi`：Account Agent Bots
- `IApplicationAgentsApi`：Agents
- `IApplicationAuditLogsApi`：Audit Logs
- `IApplicationAutomationRuleApi`：Automation Rules
- `IApplicationCannedResponsesApi`：Canned Responses
- `IApplicationContactLabelsApi`：Contact Labels
- `IApplicationContactsApi`：Contacts
- `IApplicationConversationAssignmentsApi`：Conversation Assignments
- `IApplicationConversationsApi`：Conversations
- `IApplicationCustomAttributesApi`：Custom Attributes
- `IApplicationCustomFiltersApi`：Custom Filters
- `IApplicationHelpCenterApi`：Help Center
- `IApplicationInboxesApi`：Inboxes
- `IApplicationIntegrationsApi`：Integrations
- `IApplicationLabelsApi`：Labels
- `IApplicationMessagesApi`：Messages
- `IApplicationProfileApi`：Profile
- `IApplicationReportsApi`：Reports
- `IApplicationTeamsApi`：Teams
- `IApplicationWebhooksApi`：Webhooks

</details>

<details>
<summary><strong>Client API</strong></summary>

- `IClientInboxApi`：Inbox
- `IClientContactApi`：Contacts
- `IClientConversationApi`：Conversations
- `IClientMessageApi`：Messages

</details>

<details>
<summary><strong>Platform API</strong></summary>

- `IPlatformAccountApi`：Accounts
- `IPlatformAccountUserApi`：Account Users
- `IPlatformAgentBotApi`：Agent Bots
- `IPlatformUserApi`：Users 与用户登录链接

</details>

