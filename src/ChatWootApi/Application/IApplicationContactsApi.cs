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
    /// <param name="q">按联系人名称、标识符、邮箱或电话搜索</param>
    /// <param name="sort">列表排序字段</param>
    /// <param name="page">分页页码</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>联系人列表</returns>
    Task<ContactsListResponse> ContactSearchAsync(
        long accountId,
        string? q = null,
        ContactSort? sort = null,
        long? page = null,
        CancellationToken cancellationToken = default)
    {
        if (q is not null)
        {
            if (sort is ContactSort sortWithQ)
            {
                return page is long pageWithQSort
                    ? ContactSearchWithQSortAndPageAsync(accountId, q, sortWithQ, pageWithQSort, cancellationToken)
                    : ContactSearchWithQAndSortAsync(accountId, q, sortWithQ, cancellationToken);
            }

            return page is long pageWithQ
                ? ContactSearchWithQAndPageAsync(accountId, q, pageWithQ, cancellationToken)
                : ContactSearchWithQAsync(accountId, q, cancellationToken);
        }

        if (sort is ContactSort sortOnly)
        {
            return page is long pageWithSort
                ? ContactSearchWithSortAndPageAsync(accountId, sortOnly, pageWithSort, cancellationToken)
                : ContactSearchWithSortAsync(accountId, sortOnly, cancellationToken);
        }

        return page is long pageOnly
            ? ContactSearchWithPageAsync(accountId, pageOnly, cancellationToken)
            : ContactSearchAsync(accountId, cancellationToken);
    }

    /// <summary>搜索联系人（无查询参数）。</summary>
    [Get("/api/v1/accounts/{accountId}/contacts/search")]
    Task<ContactsListResponse> ContactSearchAsync(
        long accountId,
        CancellationToken cancellationToken = default);

    /// <summary>按关键词搜索联系人。</summary>
    [Get("/api/v1/accounts/{accountId}/contacts/search?q={q}")]
    Task<ContactsListResponse> ContactSearchWithQAsync(
        long accountId,
        string q,
        CancellationToken cancellationToken = default);

    /// <summary>按排序字段搜索联系人。</summary>
    [Get("/api/v1/accounts/{accountId}/contacts/search?sort={sort}")]
    Task<ContactsListResponse> ContactSearchWithSortAsync(
        long accountId,
        ContactSort sort,
        CancellationToken cancellationToken = default);

    /// <summary>按页码搜索联系人。</summary>
    [Get("/api/v1/accounts/{accountId}/contacts/search?page={page}")]
    Task<ContactsListResponse> ContactSearchWithPageAsync(
        long accountId,
        long page,
        CancellationToken cancellationToken = default);

    /// <summary>按关键词与排序搜索联系人。</summary>
    [Get("/api/v1/accounts/{accountId}/contacts/search?q={q}&sort={sort}")]
    Task<ContactsListResponse> ContactSearchWithQAndSortAsync(
        long accountId,
        string q,
        ContactSort sort,
        CancellationToken cancellationToken = default);

    /// <summary>按关键词与页码搜索联系人。</summary>
    [Get("/api/v1/accounts/{accountId}/contacts/search?q={q}&page={page}")]
    Task<ContactsListResponse> ContactSearchWithQAndPageAsync(
        long accountId,
        string q,
        long page,
        CancellationToken cancellationToken = default);

    /// <summary>按排序与页码搜索联系人。</summary>
    [Get("/api/v1/accounts/{accountId}/contacts/search?sort={sort}&page={page}")]
    Task<ContactsListResponse> ContactSearchWithSortAndPageAsync(
        long accountId,
        ContactSort sort,
        long page,
        CancellationToken cancellationToken = default);

    /// <summary>按关键词、排序与页码搜索联系人。</summary>
    [Get("/api/v1/accounts/{accountId}/contacts/search?q={q}&sort={sort}&page={page}")]
    Task<ContactsListResponse> ContactSearchWithQSortAndPageAsync(
        long accountId,
        string q,
        ContactSort sort,
        long page,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：筛选联系人
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="page">分页页码</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>联系人列表</returns>
    Task<ContactsListResponse> ContactFilterAsync(
        long accountId,
        FilterPayload payload,
        long? page = null,
        CancellationToken cancellationToken = default)
        => page is long pageNumber
            ? ContactFilterByPageAsync(accountId, payload, pageNumber, cancellationToken)
            : ContactFilterAsync(accountId, payload, cancellationToken);

    /// <summary>筛选联系人（不带分页）。</summary>
    [Post("/api/v1/accounts/{accountId}/contacts/filter")]
    Task<ContactsListResponse> ContactFilterAsync(
        long accountId,
        [Body] FilterPayload payload,
        CancellationToken cancellationToken = default);

    /// <summary>按页码筛选联系人。</summary>
    [Post("/api/v1/accounts/{accountId}/contacts/filter?page={page}")]
    Task<ContactsListResponse> ContactFilterByPageAsync(
        long accountId,
        [Body] FilterPayload payload,
        long page,
        CancellationToken cancellationToken = default);

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
