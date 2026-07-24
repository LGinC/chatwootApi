using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：会话
/// </summary>
public record Conversation
{
    /// <summary>
    /// 对话ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 消息
    /// </summary>
    [JsonPropertyName("messages")]
    public IReadOnlyList<Message>? Messages { get; init; }

    /// <summary>
    /// 账户编号
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// 对话的 UUID
    /// </summary>
    [JsonPropertyName("uuid")]
    public string? Uuid { get; init; }

    /// <summary>
    /// 包含与对话相关的附加属性的对象
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public ConversationAdditionalAttributes? AdditionalAttributes { get; init; }

    /// <summary>
    /// 代理的最后一次活动
    /// </summary>
    [JsonPropertyName("agent_last_seen_at")]
    public long? AgentLastSeenAt { get; init; }

    /// <summary>
    /// 受让人的最后一次活动
    /// </summary>
    [JsonPropertyName("assignee_last_seen_at")]
    public long? AssigneeLastSeenAt { get; init; }

    /// <summary>
    /// 对话是否可以回复
    /// </summary>
    [JsonPropertyName("can_reply")]
    public bool? CanReply { get; init; }

    /// <summary>
    /// 联系人的最后活动时间
    /// </summary>
    [JsonPropertyName("contact_last_seen_at")]
    public long? ContactLastSeenAt { get; init; }

    /// <summary>
    /// 保存对话自定义属性的对象，接受自定义属性键和值
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }

    /// <summary>
    /// 收件箱 ID
    /// </summary>
    [JsonPropertyName("inbox_id")]
    public long? InboxId { get; init; }

    /// <summary>
    /// 对话的标签
    /// </summary>
    [JsonPropertyName("labels")]
    public IReadOnlyList<string?>? Labels { get; init; }

    /// <summary>
    /// 通话是否静音
    /// </summary>
    [JsonPropertyName("muted")]
    public bool? Muted { get; init; }

    /// <summary>
    /// 对话取消静音的时间
    /// </summary>
    [JsonPropertyName("snoozed_until")]
    public long? SnoozedUntil { get; init; }

    /// <summary>
    /// 对话状态
    /// </summary>
    [JsonPropertyName("status")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<ConversationStatus>))]
    public ConversationStatus? Status { get; init; }

    /// <summary>
    /// 对话创建时间
    /// </summary>
    [JsonPropertyName("created_at")]
    public long? CreatedAt { get; init; }

    /// <summary>
    /// 对话更新时间
    /// </summary>
    [JsonPropertyName("updated_at")]
    public long? UpdatedAt { get; init; }

    /// <summary>
    /// 对话创建时间
    /// </summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    /// <summary>
    /// 创建第一个回复的时间
    /// </summary>
    [JsonPropertyName("first_reply_created_at")]
    public long? FirstReplyCreatedAt { get; init; }

    /// <summary>
    /// 未读消息数
    /// </summary>
    [JsonPropertyName("unread_count")]
    public int? UnreadCount { get; init; }

    /// <summary>
    /// 最后一条非活动消息
    /// </summary>
    [JsonPropertyName("last_non_activity_message")]
    public Message? LastNonActivityMessage { get; init; }

    /// <summary>
    /// 对话的最后一个活动
    /// </summary>
    [JsonPropertyName("last_activity_at")]
    public long? LastActivityAt { get; init; }

    /// <summary>
    /// 对话的优先级
    /// </summary>
    [JsonPropertyName("priority")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<ConversationPriority>))]
    public ConversationPriority? Priority { get; init; }

    /// <summary>
    /// 对话等待的时间
    /// </summary>
    [JsonPropertyName("waiting_since")]
    public long? WaitingSince { get; init; }

    /// <summary>
    /// SLA策略ID
    /// </summary>
    [JsonPropertyName("sla_policy_id")]
    public long? SlaPolicyId { get; init; }

    /// <summary>
    /// 应用的 SLA
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
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
