using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：坐席机器人
/// </summary>
public sealed record AgentBot
{
    /// <summary>
    /// ID
    /// </summary>
    [JsonPropertyName("id")]
    public decimal? Id { get; init; }

    /// <summary>
    /// 名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Description
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// 缩略图
    /// </summary>
    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; init; }

    /// <summary>
    /// 外发URL
    /// </summary>
    [JsonPropertyName("outgoing_url")]
    public string? OutgoingUrl { get; init; }

    /// <summary>
    /// 机器人类型
    /// </summary>
    [JsonPropertyName("bot_type")]
    public string? BotType { get; init; }

    /// <summary>
    /// 机器人配置
    /// </summary>
    [JsonPropertyName("bot_config")]
    public IDictionary<string, JsonElement>? BotConfig { get; init; }

    /// <summary>
    /// 账号ID
    /// </summary>
    [JsonPropertyName("account_id")]
    public decimal? AccountId { get; init; }

    /// <summary>
    /// 访问令牌
    /// </summary>
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; init; }

    /// <summary>
    /// System机器人
    /// </summary>
    [JsonPropertyName("system_bot")]
    public bool? SystemBot { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
