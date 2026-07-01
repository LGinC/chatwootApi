using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationAccountApi
{
    [Get("/api/v1/accounts/{accountId}")]
    Task<AccountShowResponse> GetAccountDetailsAsync(long accountId, CancellationToken cancellationToken = default);

    [Patch("/api/v1/accounts/{accountId}")]
    Task<AccountDetail> UpdateAccountAsync(long accountId, [Body] AccountUpdatePayload payload, CancellationToken cancellationToken = default);
}
