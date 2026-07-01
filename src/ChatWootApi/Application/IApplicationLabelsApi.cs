using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationLabelsApi
{
    [Get("/api/v1/accounts/{accountId}/labels")]
    Task<JsonElement> ListAllLabelsAsync(long accountId, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/labels")]
    Task<Label> CreateALabelAsync(long accountId, [Body] LabelCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Get("/api/v1/accounts/{accountId}/labels/{id}")]
    Task<Label> GetDetailsOfASingleLabelAsync(long accountId, long id, CancellationToken cancellationToken = default);

    [Patch("/api/v1/accounts/{accountId}/labels/{id}")]
    Task<Label> UpdateALabelAsync(long accountId, long id, [Body] LabelCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Delete("/api/v1/accounts/{accountId}/labels/{id}")]
    Task DeleteALabelAsync(long accountId, long id, CancellationToken cancellationToken = default);
}
