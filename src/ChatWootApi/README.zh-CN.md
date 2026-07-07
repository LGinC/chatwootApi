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

Webhook payload 处理、签名校验要点、事件字段映射，以及 ASP.NET Core 示例已移到 [WEBHOOKS.zh-CN.md](WEBHOOKS.zh-CN.md)。

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

