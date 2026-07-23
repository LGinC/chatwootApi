using Refit;
using ChatWootApi.Application.Models;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用自定义筛选器API
/// </summary>
public interface IApplicationCustomFiltersApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：列出全部筛选器
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="filterType">自定义筛选器类型</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>自定义筛选器的只读列表</returns>
    Task<IReadOnlyList<CustomFilter>> ListAllFiltersAsync(
        long accountId,
        CustomFilterType? filterType = null,
        CancellationToken cancellationToken = default)
        => filterType is CustomFilterType type
            ? ListAllFiltersByTypeAsync(accountId, type, cancellationToken)
            : ListAllFiltersAsync(accountId, cancellationToken);

    /// <summary>列出全部自定义筛选器（不按类型过滤）。</summary>
    [Get("/api/v1/accounts/{accountId}/custom_filters")]
    Task<IReadOnlyList<CustomFilter>> ListAllFiltersAsync(
        long accountId,
        CancellationToken cancellationToken = default);

    /// <summary>按类型列出自定义筛选器。</summary>
    [Get("/api/v1/accounts/{accountId}/custom_filters?filter_type={filterType}")]
    Task<IReadOnlyList<CustomFilter>> ListAllFiltersByTypeAsync(
        long accountId,
        CustomFilterType filterType,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：创建自定义筛选器
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="filterType">自定义筛选器类型</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>自定义筛选器</returns>
    Task<CustomFilter> CreateACustomFilterAsync(
        long accountId,
        CustomFilterCreateUpdatePayload payload,
        CustomFilterType? filterType = null,
        CancellationToken cancellationToken = default)
        => filterType is CustomFilterType type
            ? CreateACustomFilterByTypeAsync(accountId, payload, type, cancellationToken)
            : CreateACustomFilterAsync(accountId, payload, cancellationToken);

    /// <summary>创建自定义筛选器（不带类型 query）。</summary>
    [Post("/api/v1/accounts/{accountId}/custom_filters")]
    Task<CustomFilter> CreateACustomFilterAsync(
        long accountId,
        [Body] CustomFilterCreateUpdatePayload payload,
        CancellationToken cancellationToken = default);

    /// <summary>创建指定类型的自定义筛选器。</summary>
    [Post("/api/v1/accounts/{accountId}/custom_filters?filter_type={filterType}")]
    Task<CustomFilter> CreateACustomFilterByTypeAsync(
        long accountId,
        [Body] CustomFilterCreateUpdatePayload payload,
        CustomFilterType filterType,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取详情单个自定义筛选器
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="customFilterId">custom筛选器ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>自定义筛选器</returns>
    [Get("/api/v1/accounts/{accountId}/custom_filters/{customFilterId}")]
    Task<CustomFilter> GetDetailsOfASingleCustomFilterAsync(long accountId, long customFilterId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新自定义筛选器
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="customFilterId">custom筛选器ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>自定义筛选器</returns>
    [Patch("/api/v1/accounts/{accountId}/custom_filters/{customFilterId}")]
    Task<CustomFilter> UpdateACustomFilterAsync(long accountId, long customFilterId, [Body] CustomFilterCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：删除自定义筛选器
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="customFilterId">custom筛选器ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>异步操作</returns>
    [Delete("/api/v1/accounts/{accountId}/custom_filters/{customFilterId}")]
    Task DeleteACustomFilterAsync(long accountId, long customFilterId, CancellationToken cancellationToken = default);
}
