using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record Team
{
    [JsonPropertyName("id")]
    public decimal? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("allow_auto_assign")]
    public bool? AllowAutoAssign { get; init; }

    [JsonPropertyName("account_id")]
    public decimal? AccountId { get; init; }

    [JsonPropertyName("is_member")]
    public bool? IsMember { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
