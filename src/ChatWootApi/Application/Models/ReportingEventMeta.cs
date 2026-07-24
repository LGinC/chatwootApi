using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：Reporting事件元数据
/// </summary>
public sealed record ReportingEventMeta
{
    /// <summary>
    /// 报告事件总数
    /// </summary>
    [JsonPropertyName("count")]
    public int? Count { get; init; }

    /// <summary>
    /// 当前页码
    /// </summary>
    [JsonPropertyName("current_page")]
    public int? CurrentPage { get; init; }

    /// <summary>
    /// 总页数
    /// </summary>
    [JsonPropertyName("total_pages")]
    public int? TotalPages { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
