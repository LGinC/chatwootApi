using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：收件箱创建WebWidget渠道载荷。
/// </summary>
public sealed record InboxCreateWebWidgetChannelPayload
{
    /// <summary>
    /// 类型。
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// 网站URL。
    /// </summary>
    [JsonPropertyName("website_url")]
    public string? WebsiteUrl { get; init; }

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
    /// Widget颜色。
    /// </summary>
    [JsonPropertyName("widget_color")]
    public string? WidgetColor { get; init; }

    /// <summary>
    /// Reply时间。
    /// </summary>
    [JsonPropertyName("reply_time")]
    public string? ReplyTime { get; init; }

    /// <summary>
    /// PreChatFormEnabled。
    /// </summary>
    [JsonPropertyName("pre_chat_form_enabled")]
    public bool? PreChatFormEnabled { get; init; }

    /// <summary>
    /// PreChatFormOptions。
    /// </summary>
    [JsonPropertyName("pre_chat_form_options")]
    public IDictionary<string, JsonElement>? PreChatFormOptions { get; init; }

    /// <summary>
    /// ContinuityVia邮箱。
    /// </summary>
    [JsonPropertyName("continuity_via_email")]
    public bool? ContinuityViaEmail { get; init; }

    /// <summary>
    /// HMACMandatory。
    /// </summary>
    [JsonPropertyName("hmac_mandatory")]
    public bool? HmacMandatory { get; init; }

    /// <summary>
    /// 允许Domains。
    /// </summary>
    [JsonPropertyName("allowed_domains")]
    public string? AllowedDomains { get; init; }

    /// <summary>
    /// SelectedFeatureFlags。
    /// </summary>
    [JsonPropertyName("selected_feature_flags")]
    public IReadOnlyList<string?>? SelectedFeatureFlags { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
