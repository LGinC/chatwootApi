using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record ConversationStatusToggle
{
    [JsonPropertyName("meta")]
    public IDictionary<string, JsonElement>? Meta { get; init; }

    [JsonPropertyName("payload")]
    public IDictionary<string, JsonElement>? Payload { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
