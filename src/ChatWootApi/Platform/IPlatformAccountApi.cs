using Refit;

namespace ChatWootApi.Platform;

public interface IPlatformAccountApi
{
    [Post("/platform/api/v1/accounts")]
    Task<PlatformAccount> CreateAccountAsync([Body] AccountCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Get("/platform/api/v1/accounts/{accountId}")]
    Task<PlatformAccount> GetAccountAsync(long accountId, CancellationToken cancellationToken = default);

    [Patch("/platform/api/v1/accounts/{accountId}")]
    Task<PlatformAccount> UpdateAccountAsync(long accountId, [Body] AccountCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Delete("/platform/api/v1/accounts/{accountId}")]
    Task DeleteAccountAsync(long accountId, CancellationToken cancellationToken = default);
}
