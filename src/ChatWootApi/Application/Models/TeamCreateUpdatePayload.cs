using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：团队创建更新载荷。
/// </summary>
public sealed record TeamCreateUpdatePayload
{
    /// <summary>
    /// 团队名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 团队的描述
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// 如果开启此设置，系统在将对话分配给团队的同时，会自动将对话分配给团队中的座席
    /// </summary>
    [JsonPropertyName("allow_auto_assign")]
    public bool? AllowAutoAssign { get; set; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object>? ExtensionData { get; set; }
}
