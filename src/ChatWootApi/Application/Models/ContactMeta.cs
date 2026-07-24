using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：联系人元数据
/// </summary>
public sealed record ContactMeta
{
    /// <summary>
    /// 联系人总数
    /// </summary>
    [JsonPropertyName("count")]
    public int? Count { get; init; }

    /// <summary>
    /// 当前页码
    /// </summary>
    [JsonPropertyName("current_page")]
    public string? CurrentPage { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
