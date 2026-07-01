using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationCannedResponsesApi
{
    [Get("/api/v1/accounts/{accountId}/canned_responses")]
    Task<IReadOnlyList<CannedResponse>> GetAccountCannedResponseAsync(long accountId, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/canned_responses")]
    Task<CannedResponse> AddNewCannedResponseToAccountAsync(long accountId, [Body] CannedResponseCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Patch("/api/v1/accounts/{accountId}/canned_responses/{id}")]
    Task<CannedResponse> UpdateCannedResponseInAccountAsync(long accountId, long id, [Body] CannedResponseCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Delete("/api/v1/accounts/{accountId}/canned_responses/{id}")]
    Task DeleteCannedResponseFromAccountAsync(long accountId, long id, CancellationToken cancellationToken = default);
}
