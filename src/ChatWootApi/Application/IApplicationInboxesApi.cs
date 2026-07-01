using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationInboxesApi
{
    [Get("/api/v1/accounts/{accountId}/inboxes")]
    Task<JsonElement> ListAllInboxesAsync(long accountId, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/inboxes")]
    Task<Inbox> InboxCreationAsync(long accountId, [Body] InboxCreatePayload payload, CancellationToken cancellationToken = default);

    [Get("/api/v1/accounts/{accountId}/inboxes/{id}")]
    Task<Inbox> GetInboxAsync(long accountId, long id, CancellationToken cancellationToken = default);

    [Patch("/api/v1/accounts/{accountId}/inboxes/{id}")]
    Task<Inbox> UpdateInboxAsync(long accountId, long id, [Body] InboxUpdatePayload payload, CancellationToken cancellationToken = default);

    [Get("/api/v1/accounts/{accountId}/inboxes/{id}/agent_bot")]
    Task GetInboxAgentBotAsync(long accountId, long id, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/inboxes/{id}/set_agent_bot")]
    Task UpdateAgentBotAsync(long accountId, long id, [Body] JsonElement payload, CancellationToken cancellationToken = default);

    [Get("/api/v1/accounts/{accountId}/inbox_members/{inboxId}")]
    Task<JsonElement> GetInboxMembersAsync(long accountId, long inboxId, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/inbox_members")]
    Task<JsonElement> AddNewAgentToInboxAsync(long accountId, [Body] JsonElement payload, CancellationToken cancellationToken = default);

    [Patch("/api/v1/accounts/{accountId}/inbox_members")]
    Task<JsonElement> UpdateAgentsInInboxAsync(long accountId, [Body] JsonElement payload, CancellationToken cancellationToken = default);

    [Delete("/api/v1/accounts/{accountId}/inbox_members")]
    Task DeleteAgentInInboxAsync(long accountId, [Body] JsonElement payload, CancellationToken cancellationToken = default);
}
