using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用WebhookAPI。
/// </summary>
public interface IApplicationWebhooksApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：列出全部Webhook。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v1/accounts/{accountId}/webhooks")]
    Task<IReadOnlyList<Webhook>> ListAllWebhooksAsync(long accountId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：创建Webhook。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Post("/api/v1/accounts/{accountId}/webhooks")]
    Task<Webhook> CreateAWebhookAsync(long accountId, [Body] WebhookCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新Webhook。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="webhookId">webhookID。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Patch("/api/v1/accounts/{accountId}/webhooks/{webhookId}")]
    Task<Webhook> UpdateAWebhookAsync(long accountId, long webhookId, [Body] WebhookCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：删除Webhook。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="webhookId">webhookID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>异步操作。</returns>
    [Delete("/api/v1/accounts/{accountId}/webhooks/{webhookId}")]
    Task DeleteAWebhookAsync(long accountId, long webhookId, CancellationToken cancellationToken = default);
}
