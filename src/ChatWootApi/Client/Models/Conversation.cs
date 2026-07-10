using System.Text.Json.Serialization;

namespace ChatWootApi.Client.Models;

/// <summary>
/// Chatwoot 客户端模型：会话
/// </summary>
public sealed record Conversation
{
    /// <summary>
    /// 对话ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 对话的 UUID
    /// </summary>
    [JsonPropertyName("uuid")]
    public string? Uuid { get; init; }

    /// <summary>
    /// 收件箱 ID
    /// </summary>
    [JsonPropertyName("inbox_id")]
    public long? InboxId { get; init; }

    /// <summary>
    /// 联系人的最后活动时间
    /// </summary>
    [JsonPropertyName("contact_last_seen_at")]
    public long? ContactLastSeenAt { get; init; }

    /// <summary>
    /// 对话状态
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// 代理的最后一次活动
    /// </summary>
    [JsonPropertyName("agent_last_seen_at")]
    public long? AgentLastSeenAt { get; init; }

    /// <summary>
    /// 消息
    /// </summary>
    [JsonPropertyName("messages")]
    public IReadOnlyList<Message>? Messages { get; init; }

    /// <summary>
    /// 联系人
    /// </summary>
    [JsonPropertyName("contact")]
    public ContactRecord? Contact { get; init; }
}
