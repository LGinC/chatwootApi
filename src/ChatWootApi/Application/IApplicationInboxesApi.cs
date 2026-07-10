using System.Text.Json;
using Refit;
using ChatWootApi.Application.Models;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用收件箱API
/// </summary>
public interface IApplicationInboxesApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：列出全部收件箱
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>原始 JSON 响应数据</returns>
    [Get("/api/v1/accounts/{accountId}/inboxes")]
    Task<InboxesListResponse> ListAllInboxesAsync(long accountId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：收件箱创建
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>收件箱（Inbox）</returns>
    [Post("/api/v1/accounts/{accountId}/inboxes")]
    Task<Inbox> InboxCreationAsync(long accountId, [Body] InboxCreatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取收件箱
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>收件箱（Inbox）</returns>
    [Get("/api/v1/accounts/{accountId}/inboxes/{id}")]
    Task<Inbox> GetInboxAsync(long accountId, long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新收件箱
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>收件箱（Inbox）</returns>
    [Patch("/api/v1/accounts/{accountId}/inboxes/{id}")]
    Task<Inbox> UpdateInboxAsync(long accountId, long id, [Body] InboxUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取收件箱坐席机器人
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>AgentBot 实例</returns>
    [Get("/api/v1/accounts/{accountId}/inboxes/{id}/agent_bot")]
    Task<AgentBot> GetInboxAgentBotAsync(long accountId, long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新坐席机器人
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>异步操作</returns>
    [Post("/api/v1/accounts/{accountId}/inboxes/{id}/set_agent_bot")]
    Task UpdateAgentBotAsync(long accountId, long id, [Body] InboxAgentBotUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取收件箱成员
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="inboxId">inboxID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>收件箱中的有效坐席列表</returns>
    [Get("/api/v1/accounts/{accountId}/inbox_members/{inboxId}")]
    Task<InboxMembersResponse> GetInboxMembersAsync(long accountId, long inboxId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：添加新坐席收件箱
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="payload">收件箱 ID 和要添加的用户 ID 列表</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>收件箱中的有效坐席列表</returns>
    [Post("/api/v1/accounts/{accountId}/inbox_members")]
    Task<InboxMembersResponse> AddNewAgentToInboxAsync(long accountId, [Body] InboxMembersCreatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新坐席收件箱
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>收件箱中的有效坐席列表</returns>
    [Patch("/api/v1/accounts/{accountId}/inbox_members")]
    Task<InboxMembersResponse> UpdateAgentsInInboxAsync(long accountId, [Body] InboxMembersUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：删除坐席收件箱
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>异步操作</returns>
    [Delete("/api/v1/accounts/{accountId}/inbox_members")]
    Task DeleteAgentInInboxAsync(long accountId, [Body] InboxMembersUpdatePayload payload, CancellationToken cancellationToken = default);
}
