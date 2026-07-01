using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record ReportingEventMeta
{
    [JsonPropertyName("count")]
    public long? Count { get; init; }

    [JsonPropertyName("current_page")]
    public long? CurrentPage { get; init; }

    [JsonPropertyName("total_pages")]
    public long? TotalPages { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
