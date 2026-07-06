using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：门户。
/// </summary>
public sealed record Portal
{
    /// <summary>
    /// 载荷。
    /// </summary>
    [JsonPropertyName("payload")]
    public IReadOnlyList<PortalItem>? Payload { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
