using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record CustomAttributeCreateUpdatePayload
{
    [JsonPropertyName("attribute_display_name")]
    public string? AttributeDisplayName { get; init; }

    [JsonPropertyName("attribute_display_type")]
    public long? AttributeDisplayType { get; init; }

    [JsonPropertyName("attribute_description")]
    public string? AttributeDescription { get; init; }

    [JsonPropertyName("attribute_key")]
    public string? AttributeKey { get; init; }

    [JsonPropertyName("attribute_values")]
    public IReadOnlyList<string?>? AttributeValues { get; init; }

    [JsonPropertyName("attribute_model")]
    public long? AttributeModel { get; init; }

    [JsonPropertyName("regex_pattern")]
    public string? RegexPattern { get; init; }

    [JsonPropertyName("regex_cue")]
    public string? RegexCue { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
