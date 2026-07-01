using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record ContactInbox
{
    [JsonPropertyName("source_id")]
    public string? SourceId { get; init; }

    [JsonPropertyName("inbox")]
    public IDictionary<string, JsonElement>? Inbox { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
