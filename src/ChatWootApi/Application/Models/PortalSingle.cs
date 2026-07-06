using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：门户单个。
/// </summary>
public sealed record PortalSingle
{
    /// <summary>
    /// 载荷。
    /// </summary>
    [JsonPropertyName("payload")]
    public PortalItem? Payload { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
