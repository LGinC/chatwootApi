using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：收件箱
/// </summary>
public sealed record Inbox
{
    /// <summary>
    /// 收件箱 ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 收件箱名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 网站网址
    /// </summary>
    [JsonPropertyName("website_url")]
    public string? WebsiteUrl { get; init; }

    /// <summary>
    /// 收件箱类型
    /// </summary>
    [JsonPropertyName("channel_type")]
    public string? ChannelType { get; init; }

    /// <summary>
    /// 收件箱的头像图片
    /// </summary>
    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; init; }

    /// <summary>
    /// 用于自定义小部件的小部件颜色
    /// </summary>
    [JsonPropertyName("widget_color")]
    public string? WidgetColor { get; init; }

    /// <summary>
    /// 网站令牌
    /// </summary>
    [JsonPropertyName("website_token")]
    public string? WebsiteToken { get; init; }

    /// <summary>
    /// 显示自动分配是否启用的标志
    /// </summary>
    [JsonPropertyName("enable_auto_assignment")]
    public bool? EnableAutoAssignment { get; init; }

    /// <summary>
    /// 用于加载网站小部件的脚本
    /// </summary>
    [JsonPropertyName("web_widget_script")]
    public string? WebWidgetScript { get; init; }

    /// <summary>
    /// 小部件上显示的欢迎标题
    /// </summary>
    [JsonPropertyName("welcome_title")]
    public string? WelcomeTitle { get; init; }

    /// <summary>
    /// 欢迎标语显示在小部件上
    /// </summary>
    [JsonPropertyName("welcome_tagline")]
    public string? WelcomeTagline { get; init; }

    /// <summary>
    /// 显示是否启用问候语的标志
    /// </summary>
    [JsonPropertyName("greeting_enabled")]
    public bool? GreetingEnabled { get; init; }

    /// <summary>
    /// 用户开始对话时的问候消息
    /// </summary>
    [JsonPropertyName("greeting_message")]
    public string? GreetingMessage { get; init; }

    /// <summary>
    /// 该收件箱所属频道的ID
    /// </summary>
    [JsonPropertyName("channel_id")]
    public long? ChannelId { get; init; }

    /// <summary>
    /// 显示工作时间功能是否启用的标志
    /// </summary>
    [JsonPropertyName("working_hours_enabled")]
    public bool? WorkingHoursEnabled { get; init; }

    /// <summary>
    /// 启用从联系人收集电子邮件的标志
    /// </summary>
    [JsonPropertyName("enable_email_collect")]
    public bool? EnableEmailCollect { get; init; }

    /// <summary>
    /// 启用 CSAT 调查的标志
    /// </summary>
    [JsonPropertyName("csat_survey_enabled")]
    public bool? CsatSurveyEnabled { get; init; }

    /// <summary>
    /// 自动分配的配置设置
    /// </summary>
    [JsonPropertyName("auto_assignment_config")]
    public IDictionary<string, JsonElement>? AutoAssignmentConfig { get; init; }

    /// <summary>
    /// 客服人员不在办公室时显示的消息
    /// </summary>
    [JsonPropertyName("out_of_office_message")]
    public string? OutOfOfficeMessage { get; init; }

    /// <summary>
    /// 收件箱工作时间配置
    /// </summary>
    [JsonPropertyName("working_hours")]
    public IReadOnlyList<InboxWorkingHour>? WorkingHours { get; init; }

    /// <summary>
    /// 收件箱的时区配置
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    /// <summary>
    /// 用于回调的 Webhook URL
    /// </summary>
    [JsonPropertyName("callback_webhook_url")]
    public string? CallbackWebhookUrl { get; init; }

    /// <summary>
    /// 对话解决后是否允许消息
    /// </summary>
    [JsonPropertyName("allow_messages_after_resolved")]
    public bool? AllowMessagesAfterResolved { get; init; }

    /// <summary>
    /// 是否将联系人锁定为单个对话
    /// </summary>
    [JsonPropertyName("lock_to_single_conversation")]
    public bool? LockToSingleConversation { get; init; }

    /// <summary>
    /// 要显示的发件人姓名类型（例如，友好）
    /// </summary>
    [JsonPropertyName("sender_name_type")]
    public string? SenderNameType { get; init; }

    /// <summary>
    /// 与收件箱关联的公司名称
    /// </summary>
    [JsonPropertyName("business_name")]
    public string? BusinessName { get; init; }

    /// <summary>
    /// HMAC验证是否强制
    /// </summary>
    [JsonPropertyName("hmac_mandatory")]
    public bool? HmacMandatory { get; init; }

    /// <summary>
    /// 收件箱的选定功能标志
    /// </summary>
    [JsonPropertyName("selected_feature_flags")]
    public IReadOnlyList<string?>? SelectedFeatureFlags { get; init; }

    /// <summary>
    /// 预计回复时间
    /// </summary>
    [JsonPropertyName("reply_time")]
    public string? ReplyTime { get; init; }

    /// <summary>
    /// SMS 提供商的消息服务 SID
    /// </summary>
    [JsonPropertyName("messaging_service_sid")]
    public string? MessagingServiceSid { get; init; }

    /// <summary>
    /// 与收件箱关联的电话号码
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; init; }

    /// <summary>
    /// 沟通媒介（例如短信、电子邮件）
    /// </summary>
    [JsonPropertyName("medium")]
    public string? Medium { get; init; }

    /// <summary>
    /// 渠道提供商
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Chatwoot 应用模型：收件箱单日工作时间
/// </summary>
public sealed record InboxWorkingHour
{
    /// <summary>星期几（0 为星期日，6 为星期六）。</summary>
    [JsonPropertyName("day_of_week")] public int? DayOfWeek { get; init; }

    /// <summary>该日是否全天关闭。</summary>
    [JsonPropertyName("closed_all_day")] public bool? ClosedAllDay { get; init; }

    /// <summary>开始营业的小时数。</summary>
    [JsonPropertyName("open_hour")] public int? OpenHour { get; init; }

    /// <summary>开始营业的分钟数。</summary>
    [JsonPropertyName("open_minutes")] public int? OpenMinutes { get; init; }

    /// <summary>结束营业的小时数。</summary>
    [JsonPropertyName("close_hour")] public int? CloseHour { get; init; }

    /// <summary>结束营业的分钟数。</summary>
    [JsonPropertyName("close_minutes")] public int? CloseMinutes { get; init; }

    /// <summary>该日是否全天营业。</summary>
    [JsonPropertyName("open_all_day")] public bool? OpenAllDay { get; init; }
}
