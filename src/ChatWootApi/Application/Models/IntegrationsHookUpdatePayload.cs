using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record IntegrationsHookUpdatePayload
{
    [JsonPropertyName("status")]
    public long? Status { get; init; }

    [JsonPropertyName("settings")]
    public IDictionary<string, JsonElement>? Settings { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
