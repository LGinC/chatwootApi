using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用联系人标签API。
/// </summary>
public interface IApplicationContactLabelsApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：列出全部标签联系人。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="id">资源 ID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v1/accounts/{accountId}/contacts/{id}/labels")]
    Task<ContactLabels> ListAllLabelsOfAContactAsync(long accountId, long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：联系人Add标签。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="id">资源 ID。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Post("/api/v1/accounts/{accountId}/contacts/{id}/labels")]
    Task<ContactLabels> ContactAddLabelsAsync(long accountId, long id, [Body] JsonElement payload, CancellationToken cancellationToken = default);
}
