# Handling Chatwoot webhooks

Chatwoot webhooks are account-level HTTP callbacks. In Chatwoot, go to **Settings → Integrations → Webhooks**, add a URL that accepts `POST` requests, and subscribe to the events you need. Chatwoot sends the event name in the JSON `event` field, such as `message_created`, `conversation_updated`, `conversation_status_changed`, `message_updated`, `webwidget_triggered`, `conversation_typing_on`, and `conversation_typing_off`.

`ChatWootApi.Application.WebhookRequest` receives those webhook payloads. It models the Account, Inbox, Contact/User, Conversation, Message, `changed_attributes`, and `event_info` structures documented by Chatwoot. Unknown or future fields are preserved through `ExtensionData`. Numeric fields that Chatwoot may send either as JSON strings or numbers are supported.

## Minimal API example

The following ASP.NET Core Minimal API reads the raw request body, verifies the Chatwoot signature, deserializes `WebhookRequest`, and dispatches by event name.

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

## Controller example

The following ASP.NET Core Controller reads the raw request body, verifies the Chatwoot signature, deserializes `WebhookRequest`, and dispatches by event name.

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

## Signature verification notes

- Always verify with the raw request body. Parsing and re-serializing JSON can change property order, whitespace, or Unicode escaping and break the signature.
- Chatwoot computes signatures as `sha256=HMAC-SHA256(secret, "{timestamp}.{raw_body}")`.
- Headers: `X-Chatwoot-Signature`, `X-Chatwoot-Timestamp`, and `X-Chatwoot-Delivery` for idempotency when available.
- `ChatwootWebhookSignatureHelper` uses constant-time comparison internally.
- Rejecting timestamps older than five minutes is recommended to reduce replay risk.

## Event-to-model field map

| Chatwoot event | Main fields |
| --- | --- |
| `message_created` / `message_updated` | `Id`, `Content`, `MessageType`, `ContentType`, `ContentAttributes`, `Sender`, `Contact`, `Conversation`, `Account`, `Inbox` |
| `conversation_created` / `conversation_status_changed` | `Id`, `DisplayId`, `Status`, `Channel`, `CanReply`, `UnreadCount`, `AccountId`, `InboxId`, `AdditionalAttributes` |
| `conversation_updated` | Conversation fields above plus `ChangedAttributes` for previous/current values |
| `webwidget_triggered` | `Contact`, `Inbox`, `Account`, `CurrentConversation`, `SourceId`, `EventInfo` |
| `conversation_typing_on` / `conversation_typing_off` | `Conversation`, `User`, `IsPrivate` |

Unknown fields are captured in the corresponding `ExtensionData` dictionary, so new Chatwoot fields do not break deserialization.
