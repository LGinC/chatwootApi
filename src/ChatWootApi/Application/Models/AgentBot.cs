using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：坐席机器人
/// </summary>
public sealed record AgentBot
{
    /// <summary>
    /// 代理机器人的 ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 代理机器人的名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 关于代理机器人的描述
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// 代理机器人的缩略图
    /// </summary>
    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; init; }

    /// <summary>
    /// 机器人的 Webhook URL
    /// </summary>
    [JsonPropertyName("outgoing_url")]
    public string? OutgoingUrl { get; init; }

    /// <summary>
    /// 机器人的类型
    /// </summary>
    [JsonPropertyName("bot_type")]
    public string? BotType { get; init; }

    /// <summary>
    /// 机器人的配置
    /// </summary>
    [JsonPropertyName("bot_config")]
    public IDictionary<string, JsonElement>? BotConfig { get; init; }

    /// <summary>
    /// 帐户 ID（如果是帐户特定机器人）
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// 机器人的访问令牌
    /// </summary>
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; init; }

    /// <summary>
    /// 机器人是否为系统机器人
    /// </summary>
    [JsonPropertyName("system_bot")]
    public bool? SystemBot { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
