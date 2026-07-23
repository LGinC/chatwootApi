using Refit;
using ChatWootApi.Application.Models;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用自定义属性API
/// </summary>
public interface IApplicationCustomAttributesApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：获取账号自定义属性
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="attributeModel">属性模型：会话属性(0)/联系人属性(1)</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>自定义属性定义的只读列表</returns>
    [Get("/api/v1/accounts/{accountId}/custom_attribute_definitions?attribute_model={attributeModel}")]
    Task<IReadOnlyList<CustomAttribute>> GetAccountCustomAttributeAsync(
        long accountId,
        CustomAttributeModel attributeModel,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：添加新自定义属性账号
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>自定义属性定义</returns>
    [Post("/api/v1/accounts/{accountId}/custom_attribute_definitions")]
    Task<CustomAttribute> AddNewCustomAttributeToAccountAsync(long accountId, [Body] CustomAttributeCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取详情单个自定义属性
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>自定义属性定义</returns>
    [Get("/api/v1/accounts/{accountId}/custom_attribute_definitions/{id}")]
    Task<CustomAttribute> GetDetailsOfASingleCustomAttributeAsync(long accountId, long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新自定义属性账号
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>自定义属性定义</returns>
    [Patch("/api/v1/accounts/{accountId}/custom_attribute_definitions/{id}")]
    Task<CustomAttribute> UpdateCustomAttributeInAccountAsync(long accountId, long id, [Body] CustomAttributeCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：删除自定义属性账号
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>异步操作</returns>
    [Delete("/api/v1/accounts/{accountId}/custom_attribute_definitions/{id}")]
    Task DeleteCustomAttributeFromAccountAsync(long accountId, long id, CancellationToken cancellationToken = default);
}
