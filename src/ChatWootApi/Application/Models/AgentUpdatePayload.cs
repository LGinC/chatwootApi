using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：坐席更新载荷。
/// </summary>
public sealed record AgentUpdatePayload
{
    /// <summary>
    /// 角色。
    /// </summary>
    [JsonPropertyName("role")]
    public string? Role { get; init; }

    /// <summary>
    /// 可用状态。
    /// </summary>
    [JsonPropertyName("availability")]
    public string? Availability { get; init; }

    /// <summary>
    /// AutoOffline。
    /// </summary>
    [JsonPropertyName("auto_offline")]
    public bool? AutoOffline { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
