using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationMessagesApi
{
    [Get("/api/v1/accounts/{accountId}/conversations/{conversationId}/messages")]
    Task<JsonElement> ListAllMessagesAsync(long accountId, long conversationId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/conversations/{conversationId}/messages")]
    Task<JsonElement> CreateANewMessageInAConversationAsync(long accountId, long conversationId, [Body] ConversationMessageCreatePayload payload, CancellationToken cancellationToken = default);

    [Delete("/api/v1/accounts/{accountId}/conversations/{conversationId}/messages/{messageId}")]
    Task DeleteAMessageAsync(long accountId, long conversationId, long messageId, CancellationToken cancellationToken = default);
}
