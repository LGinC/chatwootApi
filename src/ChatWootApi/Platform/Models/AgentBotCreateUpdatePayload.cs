using System.Text.Json.Serialization;

namespace ChatWootApi.Platform;

/// <summary>
/// Chatwoot 平台模型：坐席机器人创建更新载荷。
/// </summary>
public sealed record AgentBotCreateUpdatePayload
{
    /// <summary>
    /// 名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Description。
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// 外发URL。
    /// </summary>
    [JsonPropertyName("outgoing_url")]
    public string? OutgoingUrl { get; init; }

    /// <summary>
    /// 账号ID。
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// 头像。
    /// </summary>
    [JsonPropertyName("avatar")]
    public string? Avatar { get; init; }

    /// <summary>
    /// 头像URL。
    /// </summary>
    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; init; }
}
