using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record BadRequestError
{
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("errors")]
    public IReadOnlyList<RequestError>? Errors { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
