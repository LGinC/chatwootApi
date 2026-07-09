using System.Text.Json;
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
    /// <param name="query">查询参数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>自定义筛选器的只读列表</returns>
    [Get("/api/v1/accounts/{accountId}/custom_filters")]
    Task<IReadOnlyList<CustomFilter>> ListAllFiltersAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：创建自定义筛选器
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="query">查询参数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>自定义筛选器</returns>
    [Post("/api/v1/accounts/{accountId}/custom_filters")]
    Task<CustomFilter> CreateACustomFilterAsync(long accountId, [Body] CustomFilterCreateUpdatePayload payload, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

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
