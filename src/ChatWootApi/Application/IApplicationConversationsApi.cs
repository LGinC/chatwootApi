using System.Text.Json;
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
    /// <param name="query">查询参数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>原始 JSON 响应数据</returns>
    [Get("/api/v1/accounts/{accountId}/conversations/meta")]
    Task<ConversationListMetaResponse> ConversationListMetaAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：列出会话
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="query">查询参数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>会话列表</returns>
    [Get("/api/v1/accounts/{accountId}/conversations")]
    Task<ConversationList> ConversationListAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

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
    /// <param name="query">查询参数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>会话列表</returns>
    [Post("/api/v1/accounts/{accountId}/conversations/filter")]
    Task<ConversationList> ConversationFilterAsync(long accountId, [Body] FilterPayload payload, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

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
