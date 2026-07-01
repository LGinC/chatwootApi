using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record InboxUpdateWebWidgetChannelPayload
{
    [JsonPropertyName("website_url")]
    public string? WebsiteUrl { get; init; }

    [JsonPropertyName("welcome_title")]
    public string? WelcomeTitle { get; init; }

    [JsonPropertyName("welcome_tagline")]
    public string? WelcomeTagline { get; init; }

    [JsonPropertyName("widget_color")]
    public string? WidgetColor { get; init; }

    [JsonPropertyName("reply_time")]
    public string? ReplyTime { get; init; }

    [JsonPropertyName("pre_chat_form_enabled")]
    public bool? PreChatFormEnabled { get; init; }

    [JsonPropertyName("pre_chat_form_options")]
    public IDictionary<string, JsonElement>? PreChatFormOptions { get; init; }

    [JsonPropertyName("continuity_via_email")]
    public bool? ContinuityViaEmail { get; init; }

    [JsonPropertyName("hmac_mandatory")]
    public bool? HmacMandatory { get; init; }

    [JsonPropertyName("allowed_domains")]
    public string? AllowedDomains { get; init; }

    [JsonPropertyName("selected_feature_flags")]
    public IReadOnlyList<string?>? SelectedFeatureFlags { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
