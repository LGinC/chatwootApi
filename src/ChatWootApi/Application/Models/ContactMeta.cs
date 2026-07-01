using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record ContactMeta
{
    [JsonPropertyName("count")]
    public long? Count { get; init; }

    [JsonPropertyName("current_page")]
    public string? CurrentPage { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
