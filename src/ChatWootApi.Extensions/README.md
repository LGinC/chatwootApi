# ChatWootApi.Extensions

English | [简体中文](https://github.com/LGinC/chatwootApi/blob/main/src/ChatWootApi.Extensions/README.zh-CN.md)

Dependency-injection extensions for `ChatWootApi`. This package registers Refit clients, configures the Chatwoot base address, and automatically adds the `api_access_token` request header for Application and Platform APIs.

## Installation

```bash
dotnet add package ChatWootApi.Extensions
```

This package transitively references the core `ChatWootApi` package, so most applications do not need to install the core package separately.

## Configuration option 1: IConfiguration

`appsettings.json`:

```json
{
  "ChatWootApi": {
    "BaseAddress": "https://app.chatwoot.com/",
    "AccountAccessToken": "your-account-access-token",
    "PlatformAccessToken": "your-platform-access-token"
  }
}
```

Register the API groups you need during application startup:

```csharp
using ChatWootApi.Extensions;

builder.Services.AddChatWootApplicationApi(builder.Configuration);
builder.Services.AddChatWootClientApi(builder.Configuration);
builder.Services.AddChatWootPlatformApi(builder.Configuration);
```

The default configuration section name is `ChatWootApi`. You can use another section name when needed:

```csharp
builder.Services.AddChatWootApplicationApi(
    builder.Configuration,
    sectionName: "Services:Chatwoot");
```

## Configuration option 2: delegate

```csharp
builder.Services.AddChatWootApplicationApi(options =>
{
    options.BaseAddress = "https://chatwoot.example.com/";
    options.AccountAccessToken = "your-account-access-token";
});

builder.Services.AddChatWootPlatformApi(options =>
{
    options.BaseAddress = "https://chatwoot.example.com/";
    options.PlatformAccessToken = "your-platform-access-token";
});
```

## HTTP request and response logging

Logging is disabled by default. Set `EnableLogging` to enable logging for every registered Chatwoot API client:

```json
{
  "ChatWootApi": {
    "BaseAddress": "https://app.chatwoot.com/",
    "EnableLogging": true,
    "IncludeBodyInLogs": false
  }
}
```

To log only selected API interfaces, leave `EnableLogging` false and configure `LoggingApiNames`:

```json
{
  "ChatWootApi": {
    "LoggingApiNames": [
      "IApplicationContactsApi",
      "ChatWootApi.Platform.IPlatformAccountApi"
    ]
  }
}
```

`LoggingApiNames` accepts either an API interface short name or its full type name. The handler logs the HTTP method, redacted URI, headers, status code, and duration. Request and response bodies are omitted unless `IncludeBodyInLogs` is enabled. Access tokens, authorization/cookie headers, sensitive query parameters, and common sensitive JSON/form fields are masked before logging; unsupported or oversized bodies are omitted.

The package uses `Microsoft.Extensions.Logging`; configure the logging provider and level in the host application as usual.

## Calling APIs

After registration, inject a specific API interface:

```csharp
using ChatWootApi.Application;

app.MapGet("/contacts", async (
    long accountId,
    IApplicationContactsApi contactsApi,
    CancellationToken cancellationToken) =>
{
    return await contactsApi.ContactListAsync(accountId, cancellationToken);
});
```

Application API also provides an aggregate interface:

```csharp
app.MapGet("/account", async (
    long accountId,
    IChatWootApplicationApi chatwoot,
    CancellationToken cancellationToken) =>
{
    return await chatwoot.GetAccountDetailsAsync(accountId, cancellationToken);
});
```

Available registration methods:

- `AddChatWootApplicationApi`: registers Application API and uses Account access tokens.
- `AddChatWootClientApi`: registers public Client API and does not add an access token.
- `AddChatWootPlatformApi`: registers Platform API and uses Platform access tokens.

## Temporarily switching Application API access tokens

Application API `api_access_token` values are usually user-level tokens. The default `AccessTokenProvider` supports a temporary Application access token scoped to the current async flow. When the scope is disposed, the previous outer token or configured `AccountAccessToken` is restored.

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

Nested calls restore the outer token after the inner `using` is disposed. Platform API always uses `PlatformAccessToken` and is not affected by Application token scopes. If `AccountAccessToken` is not configured and there is no active Application token scope, Application API calls throw `InvalidOperationException`.

## Custom IAccessTokenProvider

If tokens must come entirely from tenant or request context, implement `IAccessTokenProvider` and register it before calling the Chatwoot registration extensions:

```csharp
using ChatWootApi;
using ChatWootApi.Extensions;

builder.Services.AddSingleton<IAccessTokenProvider, TenantAccessTokenProvider>();
builder.Services.AddChatWootApplicationApi(builder.Configuration);
builder.Services.AddChatWootPlatformApi(builder.Configuration);
```

The extensions register the default provider with `TryAddSingleton`, so an existing custom implementation is preserved. Each request asks for a token by `AccessTokenKind.Account` or `AccessTokenKind.Platform`.
