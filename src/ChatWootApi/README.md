# ChatWootApi

English | [简体中文](README.zh-CN.md)

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

Webhook payload handling, signature verification notes, event field mapping, and ASP.NET Core examples now live in [WEBHOOKS.md](WEBHOOKS.md).

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
