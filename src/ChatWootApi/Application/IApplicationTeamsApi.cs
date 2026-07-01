using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationTeamsApi
{
    [Get("/api/v1/accounts/{accountId}/teams")]
    Task<IReadOnlyList<Team>> ListAllTeamsAsync(long accountId, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/teams")]
    Task<Team> CreateATeamAsync(long accountId, [Body] TeamCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Get("/api/v1/accounts/{accountId}/teams/{teamId}")]
    Task<Team> GetDetailsOfASingleTeamAsync(long accountId, long teamId, CancellationToken cancellationToken = default);

    [Patch("/api/v1/accounts/{accountId}/teams/{teamId}")]
    Task<Team> UpdateATeamAsync(long accountId, long teamId, [Body] TeamCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Delete("/api/v1/accounts/{accountId}/teams/{teamId}")]
    Task DeleteATeamAsync(long accountId, long teamId, CancellationToken cancellationToken = default);

    [Get("/api/v1/accounts/{accountId}/teams/{teamId}/team_members")]
    Task<IReadOnlyList<Agent>> GetTeamMembersAsync(long accountId, long teamId, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/teams/{teamId}/team_members")]
    Task<IReadOnlyList<Agent>> AddNewAgentToTeamAsync(long accountId, long teamId, [Body] JsonElement payload, CancellationToken cancellationToken = default);

    [Patch("/api/v1/accounts/{accountId}/teams/{teamId}/team_members")]
    Task<IReadOnlyList<Agent>> UpdateAgentsInTeamAsync(long accountId, long teamId, [Body] JsonElement payload, CancellationToken cancellationToken = default);

    [Delete("/api/v1/accounts/{accountId}/teams/{teamId}/team_members")]
    Task DeleteAgentInTeamAsync(long accountId, long teamId, [Body] JsonElement payload, CancellationToken cancellationToken = default);
}
