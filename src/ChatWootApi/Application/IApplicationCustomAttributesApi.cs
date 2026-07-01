using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationCustomAttributesApi
{
    [Get("/api/v1/accounts/{accountId}/custom_attribute_definitions")]
    Task<IReadOnlyList<CustomAttribute>> GetAccountCustomAttributeAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/custom_attribute_definitions")]
    Task<CustomAttribute> AddNewCustomAttributeToAccountAsync(long accountId, [Body] CustomAttributeCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Get("/api/v1/accounts/{accountId}/custom_attribute_definitions/{id}")]
    Task<CustomAttribute> GetDetailsOfASingleCustomAttributeAsync(long accountId, long id, CancellationToken cancellationToken = default);

    [Patch("/api/v1/accounts/{accountId}/custom_attribute_definitions/{id}")]
    Task<CustomAttribute> UpdateCustomAttributeInAccountAsync(long accountId, long id, [Body] CustomAttributeCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Delete("/api/v1/accounts/{accountId}/custom_attribute_definitions/{id}")]
    Task DeleteCustomAttributeFromAccountAsync(long accountId, long id, CancellationToken cancellationToken = default);
}
