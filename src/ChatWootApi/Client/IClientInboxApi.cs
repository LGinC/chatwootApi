using Refit;
ChatWootApi.Application.Models;
ChatWootApi.Application.Models;

namespace ChatWootApi.Client;

/// <summary>
/// Chatwoot 客户端 API：客户端收件箱API
/// </summary>
public interface IClientInboxApi
{
    /// <summary>
    /// 调用 Chatwoot 客户端 API：获取收件箱
    /// </summary>
    /// <param name="inboxIdentifier">收件箱标识符</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>收件箱（Inbox）</returns>
    [Get("/public/api/v1/inboxes/{inboxIdentifier}")]
    Task<Inbox> GetInboxAsync(string inboxIdentifier, CancellationToken cancellationToken = default);
}