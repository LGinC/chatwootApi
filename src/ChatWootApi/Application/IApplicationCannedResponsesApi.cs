using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用预置响应API。
/// </summary>
public interface IApplicationCannedResponsesApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：获取账号预置响应。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v1/accounts/{accountId}/canned_responses")]
    Task<IReadOnlyList<CannedResponse>> GetAccountCannedResponseAsync(long accountId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：添加新预置响应账号。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Post("/api/v1/accounts/{accountId}/canned_responses")]
    Task<CannedResponse> AddNewCannedResponseToAccountAsync(long accountId, [Body] CannedResponseCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新预置响应账号。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="id">资源 ID。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Patch("/api/v1/accounts/{accountId}/canned_responses/{id}")]
    Task<CannedResponse> UpdateCannedResponseInAccountAsync(long accountId, long id, [Body] CannedResponseCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：删除预置响应账号。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="id">资源 ID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>异步操作。</returns>
    [Delete("/api/v1/accounts/{accountId}/canned_responses/{id}")]
    Task DeleteCannedResponseFromAccountAsync(long accountId, long id, CancellationToken cancellationToken = default);
}
