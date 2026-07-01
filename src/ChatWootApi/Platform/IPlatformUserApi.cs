using Refit;

namespace ChatWootApi.Platform;

public interface IPlatformUserApi
{
    [Post("/platform/api/v1/users")]
    Task<User> CreateUserAsync([Body] UserCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Get("/platform/api/v1/users/{id}")]
    Task<User> GetUserAsync(long id, CancellationToken cancellationToken = default);

    [Patch("/platform/api/v1/users/{id}")]
    Task<User> UpdateUserAsync(long id, [Body] UserCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Delete("/platform/api/v1/users/{id}")]
    Task DeleteUserAsync(long id, CancellationToken cancellationToken = default);

    [Get("/platform/api/v1/users/{id}/login")]
    Task<UserSsoUrl> GetUserSsoUrlAsync(long id, CancellationToken cancellationToken = default);
}
