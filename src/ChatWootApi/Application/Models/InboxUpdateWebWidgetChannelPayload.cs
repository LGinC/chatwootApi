using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：收件箱更新WebWidget渠道载荷
/// </summary>
public sealed record InboxUpdateWebWidgetChannelPayload
{
    /// <summary>
    /// 加载小部件的 URL
    /// </summary>
    [JsonPropertyName("website_url")]
    public string? WebsiteUrl { get; init; }

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
    /// 用于自定义小部件的十六进制颜色字符串
    /// </summary>
    [JsonPropertyName("widget_color")]
    public string? WidgetColor { get; init; }

    /// <summary>
    /// 小部件上显示的预计回复时间
    /// </summary>
    [JsonPropertyName("reply_time")]
    public string? ReplyTime { get; init; }

    /// <summary>
    /// 在开始对话之前启用预聊天表单
    /// </summary>
    [JsonPropertyName("pre_chat_form_enabled")]
    public bool? PreChatFormEnabled { get; init; }

    /// <summary>
    /// 聊天前表单配置
    /// </summary>
    [JsonPropertyName("pre_chat_form_options")]
    public IDictionary<string, JsonElement>? PreChatFormOptions { get; init; }

    /// <summary>
    /// 当联系人离开网站时，通过电子邮件继续对话
    /// </summary>
    [JsonPropertyName("continuity_via_email")]
    public bool? ContinuityViaEmail { get; init; }

    /// <summary>
    /// 使用小部件需要对联系人进行 HMAC 验证
    /// </summary>
    [JsonPropertyName("hmac_mandatory")]
    public bool? HmacMandatory { get; init; }

    /// <summary>
    /// 允许加载小部件的以逗号分隔的域列表
    /// </summary>
    [JsonPropertyName("allowed_domains")]
    public string? AllowedDomains { get; init; }

    /// <summary>
    /// 启用的小部件功能标志
    /// </summary>
    [JsonPropertyName("selected_feature_flags")]
    public IReadOnlyList<string?>? SelectedFeatureFlags { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
