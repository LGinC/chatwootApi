using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：自定义属性。
/// </summary>
public sealed record CustomAttribute
{
    /// <summary>
    /// ID。
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 属性显示名称。
    /// </summary>
    [JsonPropertyName("attribute_display_name")]
    public string? AttributeDisplayName { get; init; }

    /// <summary>
    /// 属性显示类型。
    /// </summary>
    [JsonPropertyName("attribute_display_type")]
    public string? AttributeDisplayType { get; init; }

    /// <summary>
    /// 属性Description。
    /// </summary>
    [JsonPropertyName("attribute_description")]
    public string? AttributeDescription { get; init; }

    /// <summary>
    /// 属性Key。
    /// </summary>
    [JsonPropertyName("attribute_key")]
    public string? AttributeKey { get; init; }

    /// <summary>
    /// RegexPattern。
    /// </summary>
    [JsonPropertyName("regex_pattern")]
    public string? RegexPattern { get; init; }

    /// <summary>
    /// RegexCue。
    /// </summary>
    [JsonPropertyName("regex_cue")]
    public string? RegexCue { get; init; }

    /// <summary>
    /// 属性值。
    /// </summary>
    [JsonPropertyName("attribute_values")]
    public string? AttributeValues { get; init; }

    /// <summary>
    /// 属性Model。
    /// </summary>
    [JsonPropertyName("attribute_model")]
    public string? AttributeModel { get; init; }

    /// <summary>
    /// Default值。
    /// </summary>
    [JsonPropertyName("default_value")]
    public string? DefaultValue { get; init; }

    /// <summary>
    /// 创建时间。
    /// </summary>
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; init; }

    /// <summary>
    /// 更新时间。
    /// </summary>
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
