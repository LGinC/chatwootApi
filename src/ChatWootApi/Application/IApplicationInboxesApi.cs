using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用收件箱API。
/// </summary>
public interface IApplicationInboxesApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：列出全部收件箱。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v1/accounts/{accountId}/inboxes")]
    Task<JsonElement> ListAllInboxesAsync(long accountId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：收件箱创建。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Post("/api/v1/accounts/{accountId}/inboxes")]
    Task<Inbox> InboxCreationAsync(long accountId, [Body] InboxCreatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取收件箱。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="id">资源 ID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v1/accounts/{accountId}/inboxes/{id}")]
    Task<Inbox> GetInboxAsync(long accountId, long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新收件箱。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="id">资源 ID。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Patch("/api/v1/accounts/{accountId}/inboxes/{id}")]
    Task<Inbox> UpdateInboxAsync(long accountId, long id, [Body] InboxUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取收件箱坐席机器人。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="id">资源 ID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>异步操作。</returns>
    [Get("/api/v1/accounts/{accountId}/inboxes/{id}/agent_bot")]
    Task GetInboxAgentBotAsync(long accountId, long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新坐席机器人。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="id">资源 ID。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>异步操作。</returns>
    [Post("/api/v1/accounts/{accountId}/inboxes/{id}/set_agent_bot")]
    Task UpdateAgentBotAsync(long accountId, long id, [Body] JsonElement payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取收件箱成员。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="inboxId">inboxID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v1/accounts/{accountId}/inbox_members/{inboxId}")]
    Task<JsonElement> GetInboxMembersAsync(long accountId, long inboxId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：添加新坐席收件箱。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Post("/api/v1/accounts/{accountId}/inbox_members")]
    Task<JsonElement> AddNewAgentToInboxAsync(long accountId, [Body] JsonElement payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新坐席收件箱。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Patch("/api/v1/accounts/{accountId}/inbox_members")]
    Task<JsonElement> UpdateAgentsInInboxAsync(long accountId, [Body] JsonElement payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：删除坐席收件箱。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>异步操作。</returns>
    [Delete("/api/v1/accounts/{accountId}/inbox_members")]
    Task DeleteAgentInInboxAsync(long accountId, [Body] JsonElement payload, CancellationToken cancellationToken = default);
}
