using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Platform;

public sealed record UserCreateUpdatePayload
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [JsonPropertyName("password")]
    public string? Password { get; init; }

    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }
}
