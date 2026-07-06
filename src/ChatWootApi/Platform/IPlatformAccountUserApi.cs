using Refit;

namespace ChatWootApi.Platform;

/// <summary>
/// Chatwoot 平台 API：平台账号用户API。
/// </summary>
public interface IPlatformAccountUserApi
{
    /// <summary>
    /// 调用 Chatwoot 平台 API：列出账号用户。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/platform/api/v1/accounts/{accountId}/account_users")]
    Task<IReadOnlyList<AccountUser>> ListAccountUsersAsync(long accountId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 平台 API：创建账号用户。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Post("/platform/api/v1/accounts/{accountId}/account_users")]
    Task<AccountUser> CreateAccountUserAsync(long accountId, [Body] AccountUserCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 平台 API：删除账号用户。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>异步操作。</returns>
    [Delete("/platform/api/v1/accounts/{accountId}/account_users")]
    Task DeleteAccountUserAsync(long accountId, CancellationToken cancellationToken = default);
}
