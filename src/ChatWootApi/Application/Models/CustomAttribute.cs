using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record CustomAttribute
{
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonPropertyName("attribute_display_name")]
    public string? AttributeDisplayName { get; init; }

    [JsonPropertyName("attribute_display_type")]
    public string? AttributeDisplayType { get; init; }

    [JsonPropertyName("attribute_description")]
    public string? AttributeDescription { get; init; }

    [JsonPropertyName("attribute_key")]
    public string? AttributeKey { get; init; }

    [JsonPropertyName("regex_pattern")]
    public string? RegexPattern { get; init; }

    [JsonPropertyName("regex_cue")]
    public string? RegexCue { get; init; }

    [JsonPropertyName("attribute_values")]
    public string? AttributeValues { get; init; }

    [JsonPropertyName("attribute_model")]
    public string? AttributeModel { get; init; }

    [JsonPropertyName("default_value")]
    public string? DefaultValue { get; init; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
