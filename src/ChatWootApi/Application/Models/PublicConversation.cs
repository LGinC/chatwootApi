using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：公开会话
/// </summary>
public sealed record PublicConversation
{
    /// <summary>
    /// 对话 ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 对话的 UUID
    /// </summary>
    [JsonPropertyName("uuid")]
    public string? Uuid { get; init; }

    /// <summary>
    /// 对话的收件箱 ID
    /// </summary>
    [JsonPropertyName("inbox_id")]
    public long? InboxId { get; init; }

    /// <summary>
    /// 联系人最后一次看到对话的时间戳（Unix 时间戳）
    /// </summary>
    [JsonPropertyName("contact_last_seen_at")]
    public long? ContactLastSeenAt { get; init; }

    /// <summary>
    /// 对话状态
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// 代理上次看到对话的时间戳（Unix 时间戳）
    /// </summary>
    [JsonPropertyName("agent_last_seen_at")]
    public long? AgentLastSeenAt { get; init; }

    /// <summary>
    /// 对话中的消息
    /// </summary>
    [JsonPropertyName("messages")]
    public IReadOnlyList<PublicMessage>? Messages { get; init; }

    /// <summary>
    /// 联系人
    /// </summary>
    [JsonPropertyName("contact")]
    public PublicContactRecord? Contact { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
