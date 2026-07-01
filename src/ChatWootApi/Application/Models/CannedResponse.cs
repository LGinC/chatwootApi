using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record CannedResponse
{
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    [JsonPropertyName("short_code")]
    public string? ShortCode { get; init; }

    [JsonPropertyName("content")]
    public string? Content { get; init; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
