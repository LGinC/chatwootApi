using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationProfileApi
{
    [Get("/api/v1/profile")]
    Task<User> FetchProfileAsync(CancellationToken cancellationToken = default);

    [Put("/api/v1/profile")]
    Task<User> UpdateProfileAsync([Body] JsonElement payload, CancellationToken cancellationToken = default);
}
