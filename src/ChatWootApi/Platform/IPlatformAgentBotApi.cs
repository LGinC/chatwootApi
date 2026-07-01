using Refit;

namespace ChatWootApi.Platform;

public interface IPlatformAgentBotApi
{
    [Get("/platform/api/v1/agent_bots")]
    Task<IReadOnlyList<AgentBot>> ListAgentBotsAsync(CancellationToken cancellationToken = default);

    [Post("/platform/api/v1/agent_bots")]
    Task<AgentBot> CreateAgentBotAsync([Body] AgentBotCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Get("/platform/api/v1/agent_bots/{id}")]
    Task<AgentBot> GetAgentBotAsync(long id, CancellationToken cancellationToken = default);

    [Patch("/platform/api/v1/agent_bots/{id}")]
    Task<AgentBot> UpdateAgentBotAsync(long id, [Body] AgentBotCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Delete("/platform/api/v1/agent_bots/{id}")]
    Task DeleteAgentBotAsync(long id, CancellationToken cancellationToken = default);
}
