using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：会话
/// </summary>
public sealed record Conversation
{
    /// <summary>
    /// ID
    /// </summary>
    [JsonPropertyName("id")]
    public decimal? Id { get; init; }

    /// <summary>
    /// 消息
    /// </summary>
    [JsonPropertyName("messages")]
    public IReadOnlyList<Message>? Messages { get; init; }

    /// <summary>
    /// 账号ID
    /// </summary>
    [JsonPropertyName("account_id")]
    public decimal? AccountId { get; init; }

    /// <summary>
    /// UUID
    /// </summary>
    [JsonPropertyName("uuid")]
    public string? Uuid { get; init; }

    /// <summary>
    /// 附加属性
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    /// <summary>
    /// 坐席最后查看时间
    /// </summary>
    [JsonPropertyName("agent_last_seen_at")]
    public decimal? AgentLastSeenAt { get; init; }

    /// <summary>
    /// Assignee最后查看时间
    /// </summary>
    [JsonPropertyName("assignee_last_seen_at")]
    public decimal? AssigneeLastSeenAt { get; init; }

    /// <summary>
    /// CanReply
    /// </summary>
    [JsonPropertyName("can_reply")]
    public bool? CanReply { get; init; }

    /// <summary>
    /// 联系人最后查看时间
    /// </summary>
    [JsonPropertyName("contact_last_seen_at")]
    public decimal? ContactLastSeenAt { get; init; }

    /// <summary>
    /// 自定义属性
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }

    /// <summary>
    /// 收件箱ID
    /// </summary>
    [JsonPropertyName("inbox_id")]
    public decimal? InboxId { get; init; }

    /// <summary>
    /// 标签
    /// </summary>
    [JsonPropertyName("labels")]
    public IReadOnlyList<string?>? Labels { get; init; }

    /// <summary>
    /// Muted
    /// </summary>
    [JsonPropertyName("muted")]
    public bool? Muted { get; init; }

    /// <summary>
    /// SnoozedUntil
    /// </summary>
    [JsonPropertyName("snoozed_until")]
    public decimal? SnoozedUntil { get; init; }

    /// <summary>
    /// 状态
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [JsonPropertyName("created_at")]
    public decimal? CreatedAt { get; init; }

    /// <summary>
    /// 更新时间
    /// </summary>
    [JsonPropertyName("updated_at")]
    public decimal? UpdatedAt { get; init; }

    /// <summary>
    /// Timestamp
    /// </summary>
    [JsonPropertyName("timestamp")]
    public decimal? Timestamp { get; init; }

    /// <summary>
    /// 首次Reply创建时间
    /// </summary>
    [JsonPropertyName("first_reply_created_at")]
    public decimal? FirstReplyCreatedAt { get; init; }

    /// <summary>
    /// Unread数量
    /// </summary>
    [JsonPropertyName("unread_count")]
    public decimal? UnreadCount { get; init; }

    /// <summary>
    /// 最后NonActivity消息
    /// </summary>
    [JsonPropertyName("last_non_activity_message")]
    public JsonElement? LastNonActivityMessage { get; init; }

    /// <summary>
    /// 最后Activity时间
    /// </summary>
    [JsonPropertyName("last_activity_at")]
    public decimal? LastActivityAt { get; init; }

    /// <summary>
    /// 优先级
    /// </summary>
    [JsonPropertyName("priority")]
    public string? Priority { get; init; }

    /// <summary>
    /// WaitingSince
    /// </summary>
    [JsonPropertyName("waiting_since")]
    public decimal? WaitingSince { get; init; }

    /// <summary>
    /// SlaPolicyID
    /// </summary>
    [JsonPropertyName("sla_policy_id")]
    public decimal? SlaPolicyId { get; init; }

    /// <summary>
    /// AppliedSla
    /// </summary>
    [JsonPropertyName("applied_sla")]
    public IDictionary<string, JsonElement>? AppliedSla { get; init; }

    /// <summary>
    /// Sla事件
    /// </summary>
    [JsonPropertyName("sla_events")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? SlaEvents { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
