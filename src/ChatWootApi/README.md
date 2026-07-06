# ChatWootApi

English | [简体中文](https://github.com/LGinC/chatwootApi/blob/main/src/ChatWootApi/README.zh-CN.md)

Strongly typed .NET interfaces and models for the Chatwoot REST APIs, built on [Refit](https://github.com/reactiveui/refit). The package covers Application, Client, and Platform API surfaces.

## Installation

Install the API interfaces and models:

```bash
dotnet add package ChatWootApi
```

Most applications should also install the dependency-injection extensions:

```bash
dotnet add package ChatWootApi.Extensions
```

## Dependency injection

`ChatWootApi.Extensions` configures Refit, `HttpClient`, JSON serialization, and the `api_access_token` request header.

Configure the Chatwoot base URL and tokens in `appsettings.json`:

```json
{
  "ChatWootApi": {
    "BaseAddress": "https://app.chatwoot.com/",
    "AccountAccessToken": "your-account-access-token",
    "PlatformAccessToken": "your-platform-access-token"
  }
}
```

Register the API groups you need:

```csharp
using ChatWootApi.Extensions;

builder.Services.AddChatWootApplicationApi(builder.Configuration);
builder.Services.AddChatWootClientApi(builder.Configuration);
builder.Services.AddChatWootPlatformApi(builder.Configuration);
```

Inject a specific API interface and call it directly:

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

Application API also provides the aggregate `IChatWootApplicationApi` interface for accessing all implemented Application API methods through one service.

## Handling Chatwoot webhooks

Chatwoot webhooks are account-level HTTP callbacks. In Chatwoot, go to **Settings → Integrations → Webhooks**, add a URL that accepts `POST` requests, and subscribe to the events you need. Chatwoot sends the event name in the JSON `event` field, such as `message_created`, `conversation_updated`, `conversation_status_changed`, `message_updated`, `webwidget_triggered`, `conversation_typing_on`, and `conversation_typing_off`.

`ChatWootApi.Application.WebhookRequest` receives those webhook payloads. It models the Account, Inbox, Contact/User, Conversation, Message, `changed_attributes`, and `event_info` structures documented by Chatwoot. Unknown or future fields are preserved through `ExtensionData`. Numeric fields that Chatwoot may send either as JSON strings or numbers are supported.

### Controller example

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

### Signature verification notes

- Always verify with the raw request body. Parsing and re-serializing JSON can change property order, whitespace, or Unicode escaping and break the signature.
- Chatwoot computes signatures as `sha256=HMAC-SHA256(secret, "{timestamp}.{raw_body}")`.
- Headers: `X-Chatwoot-Signature`, `X-Chatwoot-Timestamp`, and `X-Chatwoot-Delivery` for idempotency when available.
- `ChatwootWebhookSignatureHelper` uses constant-time comparison internally.
- Rejecting timestamps older than five minutes is recommended to reduce replay risk.

### Event-to-model field map

| Chatwoot event | Main fields |
| --- | --- |
| `message_created` / `message_updated` | `Id`, `Content`, `MessageType`, `ContentType`, `ContentAttributes`, `Sender`, `Contact`, `Conversation`, `Account`, `Inbox` |
| `conversation_created` / `conversation_status_changed` | `Id`, `DisplayId`, `Status`, `Channel`, `CanReply`, `UnreadCount`, `AccountId`, `InboxId`, `AdditionalAttributes` |
| `conversation_updated` | Conversation fields above plus `ChangedAttributes` for previous/current values |
| `webwidget_triggered` | `Contact`, `Inbox`, `Account`, `CurrentConversation`, `SourceId`, `EventInfo` |
| `conversation_typing_on` / `conversation_typing_off` | `Conversation`, `User`, `IsPrivate` |

Unknown fields are captured in the corresponding `ExtensionData` dictionary, so new Chatwoot fields do not break deserialization.

## Temporarily switching Application API access tokens

Application API `api_access_token` values are user-level tokens and often need to switch per request. With `ChatWootApi.Extensions`, inject the default `AccessTokenProvider` and scope the Application access token to the current async flow with `using`:

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

The scope uses `AsyncLocal`: an inner scope temporarily overrides the outer token and restores it when disposed. Platform API calls continue to use the configured `PlatformAccessToken`. If no scope exists and no `AccountAccessToken` is configured, Application API calls throw the same missing-configuration exception.

You can also replace the token source entirely by registering your own `IAccessTokenProvider` before calling the Chatwoot registration extensions. The extensions use `TryAddSingleton`, so they do not override an existing implementation:

```csharp
builder.Services.AddSingleton<IAccessTokenProvider, TenantAccessTokenProvider>();
builder.Services.AddChatWootApplicationApi(builder.Configuration);
builder.Services.AddChatWootPlatformApi(builder.Configuration);
```

Client API uses public inbox identifiers and does not require Account or Platform access tokens.

## Implemented APIs

The following list is grouped by Chatwoot API tag.

<details>
<summary><strong>Application API</strong></summary>

- `IChatWootApplicationApi`: aggregate interface for all Application APIs
- `IApplicationAccountApi`: Account
- `IApplicationAccountAgentBotsApi`: Account Agent Bots
- `IApplicationAgentsApi`: Agents
- `IApplicationAuditLogsApi`: Audit Logs
- `IApplicationAutomationRuleApi`: Automation Rules
- `IApplicationCannedResponsesApi`: Canned Responses
- `IApplicationContactLabelsApi`: Contact Labels
- `IApplicationContactsApi`: Contacts
- `IApplicationConversationAssignmentsApi`: Conversation Assignments
- `IApplicationConversationsApi`: Conversations
- `IApplicationCustomAttributesApi`: Custom Attributes
- `IApplicationCustomFiltersApi`: Custom Filters
- `IApplicationHelpCenterApi`: Help Center
- `IApplicationInboxesApi`: Inboxes
- `IApplicationIntegrationsApi`: Integrations
- `IApplicationLabelsApi`: Labels
- `IApplicationMessagesApi`: Messages
- `IApplicationProfileApi`: Profile
- `IApplicationReportsApi`: Reports
- `IApplicationTeamsApi`: Teams
- `IApplicationWebhooksApi`: Webhooks

</details>

<details>
<summary><strong>Client API</strong></summary>

- `IClientInboxApi`: Inbox
- `IClientContactApi`: Contacts
- `IClientConversationApi`: Conversations
- `IClientMessageApi`: Messages

</details>

<details>
<summary><strong>Platform API</strong></summary>

- `IPlatformAccountApi`: Accounts
- `IPlatformAccountUserApi`: Account Users
- `IPlatformAgentBotApi`: Agent Bots
- `IPlatformUserApi`: Users and user login links

</details>
