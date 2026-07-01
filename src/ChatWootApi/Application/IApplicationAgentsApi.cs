using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationAgentsApi
{
    [Get("/api/v1/accounts/{accountId}/agents")]
    Task<IReadOnlyList<Agent>> GetAccountAgentsAsync(long accountId, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/agents")]
    Task<Agent> AddNewAgentToAccountAsync(long accountId, [Body] AgentCreatePayload payload, CancellationToken cancellationToken = default);

    [Patch("/api/v1/accounts/{accountId}/agents/{id}")]
    Task<Agent> UpdateAgentInAccountAsync(long accountId, long id, [Body] AgentUpdatePayload payload, CancellationToken cancellationToken = default);

    [Delete("/api/v1/accounts/{accountId}/agents/{id}")]
    Task DeleteAgentFromAccountAsync(long accountId, long id, CancellationToken cancellationToken = default);
}
