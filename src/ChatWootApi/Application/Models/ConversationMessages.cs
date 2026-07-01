using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record ConversationMessages
{
    [JsonPropertyName("meta")]
    public ConversationMeta? Meta { get; init; }

    [JsonPropertyName("payload")]
    public IReadOnlyList<MessageDetailed>? Payload { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
