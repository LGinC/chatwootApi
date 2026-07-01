using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationAccountAgentBotsApi
{
    [Get("/api/v1/accounts/{accountId}/agent_bots")]
    Task<IReadOnlyList<AgentBot>> ListAllAccountAgentBotsAsync(long accountId, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/agent_bots")]
    Task<AgentBot> CreateAnAccountAgentBotAsync(long accountId, [Body] AgentBotCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Get("/api/v1/accounts/{accountId}/agent_bots/{id}")]
    Task<AgentBot> GetDetailsOfASingleAccountAgentBotAsync(long accountId, long id, CancellationToken cancellationToken = default);

    [Patch("/api/v1/accounts/{accountId}/agent_bots/{id}")]
    Task<AgentBot> UpdateAnAccountAgentBotAsync(long accountId, long id, [Body] AgentBotCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Delete("/api/v1/accounts/{accountId}/agent_bots/{id}")]
    Task DeleteAnAccountAgentBotAsync(long accountId, long id, CancellationToken cancellationToken = default);
}
