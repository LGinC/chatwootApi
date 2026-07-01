using Refit;

namespace ChatWootApi.Platform;

public interface IPlatformAccountUserApi
{
    [Get("/platform/api/v1/accounts/{accountId}/account_users")]
    Task<IReadOnlyList<AccountUser>> ListAccountUsersAsync(long accountId, CancellationToken cancellationToken = default);

    [Post("/platform/api/v1/accounts/{accountId}/account_users")]
    Task<AccountUser> CreateAccountUserAsync(long accountId, [Body] AccountUserCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Delete("/platform/api/v1/accounts/{accountId}/account_users")]
    Task DeleteAccountUserAsync(long accountId, CancellationToken cancellationToken = default);
}
