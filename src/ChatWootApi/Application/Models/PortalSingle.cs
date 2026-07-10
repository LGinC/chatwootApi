using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：门户单个
/// </summary>
public sealed record PortalSingle
{
    /// <summary>
    /// 单个门户对象（用于显示/更新端点）
    /// </summary>
    [JsonPropertyName("payload")]
    public PortalItem? Payload { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
