using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record Contact
{
    [JsonPropertyName("payload")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Payload { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
