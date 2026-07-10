using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：自定义属性创建更新载荷。
/// </summary>
public sealed record CustomAttributeCreateUpdatePayload : JsonExtensionDataPayload
{
    /// <summary>
    /// 属性显示名称
    /// </summary>
    [JsonPropertyName("attribute_display_name")]
    public string? AttributeDisplayName { get; set; }

    /// <summary>
    /// 属性显示类型（文本- 0、数字- 1、货币- 2、百分比- 3、链接- 4、日期- 5、列表- 6、复选框- 7）
    /// </summary>
    [JsonPropertyName("attribute_display_type")]
    public long? AttributeDisplayType { get; set; }

    /// <summary>
    /// 属性说明
    /// </summary>
    [JsonPropertyName("attribute_description")]
    public string? AttributeDescription { get; set; }

    /// <summary>
    /// 属性唯一键值
    /// </summary>
    [JsonPropertyName("attribute_key")]
    public string? AttributeKey { get; set; }

    /// <summary>
    /// 属性值
    /// </summary>
    [JsonPropertyName("attribute_values")]
    public IReadOnlyList<string?>? AttributeValues { get; set; }

    /// <summary>
    /// 属性类型(conversation_attribute- 0, contact_attribute- 1)
    /// </summary>
    [JsonPropertyName("attribute_model")]
    public long? AttributeModel { get; set; }

    /// <summary>
    /// 正则表达式模式（仅适用于类型文本）。正则表达式模式用于验证属性值。
    /// </summary>
    [JsonPropertyName("regex_pattern")]
    public string? RegexPattern { get; set; }

    /// <summary>
    /// 正则表达式提示消息（仅适用于类型文本）。当正则表达式模式不匹配时，会显示提示消息。
    /// </summary>
    [JsonPropertyName("regex_cue")]
    public string? RegexCue { get; set; }
}
