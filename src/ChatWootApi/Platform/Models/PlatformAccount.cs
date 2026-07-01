using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Platform;

public sealed record PlatformAccount
{
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
