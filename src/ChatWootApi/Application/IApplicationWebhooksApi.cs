using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationWebhooksApi
{
    [Get("/api/v1/accounts/{accountId}/webhooks")]
    Task<IReadOnlyList<Webhook>> ListAllWebhooksAsync(long accountId, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/webhooks")]
    Task<Webhook> CreateAWebhookAsync(long accountId, [Body] WebhookCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Patch("/api/v1/accounts/{accountId}/webhooks/{webhookId}")]
    Task<Webhook> UpdateAWebhookAsync(long accountId, long webhookId, [Body] WebhookCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Delete("/api/v1/accounts/{accountId}/webhooks/{webhookId}")]
    Task DeleteAWebhookAsync(long accountId, long webhookId, CancellationToken cancellationToken = default);
}
