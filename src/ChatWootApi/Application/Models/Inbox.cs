using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：收件箱。
/// </summary>
public sealed record Inbox
{
    /// <summary>
    /// ID。
    /// </summary>
    [JsonPropertyName("id")]
    public decimal? Id { get; init; }

    /// <summary>
    /// 名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 网站URL。
    /// </summary>
    [JsonPropertyName("website_url")]
    public string? WebsiteUrl { get; init; }

    /// <summary>
    /// 渠道类型。
    /// </summary>
    [JsonPropertyName("channel_type")]
    public string? ChannelType { get; init; }

    /// <summary>
    /// 头像URL。
    /// </summary>
    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; init; }

    /// <summary>
    /// Widget颜色。
    /// </summary>
    [JsonPropertyName("widget_color")]
    public string? WidgetColor { get; init; }

    /// <summary>
    /// 网站令牌。
    /// </summary>
    [JsonPropertyName("website_token")]
    public string? WebsiteToken { get; init; }

    /// <summary>
    /// EnableAuto分配。
    /// </summary>
    [JsonPropertyName("enable_auto_assignment")]
    public bool? EnableAutoAssignment { get; init; }

    /// <summary>
    /// WebWidgetScript。
    /// </summary>
    [JsonPropertyName("web_widget_script")]
    public string? WebWidgetScript { get; init; }

    /// <summary>
    /// Welcome标题。
    /// </summary>
    [JsonPropertyName("welcome_title")]
    public string? WelcomeTitle { get; init; }

    /// <summary>
    /// WelcomeTagline。
    /// </summary>
    [JsonPropertyName("welcome_tagline")]
    public string? WelcomeTagline { get; init; }

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
    /// 渠道ID。
    /// </summary>
    [JsonPropertyName("channel_id")]
    public decimal? ChannelId { get; init; }

    /// <summary>
    /// 工作时间Enabled。
    /// </summary>
    [JsonPropertyName("working_hours_enabled")]
    public bool? WorkingHoursEnabled { get; init; }

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
    /// Auto分配配置。
    /// </summary>
    [JsonPropertyName("auto_assignment_config")]
    public IDictionary<string, JsonElement>? AutoAssignmentConfig { get; init; }

    /// <summary>
    /// OutOffice消息。
    /// </summary>
    [JsonPropertyName("out_of_office_message")]
    public string? OutOfOfficeMessage { get; init; }

    /// <summary>
    /// 工作时间。
    /// </summary>
    [JsonPropertyName("working_hours")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? WorkingHours { get; init; }

    /// <summary>
    /// Timezone。
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    /// <summary>
    /// CallbackWebhookURL。
    /// </summary>
    [JsonPropertyName("callback_webhook_url")]
    public string? CallbackWebhookUrl { get; init; }

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
    /// HMACMandatory。
    /// </summary>
    [JsonPropertyName("hmac_mandatory")]
    public bool? HmacMandatory { get; init; }

    /// <summary>
    /// SelectedFeatureFlags。
    /// </summary>
    [JsonPropertyName("selected_feature_flags")]
    public IReadOnlyList<string?>? SelectedFeatureFlags { get; init; }

    /// <summary>
    /// Reply时间。
    /// </summary>
    [JsonPropertyName("reply_time")]
    public string? ReplyTime { get; init; }

    /// <summary>
    /// MessagingServiceSid。
    /// </summary>
    [JsonPropertyName("messaging_service_sid")]
    public string? MessagingServiceSid { get; init; }

    /// <summary>
    /// 电话号码。
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; init; }

    /// <summary>
    /// Medium。
    /// </summary>
    [JsonPropertyName("medium")]
    public string? Medium { get; init; }

    /// <summary>
    /// 提供者。
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
