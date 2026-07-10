using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：坐席机器人创建更新载荷。
/// </summary>
public sealed record AgentBotCreateUpdatePayload : JsonExtensionDataPayload
{
    /// <summary>
    /// 代理机器人的名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 代理机器人的描述
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// 机器人的 Webhook URL
    /// </summary>
    [JsonPropertyName("outgoing_url")]
    public string? OutgoingUrl { get; set; }

    /// <summary>
    /// 使用头像图像二进制文件发送表单数据或使用 avatar_url
    /// </summary>
    [JsonPropertyName("avatar")]
    public string? Avatar { get; set; }

    /// <summary>
    /// 代理机器人头像的 jpeg、png 文件的 url
    /// </summary>
    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; set; }

    /// <summary>
    /// 机器人的类型（0 表示 webhook）
    /// </summary>
    [JsonPropertyName("bot_type")]
    public long? BotType { get; set; }

    /// <summary>
    /// 机器人的配置
    /// </summary>
    [JsonPropertyName("bot_config")]
    public IDictionary<string, object>? BotConfig { get; set; }
}
