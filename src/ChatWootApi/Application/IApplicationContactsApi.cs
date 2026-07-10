using System.Text.Json;
using Refit;
using ChatWootApi.Application.Models;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用联系人API
/// </summary>
public interface IApplicationContactsApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：列出联系人
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>联系人列表</returns>
    [Get("/api/v1/accounts/{accountId}/contacts")]
    Task<ContactsListResponse> ContactListAsync(long accountId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：创建联系人
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>扩展联系人信息</returns>
    [Post("/api/v1/accounts/{accountId}/contacts")]
    Task<ExtendedContact> ContactCreateAsync(long accountId, [Body] ContactCreatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：联系人详情
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>联系人详情</returns>
    [Get("/api/v1/accounts/{accountId}/contacts/{id}")]
    Task<ContactShowResponse> ContactDetailsAsync(long accountId, long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新联系人
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>联系人基础信息</returns>
    [Put("/api/v1/accounts/{accountId}/contacts/{id}")]
    Task<ContactBase> ContactUpdateAsync(long accountId, long id, [Body] ContactUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：删除联系人
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>异步操作</returns>
    [Delete("/api/v1/accounts/{accountId}/contacts/{id}")]
    Task ContactDeleteAsync(long accountId, long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：联系人会话
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>联系人的会话列表</returns>
    [Get("/api/v1/accounts/{accountId}/contacts/{id}/conversations")]
    Task<ContactConversationsResponse> ContactConversationsAsync(long accountId, long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：搜索联系人
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="query">查询参数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>联系人列表</returns>
    [Get("/api/v1/accounts/{accountId}/contacts/search")]
    Task<ContactsListResponse> ContactSearchAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：筛选联系人
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="query">查询参数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>联系人列表</returns>
    [Post("/api/v1/accounts/{accountId}/contacts/filter")]
    Task<ContactsListResponse> ContactFilterAsync(long accountId, [Body] FilterPayload payload, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：联系人收件箱创建
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>联系人收件箱关联</returns>
    [Post("/api/v1/accounts/{accountId}/contacts/{id}/contact_inboxes")]
    Task<ContactInboxes> ContactInboxCreationAsync(long accountId, long id, [Body] ContactInboxCreatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取Contactable收件箱
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>可联系的收件箱列表</returns>
    [Get("/api/v1/accounts/{accountId}/contacts/{id}/contactable_inboxes")]
    Task<ContactableInboxesResponse> ContactableInboxesGetAsync(long accountId, long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：合并联系人
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>联系人基础信息</returns>
    [Post("/api/v1/accounts/{accountId}/actions/contact_merge")]
    Task<ContactBase> ContactMergeAsync(long accountId, [Body] ContactMergePayload payload, CancellationToken cancellationToken = default);
}
