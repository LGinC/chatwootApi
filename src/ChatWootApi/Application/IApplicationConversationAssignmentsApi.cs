using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationConversationAssignmentsApi
{
    [Post("/api/v1/accounts/{accountId}/conversations/{conversationId}/assignments")]
    Task<User> AssignAConversationAsync(long accountId, long conversationId, [Body] JsonElement payload, CancellationToken cancellationToken = default);
}
