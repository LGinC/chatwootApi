# ChatWootApi.Extensions

`ChatWootApi` 的依赖注入扩展，负责注册 Refit 客户端、配置 Chatwoot 服务地址，并为 Application 和 Platform API 自动添加 `api_access_token` 请求头。

## 安装

```bash
dotnet add package ChatWootApi.Extensions
```

该包会传递引用核心包 `ChatWootApi`，通常不需要再次单独安装。

## 配置方式一：使用 IConfiguration

`appsettings.json`：

```json
{
  "ChatWootApi": {
    "BaseAddress": "https://app.chatwoot.com/",
    "AccountAccessToken": "your-account-access-token",
    "PlatformAccessToken": "your-platform-access-token"
  }
}
```

在应用启动时按需注册：

```csharp
using ChatWootApi.Extensions;

builder.Services.AddChatWootApplicationApi(builder.Configuration);
builder.Services.AddChatWootClientApi(builder.Configuration);
builder.Services.AddChatWootPlatformApi(builder.Configuration);
```

配置节名称默认为 `ChatWootApi`，也可以指定其他名称：

```csharp
builder.Services.AddChatWootApplicationApi(
    builder.Configuration,
    sectionName: "Services:Chatwoot");
```

## 配置方式二：使用委托

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

## 调用 API

注册后直接注入细分接口：

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

Application API 也可以注入聚合接口：

```csharp
app.MapGet("/account", async (
    long accountId,
    IChatWootApplicationApi chatwoot,
    CancellationToken cancellationToken) =>
{
    return await chatwoot.GetAccountDetailsAsync(accountId, cancellationToken);
});
```

可用的注册方法：

- `AddChatWootApplicationApi`：注册 Application API，使用 Account access token。
- `AddChatWootClientApi`：注册公开 Client API，不添加 access token。
- `AddChatWootPlatformApi`：注册 Platform API，使用 Platform access token。

## 使用自定义 IAccessTokenProvider

若令牌需要按租户或请求动态获取，实现 `IAccessTokenProvider`，并在调用扩展方法前注册：

```csharp
using ChatWootApi;
using ChatWootApi.Extensions;

builder.Services.AddSingleton<IAccessTokenProvider, TenantAccessTokenProvider>();
builder.Services.AddChatWootApplicationApi(builder.Configuration);
builder.Services.AddChatWootPlatformApi(builder.Configuration);
```

扩展通过 `TryAddSingleton` 注册默认 provider，已有的自定义实现会被保留。每次请求都会根据 `AccessTokenKind.Account` 或 `AccessTokenKind.Platform` 获取相应令牌。

