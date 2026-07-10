using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：自定义属性
/// </summary>
public sealed record CustomAttribute
{
    /// <summary>
    /// 标识符
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 属性显示名称
    /// </summary>
    [JsonPropertyName("attribute_display_name")]
    public string? AttributeDisplayName { get; init; }

    /// <summary>
    /// 属性显示类型（文本、数字、货币、百分比、链接、日期、列表、复选框）
    /// </summary>
    [JsonPropertyName("attribute_display_type")]
    public string? AttributeDisplayType { get; init; }

    /// <summary>
    /// 属性说明
    /// </summary>
    [JsonPropertyName("attribute_description")]
    public string? AttributeDescription { get; init; }

    /// <summary>
    /// 属性唯一键值
    /// </summary>
    [JsonPropertyName("attribute_key")]
    public string? AttributeKey { get; init; }

    /// <summary>
    /// 正则表达式模式
    /// </summary>
    [JsonPropertyName("regex_pattern")]
    public string? RegexPattern { get; init; }

    /// <summary>
    /// 正则表达式提示
    /// </summary>
    [JsonPropertyName("regex_cue")]
    public string? RegexCue { get; init; }

    /// <summary>
    /// 属性值
    /// </summary>
    [JsonPropertyName("attribute_values")]
    public string? AttributeValues { get; init; }

    /// <summary>
    /// 属性类型(conversation_attribute/contact_attribute)
    /// </summary>
    [JsonPropertyName("attribute_model")]
    public string? AttributeModel { get; init; }

    /// <summary>
    /// 属性默认值
    /// </summary>
    [JsonPropertyName("default_value")]
    public string? DefaultValue { get; init; }

    /// <summary>
    /// 创建自定义属性的日期和时间
    /// </summary>
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; init; }

    /// <summary>
    /// 更新自定义属性的日期和时间
    /// </summary>
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
