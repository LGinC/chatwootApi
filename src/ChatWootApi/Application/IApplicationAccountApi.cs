using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用账号API。
/// </summary>
public interface IApplicationAccountApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：获取账号详情。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v1/accounts/{accountId}")]
    Task<AccountShowResponse> GetAccountDetailsAsync(long accountId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新账号。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Patch("/api/v1/accounts/{accountId}")]
    Task<AccountDetail> UpdateAccountAsync(long accountId, [Body] AccountUpdatePayload payload, CancellationToken cancellationToken = default);
}
