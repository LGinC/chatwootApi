# 处理 Chatwoot Webhook

Chatwoot Webhook 是账号级 HTTP 回调。你可以在 Chatwoot 控制台进入 **Settings → Integrations → Webhooks**，添加一个接收 `POST` 请求的 URL，并选择需要订阅的事件。Chatwoot 会把事件名称放在 JSON 的 `event` 字段中，例如 `message_created`、`conversation_updated`、`conversation_status_changed`、`message_updated`、`webwidget_triggered`、`conversation_typing_on` 和 `conversation_typing_off`。

`ChatWootApi.Application.WebhookRequest` 用于接收这些 webhook payload。模型覆盖 Chatwoot 文档中的 Account、Inbox、Contact/User、Conversation、Message、`changed_attributes` 和 `event_info`，并通过 `ExtensionData` 保留未来新增或未显式建模的字段。Chatwoot 文档里部分数字字段可能以字符串或数字返回，`WebhookRequest` 已兼容这两种格式。

## Minimal API 示例

下面示例使用 ASP.NET Core Minimal API：先用原始请求体校验 Chatwoot 签名，再反序列化为 `WebhookRequest` 并按事件分发。

```csharp
using System.Text.Json;
using ChatWootApi.Application;
using ChatWootApi.Serialization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ChatwootWebhookOptions>(
    builder.Configuration.GetSection("ChatwootWebhook"));

var app = builder.Build();

app.MapPost("/api/chatwoot/webhooks", async Task<Results<Ok, UnauthorizedHttpResult, BadRequest>> (
    HttpRequest request,
    IOptions<ChatwootWebhookOptions> options,
    ILoggerFactory loggerFactory,
    CancellationToken cancellationToken) =>
{
    var logger = loggerFactory.CreateLogger("ChatwootWebhook");
    var signatureTolerance = TimeSpan.FromMinutes(5);

    request.EnableBuffering();

    byte[] rawBody;
    using (var buffer = new MemoryStream())
    {
        await request.Body.CopyToAsync(buffer, cancellationToken);
        rawBody = buffer.ToArray();
    }

    request.Body.Position = 0;

    if (!ChatwootWebhookSignatureHelper.VerifySignature(
        request.Headers["X-Chatwoot-Signature"].ToString(),
        request.Headers["X-Chatwoot-Timestamp"].ToString(),
        rawBody,
        options.Value.Secret,
        DateTimeOffset.UtcNow,
        signatureTolerance))
    {
        return TypedResults.Unauthorized();
    }

    var webhook = JsonSerializer.Deserialize(
        rawBody,
        ChatWootJsonSerializerContext.Default.ChatWootApiApplicationWebhookRequest);

    if (webhook is null || string.IsNullOrWhiteSpace(webhook.Event))
    {
        return TypedResults.BadRequest();
    }

    switch (webhook.Event)
    {
        case "message_created":
        case "message_updated":
            await HandleMessageAsync(webhook, logger, cancellationToken);
            break;

        case "conversation_created":
        case "conversation_updated":
        case "conversation_status_changed":
            await HandleConversationAsync(webhook, logger, cancellationToken);
            break;

        case "webwidget_triggered":
            await HandleWebWidgetTriggeredAsync(webhook, logger, cancellationToken);
            break;

        case "conversation_typing_on":
        case "conversation_typing_off":
            await HandleTypingAsync(webhook, logger, cancellationToken);
            break;

        default:
            logger.LogInformation("Ignored Chatwoot webhook event {Event}", webhook.Event);
            break;
    }

    return TypedResults.Ok();
});

app.Run();

static Task HandleMessageAsync(
    WebhookRequest webhook,
    ILogger logger,
    CancellationToken cancellationToken)
{
    logger.LogInformation(
        "Chatwoot message {MessageId} in conversation {ConversationDisplayId}: {Content}",
        webhook.Id,
        webhook.Conversation?.DisplayId ?? webhook.DisplayId,
        webhook.Content);

    return Task.CompletedTask;
}

static Task HandleConversationAsync(
    WebhookRequest webhook,
    ILogger logger,
    CancellationToken cancellationToken)
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

static Task HandleWebWidgetTriggeredAsync(
    WebhookRequest webhook,
    ILogger logger,
    CancellationToken cancellationToken)
{
    logger.LogInformation(
        "Chatwoot widget opened by contact {ContactId} from {Referer}",
        webhook.Contact?.Id,
        webhook.EventInfo?.Referer);

    return Task.CompletedTask;
}

static Task HandleTypingAsync(
    WebhookRequest webhook,
    ILogger logger,
    CancellationToken cancellationToken)
{
    logger.LogInformation(
        "Chatwoot typing event {Event} by {UserName}; private note: {IsPrivate}",
        webhook.Event,
        webhook.User?.Name,
        webhook.IsPrivate);

    return Task.CompletedTask;
}

public sealed class ChatwootWebhookOptions
{
    public required string Secret { get; init; }
}
```

## Controller 示例

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

## 签名校验要点

- 必须使用原始请求体参与签名计算，不能先反序列化再序列化。JSON 字段顺序、空白和 Unicode 转义改变都会导致签名不同。
- Chatwoot 签名格式为 `sha256=HMAC-SHA256(secret, "{timestamp}.{raw_body}")`。
- 请求头：`X-Chatwoot-Signature`、`X-Chatwoot-Timestamp`，以及可用于幂等处理的 `X-Chatwoot-Delivery`。
- `ChatwootWebhookSignatureHelper` 内部使用常量时间比较。
- 建议拒绝超过 5 分钟的 timestamp，降低重放攻击风险。

## 事件与模型字段对应

| Chatwoot 事件 | 主要读取字段 |
| --- | --- |
| `message_created` / `message_updated` | `Id`、`Content`、`MessageType`、`ContentType`、`ContentAttributes`、`Sender`、`Contact`、`Conversation`、`Account`、`Inbox` |
| `conversation_created` / `conversation_status_changed` | `Id`、`DisplayId`、`Status`、`Channel`、`CanReply`、`UnreadCount`、`AccountId`、`InboxId`、`AdditionalAttributes` |
| `conversation_updated` | 上述会话字段，加上 `ChangedAttributes` 获取变更前后的值 |
| `webwidget_triggered` | `Contact`、`Inbox`、`Account`、`CurrentConversation`、`SourceId`、`EventInfo` |
| `conversation_typing_on` / `conversation_typing_off` | `Conversation`、`User`、`IsPrivate` |

未识别字段会进入对应对象的 `ExtensionData`，因此 Chatwoot 增加字段时不会导致反序列化失败。
