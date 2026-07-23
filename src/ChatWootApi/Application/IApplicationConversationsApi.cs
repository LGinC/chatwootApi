using Refit;
using ChatWootApi.Application.Models;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用会话API
/// </summary>
public interface IApplicationConversationsApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：会话列表元数据
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="status">按会话状态筛选</param>
    /// <param name="q">按消息内容搜索词筛选</param>
    /// <param name="inboxId">收件箱 ID</param>
    /// <param name="teamId">团队 ID</param>
    /// <param name="labels">标签列表</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>会话列表计数</returns>
    Task<ConversationListMetaResponse> ConversationListMetaAsync(
        long accountId,
        ConversationStatus? status = null,
        string? q = null,
        long? inboxId = null,
        long? teamId = null,
        IEnumerable<string>? labels = null,
        CancellationToken cancellationToken = default)
    {
        string? labelsQuery = labels is null ? null : string.Join(",", labels);
        return ConversationListMetaAsync(accountId, status, q, inboxId, teamId, labelsQuery, cancellationToken);
    }

    /// <summary>会话列表元数据（path query 模板）。</summary>
    [Get("/api/v1/accounts/{accountId}/conversations/meta?status={status}&q={q}&inbox_id={inboxId}&team_id={teamId}&labels={labels}")]
    Task<ConversationListMetaResponse> ConversationListMetaAsync(
        long accountId,
        ConversationStatus? status,
        string? q,
        long? inboxId,
        long? teamId,
        string? labels,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：列出会话
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="assigneeType">按负责人类型筛选</param>
    /// <param name="status">按会话状态筛选</param>
    /// <param name="q">按消息内容搜索词筛选</param>
    /// <param name="inboxId">收件箱 ID</param>
    /// <param name="teamId">团队 ID</param>
    /// <param name="labels">标签列表</param>
    /// <param name="page">分页页码</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>会话列表</returns>
    Task<ConversationList> ConversationListAsync(
        long accountId,
        ConversationAssigneeType? assigneeType = null,
        ConversationStatus? status = null,
        string? q = null,
        long? inboxId = null,
        long? teamId = null,
        IEnumerable<string>? labels = null,
        long? page = null,
        CancellationToken cancellationToken = default)
    {
        string? labelsQuery = labels is null ? null : string.Join(",", labels);
        return ConversationListAsync(accountId, assigneeType, status, q, inboxId, teamId, labelsQuery, page, cancellationToken);
    }

    /// <summary>列出会话（path query 模板）。</summary>
    [Get("/api/v1/accounts/{accountId}/conversations?assignee_type={assigneeType}&status={status}&q={q}&inbox_id={inboxId}&team_id={teamId}&labels={labels}&page={page}")]
    Task<ConversationList> ConversationListAsync(
        long accountId,
        ConversationAssigneeType? assigneeType,
        ConversationStatus? status,
        string? q,
        long? inboxId,
        long? teamId,
        string? labels,
        long? page,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：新会话
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>原始 JSON 响应数据</returns>
    [Post("/api/v1/accounts/{accountId}/conversations")]
    Task<ConversationCreateResponse> NewConversationAsync(long accountId, [Body] ConversationCreatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：筛选会话
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="page">分页页码</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>会话列表</returns>
    Task<ConversationList> ConversationFilterAsync(
        long accountId,
        FilterPayload payload,
        long? page = null,
        CancellationToken cancellationToken = default)
        => page is long pageNumber
            ? ConversationFilterByPageAsync(accountId, payload, pageNumber, cancellationToken)
            : ConversationFilterAsync(accountId, payload, cancellationToken);

    /// <summary>筛选会话（不带分页）。</summary>
    [Post("/api/v1/accounts/{accountId}/conversations/filter")]
    Task<ConversationList> ConversationFilterAsync(
        long accountId,
        [Body] FilterPayload payload,
        CancellationToken cancellationToken = default);

    /// <summary>按页码筛选会话。</summary>
    [Post("/api/v1/accounts/{accountId}/conversations/filter?page={page}")]
    Task<ConversationList> ConversationFilterByPageAsync(
        long accountId,
        [Body] FilterPayload payload,
        long page,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取详情会话
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="conversationId">会话 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>会话详情</returns>
    [Get("/api/v1/accounts/{accountId}/conversations/{conversationId}")]
    Task<ConversationShow> GetDetailsOfAConversationAsync(long accountId, long conversationId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新会话
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="conversationId">会话 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>会话信息</returns>
    [Patch("/api/v1/accounts/{accountId}/conversations/{conversationId}")]
    Task<Conversation> UpdateConversationAsync(long accountId, long conversationId, [Body] ConversationUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：切换状态会话
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="conversationId">会话 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>原始 JSON 响应数据</returns>
    [Post("/api/v1/accounts/{accountId}/conversations/{conversationId}/toggle_status")]
    Task<ConversationStatusUpdateResponse> ToggleStatusOfAConversationAsync(long accountId, long conversationId, [Body] ConversationStatusUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：切换优先级会话
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="conversationId">会话 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>异步操作</returns>
    [Post("/api/v1/accounts/{accountId}/conversations/{conversationId}/toggle_priority")]
    Task TogglePriorityOfAConversationAsync(long accountId, long conversationId, [Body] ConversationPriorityUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：切换输入状态会话
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="conversationId">会话 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>异步操作</returns>
    [Post("/api/v1/accounts/{accountId}/conversations/{conversationId}/toggle_typing_status")]
    Task ToggleTypingStatusOfAConversationAsync(long accountId, long conversationId, [Body] ConversationTypingStatusPayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新自定义属性会话
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="conversationId">会话 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>原始 JSON 响应数据</returns>
    [Post("/api/v1/accounts/{accountId}/conversations/{conversationId}/custom_attributes")]
    Task<ConversationCustomAttributesResponse> UpdateCustomAttributesOfAConversationAsync(long accountId, long conversationId, [Body] ConversationCustomAttributesUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：列出全部标签会话
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="conversationId">会话 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>会话标签集合</returns>
    [Get("/api/v1/accounts/{accountId}/conversations/{conversationId}/labels")]
    Task<ConversationLabels> ListAllLabelsOfAConversationAsync(long accountId, long conversationId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：会话Add标签
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="conversationId">会话 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>会话标签集合</returns>
    [Post("/api/v1/accounts/{accountId}/conversations/{conversationId}/labels")]
    Task<ConversationLabels> ConversationAddLabelsAsync(long accountId, long conversationId, [Body] LabelsPayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取会话Reporting事件
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="conversationId">会话 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>上报事件（Reporting Event）的只读列表</returns>
    [Get("/api/v1/accounts/{accountId}/conversations/{conversationId}/reporting_events")]
    Task<IReadOnlyList<ReportingEvent>> GetConversationReportingEventsAsync(long accountId, long conversationId, CancellationToken cancellationToken = default);
}
