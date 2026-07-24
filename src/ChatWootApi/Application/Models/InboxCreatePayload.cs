using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：收件箱创建载荷。
/// </summary>
public sealed record InboxCreatePayload : JsonExtensionDataPayload
{
    /// <summary>
    /// 收件箱的名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 头像的图像文件。
    /// </summary>
    [JsonPropertyName("avatar")]
    public string? Avatar { get; set; }

    /// <summary>
    /// 启用问候消息。
    /// </summary>
    [JsonPropertyName("greeting_enabled")]
    public bool? GreetingEnabled { get; set; }

    /// <summary>
    /// 启用问候消息时发送的问候消息。
    /// </summary>
    [JsonPropertyName("greeting_message")]
    public string? GreetingMessage { get; set; }

    /// <summary>
    /// 启用电子邮件收集。 可用于：“网站”
    /// </summary>
    [JsonPropertyName("enable_email_collect")]
    public bool? EnableEmailCollect { get; set; }

    /// <summary>
    /// 启用 CSAT 调查。
    /// </summary>
    [JsonPropertyName("csat_survey_enabled")]
    public bool? CsatSurveyEnabled { get; set; }

    /// <summary>
    /// CSAT 调查配置。
    /// </summary>
    [JsonPropertyName("csat_config")]
    public CsatConfig? CsatConfig { get; set; }

    /// <summary>
    /// 启用自动分配。
    /// </summary>
    [JsonPropertyName("enable_auto_assignment")]
    public bool? EnableAutoAssignment { get; set; }

    /// <summary>
    /// 启用工作时间。
    /// </summary>
    [JsonPropertyName("working_hours_enabled")]
    public bool? WorkingHoursEnabled { get; set; }

    /// <summary>
    /// 在工作时间之外发送外出消息。
    /// </summary>
    [JsonPropertyName("out_of_office_message")]
    public string? OutOfOfficeMessage { get; set; }

    /// <summary>
    /// 收件箱的时区。
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>
    /// 对话解决后允许消息。 可用于：“网站”
    /// </summary>
    [JsonPropertyName("allow_messages_after_resolved")]
    public bool? AllowMessagesAfterResolved { get; set; }

    /// <summary>
    /// 将联系人消息锁定到单个活动对话。 适用于： `API` `LINE` `Telegram` `WhatsApp` `SMS`
    /// </summary>
    [JsonPropertyName("lock_to_single_conversation")]
    public bool? LockToSingleConversation { get; set; }

    /// <summary>
    /// 要附加到收件箱的帮助中心门户的 ID。
    /// </summary>
    [JsonPropertyName("portal_id")]
    public long? PortalId { get; set; }

    /// <summary>
    /// 出站电子邮件回复的发件人姓名类型。 适用于：`网站``电子邮件`
    /// </summary>
    [JsonPropertyName("sender_name_type")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<SenderNameType>))]
    public SenderNameType? SenderNameType { get; set; }

    /// <summary>
    /// 出站电子邮件回复的公司名称。 适用于：`网站``电子邮件`
    /// </summary>
    [JsonPropertyName("business_name")]
    public string? BusinessName { get; set; }

    /// <summary>
    /// 渠道。
    /// </summary>
    [JsonPropertyName("channel")]
    public InboxCreateChannelPayload? Channel { get; set; }
}
