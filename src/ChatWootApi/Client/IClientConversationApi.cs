using Refit;

namespace ChatWootApi.Client;

public interface IClientConversationApi
{
    [Post("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}/conversations")]
    Task<Conversation> CreateConversationAsync(string inboxIdentifier, string contactIdentifier, [Body] ConversationCreatePayload payload, CancellationToken cancellationToken = default);

    [Get("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}/conversations")]
    Task<IReadOnlyList<Conversation>> ListConversationsAsync(string inboxIdentifier, string contactIdentifier, CancellationToken cancellationToken = default);

    [Get("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}/conversations/{conversationId}")]
    Task<Conversation> GetConversationAsync(string inboxIdentifier, string contactIdentifier, long conversationId, CancellationToken cancellationToken = default);

    [Post("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}/conversations/{conversationId}/toggle_status")]
    Task<Conversation> ToggleConversationStatusAsync(string inboxIdentifier, string contactIdentifier, long conversationId, CancellationToken cancellationToken = default);

    [Post("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}/conversations/{conversationId}/toggle_typing")]
    Task ToggleTypingAsync(string inboxIdentifier, string contactIdentifier, long conversationId, CancellationToken cancellationToken = default);

    [Post("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}/conversations/{conversationId}/update_last_seen")]
    Task UpdateLastSeenAsync(string inboxIdentifier, string contactIdentifier, long conversationId, CancellationToken cancellationToken = default);
}
