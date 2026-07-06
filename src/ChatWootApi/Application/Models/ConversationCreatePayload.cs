using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：会话创建载荷。
/// </summary>
public sealed record ConversationCreatePayload
{
    /// <summary>
    /// 来源ID。
    /// </summary>
    [JsonPropertyName("source_id")]
    public string? SourceId { get; init; }

    /// <summary>
    /// 收件箱ID。
    /// </summary>
    [JsonPropertyName("inbox_id")]
    public long? InboxId { get; init; }

    /// <summary>
    /// 联系人ID。
    /// </summary>
    [JsonPropertyName("contact_id")]
    public long? ContactId { get; init; }

    /// <summary>
    /// 附加属性。
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    /// <summary>
    /// 自定义属性。
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }

    /// <summary>
    /// 状态。
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// AssigneeID。
    /// </summary>
    [JsonPropertyName("assignee_id")]
    public long? AssigneeId { get; init; }

    /// <summary>
    /// 团队ID。
    /// </summary>
    [JsonPropertyName("team_id")]
    public long? TeamId { get; init; }

    /// <summary>
    /// SnoozedUntil。
    /// </summary>
    [JsonPropertyName("snoozed_until")]
    public string? SnoozedUntil { get; init; }

    /// <summary>
    /// 消息。
    /// </summary>
    [JsonPropertyName("message")]
    public IDictionary<string, JsonElement>? Message { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
