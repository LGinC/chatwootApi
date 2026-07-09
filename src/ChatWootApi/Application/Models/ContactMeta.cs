using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：联系人元数据
/// </summary>
public sealed record ContactMeta
{
    /// <summary>
    /// 数量
    /// </summary>
    [JsonPropertyName("count")]
    public long? Count { get; init; }

    /// <summary>
    /// 当前Page
    /// </summary>
    [JsonPropertyName("current_page")]
    public string? CurrentPage { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
