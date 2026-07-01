using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record PublicMessageUpdatePayload
{
    [JsonPropertyName("submitted_values")]
    public IDictionary<string, JsonElement>? SubmittedValues { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
