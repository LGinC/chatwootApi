using Refit;

namespace ChatWootApi.Client;

/// <summary>
/// Chatwoot 客户端 API：客户端会话API。
/// </summary>
public interface IClientConversationApi
{
    /// <summary>
    /// 调用 Chatwoot 客户端 API：创建会话。
    /// </summary>
    /// <param name="inboxIdentifier">收件箱标识符。</param>
    /// <param name="contactIdentifier">联系人标识符。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Post("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}/conversations")]
    Task<Conversation> CreateConversationAsync(string inboxIdentifier, string contactIdentifier, [Body] ConversationCreatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 客户端 API：列出会话。
    /// </summary>
    /// <param name="inboxIdentifier">收件箱标识符。</param>
    /// <param name="contactIdentifier">联系人标识符。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}/conversations")]
    Task<IReadOnlyList<Conversation>> ListConversationsAsync(string inboxIdentifier, string contactIdentifier, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 客户端 API：获取会话。
    /// </summary>
    /// <param name="inboxIdentifier">收件箱标识符。</param>
    /// <param name="contactIdentifier">联系人标识符。</param>
    /// <param name="conversationId">会话 ID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}/conversations/{conversationId}")]
    Task<Conversation> GetConversationAsync(string inboxIdentifier, string contactIdentifier, long conversationId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 客户端 API：切换会话状态。
    /// </summary>
    /// <param name="inboxIdentifier">收件箱标识符。</param>
    /// <param name="contactIdentifier">联系人标识符。</param>
    /// <param name="conversationId">会话 ID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Post("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}/conversations/{conversationId}/toggle_status")]
    Task<Conversation> ToggleConversationStatusAsync(string inboxIdentifier, string contactIdentifier, long conversationId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 客户端 API：切换输入。
    /// </summary>
    /// <param name="inboxIdentifier">收件箱标识符。</param>
    /// <param name="contactIdentifier">联系人标识符。</param>
    /// <param name="conversationId">会话 ID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>异步操作。</returns>
    [Post("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}/conversations/{conversationId}/toggle_typing")]
    Task ToggleTypingAsync(string inboxIdentifier, string contactIdentifier, long conversationId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 客户端 API：更新最后查看。
    /// </summary>
    /// <param name="inboxIdentifier">收件箱标识符。</param>
    /// <param name="contactIdentifier">联系人标识符。</param>
    /// <param name="conversationId">会话 ID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>异步操作。</returns>
    [Post("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}/conversations/{conversationId}/update_last_seen")]
    Task UpdateLastSeenAsync(string inboxIdentifier, string contactIdentifier, long conversationId, CancellationToken cancellationToken = default);
}
