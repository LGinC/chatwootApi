using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record ReportingEventsListResponse
{
    [JsonPropertyName("meta")]
    public ReportingEventMeta? Meta { get; init; }

    [JsonPropertyName("payload")]
    public IReadOnlyList<ReportingEvent>? Payload { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
