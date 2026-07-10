using System.Text.Json.Serialization;

namespace ChatWootApi.Platform.Models;

/// <summary>
/// Chatwoot 平台模型：坐席机器人创建更新载荷
/// </summary>
public sealed record AgentBotCreateUpdatePayload
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
    /// 账号ID
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; set; }

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
}
