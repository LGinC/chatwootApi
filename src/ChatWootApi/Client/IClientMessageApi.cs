using Refit;
using ChatWootApi.Client.Models;

namespace ChatWootApi.Client;

/// <summary>
/// Chatwoot 客户端 API：客户端消息API
/// </summary>
public interface IClientMessageApi
{
    /// <summary>
    /// 调用 Chatwoot 客户端 API：创建消息
    /// </summary>
    /// <param name="inboxIdentifier">收件箱标识符</param>
    /// <param name="contactIdentifier">联系人标识符</param>
    /// <param name="conversationId">会话 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>Message 实例</returns>
    [Post("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}/conversations/{conversationId}/messages")]
    Task<Message> CreateMessageAsync(string inboxIdentifier, string contactIdentifier, long conversationId, [Body] MessageCreatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 客户端 API：列出消息
    /// </summary>
    /// <param name="inboxIdentifier">收件箱标识符</param>
    /// <param name="contactIdentifier">联系人标识符</param>
    /// <param name="conversationId">会话 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>消息（Message）的只读列表</returns>
    [Get("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}/conversations/{conversationId}/messages")]
    Task<IReadOnlyList<Message>> ListMessagesAsync(string inboxIdentifier, string contactIdentifier, long conversationId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 客户端 API：更新消息
    /// </summary>
    /// <param name="inboxIdentifier">收件箱标识符</param>
    /// <param name="contactIdentifier">联系人标识符</param>
    /// <param name="conversationId">会话 ID</param>
    /// <param name="messageId">messageID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>Message 实例</returns>
    [Patch("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}/conversations/{conversationId}/messages/{messageId}")]
    Task<Message> UpdateMessageAsync(string inboxIdentifier, string contactIdentifier, long conversationId, long messageId, [Body] MessageUpdatePayload payload, CancellationToken cancellationToken = default);
}
