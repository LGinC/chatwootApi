using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：坐席创建载荷。
/// </summary>
public sealed record AgentCreatePayload
{
    /// <summary>
    /// 名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 邮箱。
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

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
