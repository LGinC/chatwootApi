using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationIntegrationsApi
{
    [Get("/api/v1/accounts/{accountId}/integrations/apps")]
    Task<JsonElement> GetDetailsOfAllIntegrationsAsync(long accountId, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/integrations/hooks")]
    Task<IntegrationsHook> CreateAnIntegrationHookAsync(long accountId, [Body] IntegrationsHookCreatePayload payload, CancellationToken cancellationToken = default);

    [Patch("/api/v1/accounts/{accountId}/integrations/hooks/{hookId}")]
    Task<IntegrationsHook> UpdateAnIntegrationsHookAsync(long accountId, long hookId, [Body] IntegrationsHookUpdatePayload payload, CancellationToken cancellationToken = default);

    [Delete("/api/v1/accounts/{accountId}/integrations/hooks/{hookId}")]
    Task DeleteAnIntegrationHookAsync(long accountId, long hookId, CancellationToken cancellationToken = default);
}
