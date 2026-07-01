using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record AccountUserCreateUpdatePayload
{
    [JsonPropertyName("user_id")]
    public long? UserId { get; init; }

    [JsonPropertyName("role")]
    public string? Role { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
