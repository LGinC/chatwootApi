using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用HelpCenterAPI。
/// </summary>
public interface IApplicationHelpCenterApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：添加新门户账号。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Post("/api/v1/accounts/{accountId}/portals")]
    Task<Portal> AddNewPortalToAccountAsync(long accountId, [Body] PortalCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取门户。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v1/accounts/{accountId}/portals")]
    Task<Portal> GetPortalAsync(long accountId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新门户账号。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="id">资源 ID。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Patch("/api/v1/accounts/{accountId}/portals/{id}")]
    Task<PortalSingle> UpdatePortalToAccountAsync(long accountId, long id, [Body] PortalCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：添加新分类账号。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="id">资源 ID。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Post("/api/v1/accounts/{accountId}/portals/{id}/categories")]
    Task<Category> AddNewCategoryToAccountAsync(long accountId, long id, [Body] CategoryCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：添加新文章账号。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="id">资源 ID。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Post("/api/v1/accounts/{accountId}/portals/{id}/articles")]
    Task<Article> AddNewArticleToAccountAsync(long accountId, long id, [Body] ArticleCreateUpdatePayload payload, CancellationToken cancellationToken = default);
}
