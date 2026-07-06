using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用集成API。
/// </summary>
public interface IApplicationIntegrationsApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：获取详情全部集成。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v1/accounts/{accountId}/integrations/apps")]
    Task<JsonElement> GetDetailsOfAllIntegrationsAsync(long accountId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：创建集成钩子。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Post("/api/v1/accounts/{accountId}/integrations/hooks")]
    Task<IntegrationsHook> CreateAnIntegrationHookAsync(long accountId, [Body] IntegrationsHookCreatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新集成钩子。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="hookId">hookID。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Patch("/api/v1/accounts/{accountId}/integrations/hooks/{hookId}")]
    Task<IntegrationsHook> UpdateAnIntegrationsHookAsync(long accountId, long hookId, [Body] IntegrationsHookUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：删除集成钩子。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="hookId">hookID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>异步操作。</returns>
    [Delete("/api/v1/accounts/{accountId}/integrations/hooks/{hookId}")]
    Task DeleteAnIntegrationHookAsync(long accountId, long hookId, CancellationToken cancellationToken = default);
}
