# ChatWootApi.Extensions

`ChatWootApi` 的依赖注入扩展，负责注册 Refit 客户端、配置 Chatwoot 服务地址，并为 Application 和 Platform API 自动添加 `api_access_token` 请求头

## 安装

```bash
dotnet add package ChatWootApi.Extensions
```

该包会传递引用核心包 `ChatWootApi`，通常不需要再次单独安装

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

## HTTP 请求和响应日志

默认关闭日志。将 `EnableLogging` 设置为 `true` 后，所有已注册的 Chatwoot API 客户端都会记录日志：

```json
{
  "ChatWootApi": {
    "BaseAddress": "https://app.chatwoot.com/",
    "EnableLogging": true,
    "IncludeBodyInLogs": false
  }
}
```

如果只需要记录指定 API，请保持 `EnableLogging` 为 `false`，并配置 `LoggingApiNames`：

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

`LoggingApiNames` 支持 API 接口短名称或完整类型名称。处理器会记录 HTTP 方法、已脱敏的 URI、请求头、响应状态码和耗时。请求体和响应体默认不记录，只有启用 `IncludeBodyInLogs` 后才会记录；access token、Authorization/Cookie 请求头、敏感查询参数以及常见敏感 JSON/表单字段会在记录前掩码，无法安全识别或超过大小限制的内容会省略。

该包使用 `Microsoft.Extensions.Logging`，请按宿主应用的方式配置日志 Provider 和日志级别。

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

- `AddChatWootApplicationApi`：注册 Application API，使用 Account access token
- `AddChatWootClientApi`：注册公开 Client API，不添加 access token
- `AddChatWootPlatformApi`：注册 Platform API，使用 Platform access token

## Application API 临时切换 access token

Application API 的 `api_access_token` 通常是用户级令牌默认 `AccessTokenProvider` 支持通过 `using` 创建异步上下文范围内的临时 Application access token，范围结束后自动恢复外层令牌或配置中的 `AccountAccessToken`

```csharp
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

嵌套调用会在内层 `using` 释放后恢复外层 token；Platform API 始终使用 `PlatformAccessToken`，不会受 Application token scope 影响若未配置 `AccountAccessToken` 且当前没有 Application token scope，调用 Application API 会抛出 `InvalidOperationException`

## 使用自定义 IAccessTokenProvider

若令牌需要完全由租户上下文或请求上下文动态获取，实现 `IAccessTokenProvider`，并在调用扩展方法前注册：

```csharp
using ChatWootApi;
using ChatWootApi.Extensions;

builder.Services.AddSingleton<IAccessTokenProvider, TenantAccessTokenProvider>();
builder.Services.AddChatWootApplicationApi(builder.Configuration);
builder.Services.AddChatWootPlatformApi(builder.Configuration);
```

扩展通过 `TryAddSingleton` 注册默认 provider，已有的自定义实现会被保留每次请求都会根据 `AccessTokenKind.Account` 或 `AccessTokenKind.Platform` 获取相应令牌

