using Refit;
using ChatWootApi.Application.Models;

namespace ChatWootApi.Platform;

/// <summary>
/// Chatwoot 平台 API：平台账号API
/// </summary>
public interface IPlatformAccountApi
{
    /// <summary>
    /// 调用 Chatwoot 平台 API：创建账号
    /// </summary>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>平台账户（Platform Account）</returns>
    [Post("/platform/api/v1/accounts")]
    Task<PlatformAccount> CreateAccountAsync([Body] AccountCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 平台 API：获取账号
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>平台账户（Platform Account）</returns>
    [Get("/platform/api/v1/accounts/{accountId}")]
    Task<PlatformAccount> GetAccountAsync(long accountId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 平台 API：更新账号
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>平台账户（Platform Account）</returns>
    [Patch("/platform/api/v1/accounts/{accountId}")]
    Task<PlatformAccount> UpdateAccountAsync(long accountId, [Body] AccountCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 平台 API：删除账号
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>异步操作</returns>
    [Delete("/platform/api/v1/accounts/{accountId}")]
    Task DeleteAccountAsync(long accountId, CancellationToken cancellationToken = default);
}