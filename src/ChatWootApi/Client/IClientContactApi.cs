using Refit;

namespace ChatWootApi.Client;

/// <summary>
/// Chatwoot 客户端 API：客户端联系人API。
/// </summary>
public interface IClientContactApi
{
    /// <summary>
    /// 调用 Chatwoot 客户端 API：创建联系人。
    /// </summary>
    /// <param name="inboxIdentifier">收件箱标识符。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Post("/public/api/v1/inboxes/{inboxIdentifier}/contacts")]
    Task<Contact> CreateContactAsync(string inboxIdentifier, [Body] ContactCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 客户端 API：获取联系人。
    /// </summary>
    /// <param name="inboxIdentifier">收件箱标识符。</param>
    /// <param name="contactIdentifier">联系人标识符。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}")]
    Task<Contact> GetContactAsync(string inboxIdentifier, string contactIdentifier, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 客户端 API：更新联系人。
    /// </summary>
    /// <param name="inboxIdentifier">收件箱标识符。</param>
    /// <param name="contactIdentifier">联系人标识符。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Patch("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}")]
    Task<ContactRecord> UpdateContactAsync(string inboxIdentifier, string contactIdentifier, [Body] ContactCreateUpdatePayload payload, CancellationToken cancellationToken = default);
}
