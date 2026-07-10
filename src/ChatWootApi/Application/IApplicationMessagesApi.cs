using System.Text.Json;
using Refit;
using ChatWootApi.Application.Models;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用消息API
/// </summary>
public interface IApplicationMessagesApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：列出全部消息
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="conversationId">会话 ID</param>
    /// <param name="query">查询参数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>原始 JSON 响应数据</returns>
    [Get("/api/v1/accounts/{accountId}/conversations/{conversationId}/messages")]
    Task<ConversationMessages> ListAllMessagesAsync(long accountId, long conversationId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：创建新消息会话
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="conversationId">会话 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>原始 JSON 响应数据</returns>
    [Post("/api/v1/accounts/{accountId}/conversations/{conversationId}/messages")]
    Task<Message> CreateANewMessageInAConversationAsync(long accountId, long conversationId, [Body] ConversationMessageCreatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：删除消息
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="conversationId">会话 ID</param>
    /// <param name="messageId">messageID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>异步操作</returns>
    [Delete("/api/v1/accounts/{accountId}/conversations/{conversationId}/messages/{messageId}")]
    Task DeleteAMessageAsync(long accountId, long conversationId, long messageId, CancellationToken cancellationToken = default);
}
