using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：坐席机器人创建更新载荷。
/// </summary>
public sealed record AgentBotCreateUpdatePayload
{
    /// <summary>
    /// 名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Description。
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// 外发URL。
    /// </summary>
    [JsonPropertyName("outgoing_url")]
    public string? OutgoingUrl { get; set; }

    /// <summary>
    /// 头像。
    /// </summary>
    [JsonPropertyName("avatar")]
    public string? Avatar { get; set; }

    /// <summary>
    /// 头像URL。
    /// </summary>
    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; set; }

    /// <summary>
    /// 机器人类型。
    /// </summary>
    [JsonPropertyName("bot_type")]
    public long? BotType { get; set; }

    /// <summary>
    /// 机器人配置。
    /// </summary>
    [JsonPropertyName("bot_config")]
    public IDictionary<string, object>? BotConfig { get; set; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object>? ExtensionData { get; set; }
}
