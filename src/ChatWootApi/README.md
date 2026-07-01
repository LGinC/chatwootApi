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

## 自定义 Access Token

默认的 `IAccessTokenProvider` 从 `ChatWootApiOptions` 读取 Account 或 Platform token。若 token 来自数据库、租户上下文或密钥服务，可自行实现该接口：

```csharp
using ChatWootApi;

public sealed class TenantAccessTokenProvider : IAccessTokenProvider
{
    public async ValueTask<string> GetAccessTokenAsync(
        AccessTokenKind tokenKind,
        CancellationToken cancellationToken = default)
    {
        return tokenKind switch
        {
            AccessTokenKind.Account => await LoadAccountTokenAsync(cancellationToken),
            AccessTokenKind.Platform => await LoadPlatformTokenAsync(cancellationToken),
            _ => throw new ArgumentOutOfRangeException(nameof(tokenKind), tokenKind, null)
        };
    }

    private static Task<string> LoadAccountTokenAsync(CancellationToken cancellationToken) =>
        Task.FromResult("account-token");

    private static Task<string> LoadPlatformTokenAsync(CancellationToken cancellationToken) =>
        Task.FromResult("platform-token");
}
```

在调用 ChatWoot 注册扩展前注册自定义实现。扩展使用 `TryAddSingleton`，因此不会覆盖它：

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

