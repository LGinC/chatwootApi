using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationConversationsApi
{
    [Get("/api/v1/accounts/{accountId}/conversations/meta")]
    Task<JsonElement> ConversationListMetaAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    [Get("/api/v1/accounts/{accountId}/conversations")]
    Task<ConversationList> ConversationListAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/conversations")]
    Task<JsonElement> NewConversationAsync(long accountId, [Body] ConversationCreatePayload payload, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/conversations/filter")]
    Task<ConversationList> ConversationFilterAsync(long accountId, [Body] JsonElement payload, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    [Get("/api/v1/accounts/{accountId}/conversations/{conversationId}")]
    Task<ConversationShow> GetDetailsOfAConversationAsync(long accountId, long conversationId, CancellationToken cancellationToken = default);

    [Patch("/api/v1/accounts/{accountId}/conversations/{conversationId}")]
    Task<Conversation> UpdateConversationAsync(long accountId, long conversationId, [Body] JsonElement payload, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/conversations/{conversationId}/toggle_status")]
    Task<JsonElement> ToggleStatusOfAConversationAsync(long accountId, long conversationId, [Body] JsonElement payload, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/conversations/{conversationId}/toggle_priority")]
    Task TogglePriorityOfAConversationAsync(long accountId, long conversationId, [Body] JsonElement payload, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/conversations/{conversationId}/toggle_typing_status")]
    Task ToggleTypingStatusOfAConversationAsync(long accountId, long conversationId, [Body] JsonElement payload, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/conversations/{conversationId}/custom_attributes")]
    Task<JsonElement> UpdateCustomAttributesOfAConversationAsync(long accountId, long conversationId, [Body] JsonElement payload, CancellationToken cancellationToken = default);

    [Get("/api/v1/accounts/{accountId}/conversations/{conversationId}/labels")]
    Task<ConversationLabels> ListAllLabelsOfAConversationAsync(long accountId, long conversationId, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/conversations/{conversationId}/labels")]
    Task<ConversationLabels> ConversationAddLabelsAsync(long accountId, long conversationId, [Body] JsonElement payload, CancellationToken cancellationToken = default);

    [Get("/api/v1/accounts/{accountId}/conversations/{conversationId}/reporting_events")]
    Task<IReadOnlyList<ReportingEvent>> GetConversationReportingEventsAsync(long accountId, long conversationId, CancellationToken cancellationToken = default);
}
