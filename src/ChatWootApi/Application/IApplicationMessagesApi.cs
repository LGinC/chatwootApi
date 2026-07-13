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
    /// <param name="after">返回此消息 ID 之后的消息</param>
    /// <param name="before">返回此消息 ID 之前的消息</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>原始 JSON 响应数据</returns>
    Task<ConversationMessages> ListAllMessagesAsync(
        long accountId,
        long conversationId,
        long? after = null,
        long? before = null,
        CancellationToken cancellationToken = default)
    {
        if (after is long afterId)
        {
            return before is long beforeId
                ? ListMessagesBetweenAsync(accountId, conversationId, afterId, beforeId, cancellationToken)
                : ListMessagesAfterAsync(accountId, conversationId, afterId, cancellationToken);
        }

        return before is long cursorBeforeId
            ? ListMessagesBeforeAsync(accountId, conversationId, cursorBeforeId, cancellationToken)
            : ListMessagesAsync(accountId, conversationId, cancellationToken);
    }

    /// <summary>列出会话消息，不使用游标。</summary>
    [Get("/api/v1/accounts/{accountId}/conversations/{conversationId}/messages")]
    Task<ConversationMessages> ListMessagesAsync(
        long accountId,
        long conversationId,
        CancellationToken cancellationToken = default);

    /// <summary>列出指定消息 ID 之后的会话消息。</summary>
    [Get("/api/v1/accounts/{accountId}/conversations/{conversationId}/messages?after={after}")]
    Task<ConversationMessages> ListMessagesAfterAsync(
        long accountId,
        long conversationId,
        long after,
        CancellationToken cancellationToken = default);

    /// <summary>列出指定消息 ID 之前的会话消息。</summary>
    [Get("/api/v1/accounts/{accountId}/conversations/{conversationId}/messages?before={before}")]
    Task<ConversationMessages> ListMessagesBeforeAsync(
        long accountId,
        long conversationId,
        long before,
        CancellationToken cancellationToken = default);

    /// <summary>列出两个消息 ID 游标之间的会话消息。</summary>
    [Get("/api/v1/accounts/{accountId}/conversations/{conversationId}/messages?after={after}&before={before}")]
    Task<ConversationMessages> ListMessagesBetweenAsync(
        long accountId,
        long conversationId,
        long after,
        long before,
        CancellationToken cancellationToken = default);

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
