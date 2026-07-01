using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record ContactableInboxes
{
    [JsonPropertyName("source_id")]
    public string? SourceId { get; init; }

    [JsonPropertyName("inbox")]
    public Inbox? Inbox { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
