using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：收件箱更新载荷。
/// </summary>
public sealed record InboxUpdatePayload
{
    /// <summary>
    /// 名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 头像。
    /// </summary>
    [JsonPropertyName("avatar")]
    public string? Avatar { get; init; }

    /// <summary>
    /// GreetingEnabled。
    /// </summary>
    [JsonPropertyName("greeting_enabled")]
    public bool? GreetingEnabled { get; init; }

    /// <summary>
    /// Greeting消息。
    /// </summary>
    [JsonPropertyName("greeting_message")]
    public string? GreetingMessage { get; init; }

    /// <summary>
    /// Enable邮箱Collect。
    /// </summary>
    [JsonPropertyName("enable_email_collect")]
    public bool? EnableEmailCollect { get; init; }

    /// <summary>
    /// CSAT调查Enabled。
    /// </summary>
    [JsonPropertyName("csat_survey_enabled")]
    public bool? CsatSurveyEnabled { get; init; }

    /// <summary>
    /// CSAT配置。
    /// </summary>
    [JsonPropertyName("csat_config")]
    public IDictionary<string, JsonElement>? CsatConfig { get; init; }

    /// <summary>
    /// EnableAuto分配。
    /// </summary>
    [JsonPropertyName("enable_auto_assignment")]
    public bool? EnableAutoAssignment { get; init; }

    /// <summary>
    /// 工作时间Enabled。
    /// </summary>
    [JsonPropertyName("working_hours_enabled")]
    public bool? WorkingHoursEnabled { get; init; }

    /// <summary>
    /// OutOffice消息。
    /// </summary>
    [JsonPropertyName("out_of_office_message")]
    public string? OutOfOfficeMessage { get; init; }

    /// <summary>
    /// Timezone。
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    /// <summary>
    /// Allow消息After已解析。
    /// </summary>
    [JsonPropertyName("allow_messages_after_resolved")]
    public bool? AllowMessagesAfterResolved { get; init; }

    /// <summary>
    /// Lock单个会话。
    /// </summary>
    [JsonPropertyName("lock_to_single_conversation")]
    public bool? LockToSingleConversation { get; init; }

    /// <summary>
    /// 门户ID。
    /// </summary>
    [JsonPropertyName("portal_id")]
    public long? PortalId { get; init; }

    /// <summary>
    /// 发送者名称类型。
    /// </summary>
    [JsonPropertyName("sender_name_type")]
    public string? SenderNameType { get; init; }

    /// <summary>
    /// Business名称。
    /// </summary>
    [JsonPropertyName("business_name")]
    public string? BusinessName { get; init; }

    /// <summary>
    /// 渠道。
    /// </summary>
    [JsonPropertyName("channel")]
    public JsonElement? Channel { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
