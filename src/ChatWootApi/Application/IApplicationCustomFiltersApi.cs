using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationCustomFiltersApi
{
    [Get("/api/v1/accounts/{accountId}/custom_filters")]
    Task<IReadOnlyList<CustomFilter>> ListAllFiltersAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/custom_filters")]
    Task<CustomFilter> CreateACustomFilterAsync(long accountId, [Body] CustomFilterCreateUpdatePayload payload, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    [Get("/api/v1/accounts/{accountId}/custom_filters/{customFilterId}")]
    Task<CustomFilter> GetDetailsOfASingleCustomFilterAsync(long accountId, long customFilterId, CancellationToken cancellationToken = default);

    [Patch("/api/v1/accounts/{accountId}/custom_filters/{customFilterId}")]
    Task<CustomFilter> UpdateACustomFilterAsync(long accountId, long customFilterId, [Body] CustomFilterCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Delete("/api/v1/accounts/{accountId}/custom_filters/{customFilterId}")]
    Task DeleteACustomFilterAsync(long accountId, long customFilterId, CancellationToken cancellationToken = default);
}
