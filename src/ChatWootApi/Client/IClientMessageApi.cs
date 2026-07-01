using Refit;

namespace ChatWootApi.Client;

public interface IClientMessageApi
{
    [Post("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}/conversations/{conversationId}/messages")]
    Task<Message> CreateMessageAsync(string inboxIdentifier, string contactIdentifier, long conversationId, [Body] MessageCreatePayload payload, CancellationToken cancellationToken = default);

    [Get("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}/conversations/{conversationId}/messages")]
    Task<IReadOnlyList<Message>> ListMessagesAsync(string inboxIdentifier, string contactIdentifier, long conversationId, CancellationToken cancellationToken = default);

    [Patch("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}/conversations/{conversationId}/messages/{messageId}")]
    Task<Message> UpdateMessageAsync(string inboxIdentifier, string contactIdentifier, long conversationId, long messageId, [Body] MessageUpdatePayload payload, CancellationToken cancellationToken = default);
}
