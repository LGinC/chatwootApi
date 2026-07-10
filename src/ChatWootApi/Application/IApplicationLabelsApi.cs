using System.Text.Json;
using Refit;
using ChatWootApi.Application.Models;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用标签API
/// </summary>
public interface IApplicationLabelsApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：列出全部标签
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>原始 JSON 响应数据</returns>
    [Get("/api/v1/accounts/{accountId}/labels")]
    Task<LabelsListResponse> ListAllLabelsAsync(long accountId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：创建标签
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>标签（Label）</returns>
    [Post("/api/v1/accounts/{accountId}/labels")]
    Task<Label> CreateALabelAsync(long accountId, [Body] LabelCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取详情单个标签
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>标签（Label）</returns>
    [Get("/api/v1/accounts/{accountId}/labels/{id}")]
    Task<Label> GetDetailsOfASingleLabelAsync(long accountId, long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新标签
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>标签（Label）</returns>
    [Patch("/api/v1/accounts/{accountId}/labels/{id}")]
    Task<Label> UpdateALabelAsync(long accountId, long id, [Body] LabelCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：删除标签
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>异步操作</returns>
    [Delete("/api/v1/accounts/{accountId}/labels/{id}")]
    Task DeleteALabelAsync(long accountId, long id, CancellationToken cancellationToken = default);
}
