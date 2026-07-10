using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：标签创建更新载荷。
/// </summary>
public sealed record LabelCreateUpdatePayload
{
    /// <summary>
    /// 标签标题
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// 标签的简短描述
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// 标签的十六进制颜色代码
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color { get; set; }

    /// <summary>
    /// 标签是否应出现在侧边栏中
    /// </summary>
    [JsonPropertyName("show_on_sidebar")]
    public bool? ShowOnSidebar { get; set; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object>? ExtensionData { get; set; }
}
