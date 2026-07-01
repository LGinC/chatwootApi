using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record InboxLabelMatrix
{
    [JsonPropertyName("inboxes")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Inboxes { get; init; }

    [JsonPropertyName("labels")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Labels { get; init; }

    [JsonPropertyName("matrix")]
    public IReadOnlyList<IReadOnlyList<decimal>?>? Matrix { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
