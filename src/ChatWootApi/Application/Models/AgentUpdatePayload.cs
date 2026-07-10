using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：坐席更新载荷。
/// </summary>
public sealed record AgentUpdatePayload
{
    /// <summary>
    /// 无论是管理员还是代理人
    /// </summary>
    [JsonPropertyName("role")]
    public string? Role { get; set; }

    /// <summary>
    /// 代理的已配置可用性。
    /// </summary>
    [JsonPropertyName("availability")]
    public string? Availability { get; set; }

    /// <summary>
    /// 座席离开时是否自动标记为离线。
    /// </summary>
    [JsonPropertyName("auto_offline")]
    public bool? AutoOffline { get; set; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object>? ExtensionData { get; set; }
}
