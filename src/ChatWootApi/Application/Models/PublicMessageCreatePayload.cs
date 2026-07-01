using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record PublicMessageCreatePayload
{
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    [JsonPropertyName("echo_id")]
    public string? EchoId { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
