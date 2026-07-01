using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record CannedResponseCreateUpdatePayload
{
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    [JsonPropertyName("short_code")]
    public string? ShortCode { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
