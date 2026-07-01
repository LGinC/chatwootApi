using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationContactLabelsApi
{
    [Get("/api/v1/accounts/{accountId}/contacts/{id}/labels")]
    Task<ContactLabels> ListAllLabelsOfAContactAsync(long accountId, long id, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/contacts/{id}/labels")]
    Task<ContactLabels> ContactAddLabelsAsync(long accountId, long id, [Body] JsonElement payload, CancellationToken cancellationToken = default);
}
