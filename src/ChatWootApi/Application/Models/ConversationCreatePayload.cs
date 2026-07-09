using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：会话创建载荷。
/// </summary>
public sealed record ConversationCreatePayload
{
    /// <summary>
    /// 来源ID。
    /// </summary>
    [JsonPropertyName("source_id")]
    public string? SourceId { get; set; }

    /// <summary>
    /// 收件箱ID。
    /// </summary>
    [JsonPropertyName("inbox_id")]
    public long? InboxId { get; set; }

    /// <summary>
    /// 联系人ID。
    /// </summary>
    [JsonPropertyName("contact_id")]
    public long? ContactId { get; set; }

    /// <summary>
    /// 附加属性。
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>
    /// 自定义属性。
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, object>? CustomAttributes { get; set; }

    /// <summary>
    /// 状态。
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// AssigneeID。
    /// </summary>
    [JsonPropertyName("assignee_id")]
    public long? AssigneeId { get; set; }

    /// <summary>
    /// 团队ID。
    /// </summary>
    [JsonPropertyName("team_id")]
    public long? TeamId { get; set; }

    /// <summary>
    /// SnoozedUntil。
    /// </summary>
    [JsonPropertyName("snoozed_until")]
    public string? SnoozedUntil { get; set; }

    /// <summary>
    /// 消息。
    /// </summary>
    [JsonPropertyName("message")]
    public IDictionary<string, object>? Message { get; set; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object>? ExtensionData { get; set; }
}
