using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

#pragma warning disable CS1591

/// <summary>创建收件箱时的渠道载荷基类；文档要求通过 <c>type</c> 指定渠道类型。</summary>
[JsonConverter(typeof(InboxChannelPayloadConverter<InboxCreateChannelPayload>))]
public abstract record InboxCreateChannelPayload
{
    /// <summary>渠道类型，如 <c>web_widget</c>、<c>api</c>、<c>email</c>、<c>line</c>、<c>telegram</c>、<c>whatsapp</c> 或 <c>sms</c>。</summary>
    [JsonPropertyName("type")] public string? Type { get; init; }
    /// <summary>未被当前渠道模型显式覆盖的文档扩展字段。</summary>
    [JsonExtensionData] public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>更新现有收件箱时的渠道载荷基类；请求仅包含待更新的渠道字段。</summary>
[JsonConverter(typeof(InboxChannelPayloadConverter<InboxUpdateChannelPayload>))]
public abstract record InboxUpdateChannelPayload
{
    /// <summary>未被当前渠道模型显式覆盖的文档扩展字段。</summary>
    [JsonExtensionData] public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>创建 Website（Web Widget）渠道的载荷。</summary>
public sealed record InboxCreateWebWidgetChannelPayload : InboxCreateChannelPayload
{
    /// <summary>加载小部件的网站 URL。</summary>
    [JsonPropertyName("website_url")] public string? WebsiteUrl { get; init; }
    /// <summary>小部件中显示的欢迎标题。</summary>
    [JsonPropertyName("welcome_title")] public string? WelcomeTitle { get; init; }
    /// <summary>小部件中显示的欢迎标语。</summary>
    [JsonPropertyName("welcome_tagline")] public string? WelcomeTagline { get; init; }
    /// <summary>小部件的十六进制主题颜色。</summary>
    [JsonPropertyName("widget_color")] public string? WidgetColor { get; init; }
    /// <summary>小部件显示的预计回复时间。</summary>
    [JsonPropertyName("reply_time")] [JsonConverter(typeof(ChatWootStringEnumConverter<WidgetReplyTime>))] public WidgetReplyTime? ReplyTime { get; init; }
    /// <summary>是否启用开始会话前的预聊天表单。</summary>
    [JsonPropertyName("pre_chat_form_enabled")] public bool? PreChatFormEnabled { get; init; }
    /// <summary>联系人离开网站后是否通过电子邮件延续会话。</summary>
    [JsonPropertyName("continuity_via_email")] public bool? ContinuityViaEmail { get; init; }
    /// <summary>是否强制对小部件联系人进行 HMAC 验证。</summary>
    [JsonPropertyName("hmac_mandatory")] public bool? HmacMandatory { get; init; }
    /// <summary>启用的小部件功能标志。</summary>
    [JsonPropertyName("selected_feature_flags")] public IReadOnlyList<WebWidgetFeatureFlag>? SelectedFeatureFlags { get; init; }
}
/// <summary>创建 API 渠道的载荷。</summary>
public sealed record InboxCreateApiChannelPayload : InboxCreateChannelPayload
{
    [JsonPropertyName("webhook_url")] public string? WebhookUrl { get; init; }
    [JsonPropertyName("hmac_mandatory")] public bool? HmacMandatory { get; init; }
    [JsonPropertyName("additional_attributes")] public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }
}
/// <summary>创建 Email 渠道的载荷，包含 IMAP 与 SMTP 配置。</summary>
public sealed record InboxCreateEmailChannelPayload : InboxCreateChannelPayload
{
    [JsonPropertyName("email")] public string? Email { get; init; }
    [JsonPropertyName("imap_enabled")] public bool? ImapEnabled { get; init; }
    [JsonPropertyName("imap_login")] public string? ImapLogin { get; init; }
    [JsonPropertyName("imap_password")] public string? ImapPassword { get; init; }
    [JsonPropertyName("imap_address")] public string? ImapAddress { get; init; }
    [JsonPropertyName("imap_port")] public long? ImapPort { get; init; }
    [JsonPropertyName("imap_enable_ssl")] public bool? ImapEnableSsl { get; init; }
    [JsonPropertyName("imap_authentication")] public string? ImapAuthentication { get; init; }
    [JsonPropertyName("smtp_enabled")] public bool? SmtpEnabled { get; init; }
    [JsonPropertyName("smtp_login")] public string? SmtpLogin { get; init; }
    [JsonPropertyName("smtp_password")] public string? SmtpPassword { get; init; }
    [JsonPropertyName("smtp_address")] public string? SmtpAddress { get; init; }
    [JsonPropertyName("smtp_port")] public long? SmtpPort { get; init; }
    [JsonPropertyName("smtp_domain")] public string? SmtpDomain { get; init; }
    [JsonPropertyName("smtp_enable_starttls_auto")] public bool? SmtpEnableStarttlsAuto { get; init; }
    [JsonPropertyName("smtp_enable_ssl_tls")] public bool? SmtpEnableSslTls { get; init; }
    [JsonPropertyName("smtp_openssl_verify_mode")] public string? SmtpOpensslVerifyMode { get; init; }
    [JsonPropertyName("smtp_authentication")] public string? SmtpAuthentication { get; init; }
    [JsonPropertyName("provider")] public string? Provider { get; init; }
    [JsonPropertyName("verified_for_sending")] public bool? VerifiedForSending { get; init; }
}
/// <summary>创建 LINE 渠道的载荷。</summary>
public sealed record InboxCreateLineChannelPayload : InboxCreateChannelPayload
{
    [JsonPropertyName("line_channel_id")] public string? LineChannelId { get; init; }
    [JsonPropertyName("line_channel_secret")] public string? LineChannelSecret { get; init; }
    [JsonPropertyName("line_channel_token")] public string? LineChannelToken { get; init; }
}
/// <summary>创建 Telegram 渠道的载荷。</summary>
public sealed record InboxCreateTelegramChannelPayload : InboxCreateChannelPayload { [JsonPropertyName("bot_token")] public string? BotToken { get; init; } }
/// <summary>创建 WhatsApp Cloud 或旧版 360dialog 渠道的载荷。</summary>
public sealed record InboxCreateWhatsappChannelPayload : InboxCreateChannelPayload
{
    [JsonPropertyName("phone_number")] public string? PhoneNumber { get; init; }
    [JsonPropertyName("provider")] [JsonConverter(typeof(ChatWootStringEnumConverter<WhatsAppProvider>))] public WhatsAppProvider? Provider { get; init; }
    [JsonPropertyName("provider_config")] public WhatsAppProviderConfig? ProviderConfig { get; init; }
}
/// <summary>创建 SMS 渠道的载荷。</summary>
public sealed record InboxCreateSmsChannelPayload : InboxCreateChannelPayload
{
    [JsonPropertyName("phone_number")] public string? PhoneNumber { get; init; }
    [JsonPropertyName("provider_config")] public IDictionary<string, JsonElement>? ProviderConfig { get; init; }
}

/// <summary>更新 Website（Web Widget）渠道的载荷。</summary>
public sealed record InboxUpdateWebWidgetChannelPayload : InboxUpdateChannelPayload
{
    [JsonPropertyName("website_url")] public string? WebsiteUrl { get; init; }
    [JsonPropertyName("welcome_title")] public string? WelcomeTitle { get; init; }
    [JsonPropertyName("welcome_tagline")] public string? WelcomeTagline { get; init; }
    [JsonPropertyName("widget_color")] public string? WidgetColor { get; init; }
    [JsonPropertyName("reply_time")] [JsonConverter(typeof(ChatWootStringEnumConverter<WidgetReplyTime>))] public WidgetReplyTime? ReplyTime { get; init; }
    [JsonPropertyName("pre_chat_form_enabled")] public bool? PreChatFormEnabled { get; init; }
    [JsonPropertyName("continuity_via_email")] public bool? ContinuityViaEmail { get; init; }
    [JsonPropertyName("hmac_mandatory")] public bool? HmacMandatory { get; init; }
    [JsonPropertyName("selected_feature_flags")] public IReadOnlyList<WebWidgetFeatureFlag>? SelectedFeatureFlags { get; init; }
}
/// <summary>更新 API 渠道的载荷。</summary>
public sealed record InboxUpdateApiChannelPayload : InboxUpdateChannelPayload
{
    [JsonPropertyName("webhook_url")] public string? WebhookUrl { get; init; }
    [JsonPropertyName("hmac_mandatory")] public bool? HmacMandatory { get; init; }
    [JsonPropertyName("additional_attributes")] public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }
}
/// <summary>更新 Email 渠道的载荷，包含 IMAP 与 SMTP 配置。</summary>
public sealed record InboxUpdateEmailChannelPayload : InboxUpdateChannelPayload
{
    [JsonPropertyName("email")] public string? Email { get; init; }
    [JsonPropertyName("imap_enabled")] public bool? ImapEnabled { get; init; }
    [JsonPropertyName("imap_login")] public string? ImapLogin { get; init; }
    [JsonPropertyName("imap_password")] public string? ImapPassword { get; init; }
    [JsonPropertyName("imap_address")] public string? ImapAddress { get; init; }
    [JsonPropertyName("imap_port")] public long? ImapPort { get; init; }
    [JsonPropertyName("imap_enable_ssl")] public bool? ImapEnableSsl { get; init; }
    [JsonPropertyName("imap_authentication")] public string? ImapAuthentication { get; init; }
    [JsonPropertyName("smtp_enabled")] public bool? SmtpEnabled { get; init; }
    [JsonPropertyName("smtp_login")] public string? SmtpLogin { get; init; }
    [JsonPropertyName("smtp_password")] public string? SmtpPassword { get; init; }
    [JsonPropertyName("smtp_address")] public string? SmtpAddress { get; init; }
    [JsonPropertyName("smtp_port")] public long? SmtpPort { get; init; }
    [JsonPropertyName("smtp_domain")] public string? SmtpDomain { get; init; }
    [JsonPropertyName("smtp_enable_starttls_auto")] public bool? SmtpEnableStarttlsAuto { get; init; }
    [JsonPropertyName("smtp_enable_ssl_tls")] public bool? SmtpEnableSslTls { get; init; }
    [JsonPropertyName("smtp_openssl_verify_mode")] public string? SmtpOpensslVerifyMode { get; init; }
    [JsonPropertyName("smtp_authentication")] public string? SmtpAuthentication { get; init; }
    [JsonPropertyName("provider")] public string? Provider { get; init; }
    [JsonPropertyName("verified_for_sending")] public bool? VerifiedForSending { get; init; }
}
/// <summary>更新 LINE 渠道的载荷。</summary>
public sealed record InboxUpdateLineChannelPayload : InboxUpdateChannelPayload
{
    [JsonPropertyName("line_channel_id")] public string? LineChannelId { get; init; }
    [JsonPropertyName("line_channel_secret")] public string? LineChannelSecret { get; init; }
    [JsonPropertyName("line_channel_token")] public string? LineChannelToken { get; init; }
}
/// <summary>更新 Telegram 渠道的载荷。</summary>
public sealed record InboxUpdateTelegramChannelPayload : InboxUpdateChannelPayload { [JsonPropertyName("bot_token")] public string? BotToken { get; init; } }
/// <summary>更新 WhatsApp Cloud 或旧版 360dialog 渠道的载荷。</summary>
public sealed record InboxUpdateWhatsappChannelPayload : InboxUpdateChannelPayload
{
    [JsonPropertyName("phone_number")] public string? PhoneNumber { get; init; }
    [JsonPropertyName("provider")] [JsonConverter(typeof(ChatWootStringEnumConverter<WhatsAppProvider>))] public WhatsAppProvider? Provider { get; init; }
    [JsonPropertyName("provider_config")] public WhatsAppProviderConfig? ProviderConfig { get; init; }
}
/// <summary>更新 SMS 渠道的载荷。</summary>
public sealed record InboxUpdateSmsChannelPayload : InboxUpdateChannelPayload
{
    [JsonPropertyName("phone_number")] public string? PhoneNumber { get; init; }
    [JsonPropertyName("provider_config")] public IDictionary<string, JsonElement>? ProviderConfig { get; init; }
}

internal sealed class InboxChannelPayloadConverter<TChannel> : JsonConverter<TChannel> where TChannel : class
{
    public override TChannel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => throw new NotSupportedException("Inbox channel payloads are request-only.");

    public override void Write(Utf8JsonWriter writer, TChannel value, JsonSerializerOptions options)
    {
        var runtimeType = value.GetType();
        JsonSerializer.Serialize(writer, value, options.GetTypeInfo(runtimeType));
    }
}

#pragma warning restore CS1591
