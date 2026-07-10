using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：自定义筛选器创建更新载荷。
/// </summary>
public sealed record CustomFilterCreateUpdatePayload
{
    /// <summary>
    /// 自定义过滤器的名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 关于自定义过滤器的说明
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// 需要保存为自定义过滤器的查询
    /// </summary>
    [JsonPropertyName("query")]
    public IDictionary<string, object>? Query { get; set; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object>? ExtensionData { get; set; }
}
