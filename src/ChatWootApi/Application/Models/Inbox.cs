using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record Inbox
{
    [JsonPropertyName("id")]
    public decimal? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("website_url")]
    public string? WebsiteUrl { get; init; }

    [JsonPropertyName("channel_type")]
    public string? ChannelType { get; init; }

    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; init; }

    [JsonPropertyName("widget_color")]
    public string? WidgetColor { get; init; }

    [JsonPropertyName("website_token")]
    public string? WebsiteToken { get; init; }

    [JsonPropertyName("enable_auto_assignment")]
    public bool? EnableAutoAssignment { get; init; }

    [JsonPropertyName("web_widget_script")]
    public string? WebWidgetScript { get; init; }

    [JsonPropertyName("welcome_title")]
    public string? WelcomeTitle { get; init; }

    [JsonPropertyName("welcome_tagline")]
    public string? WelcomeTagline { get; init; }

    [JsonPropertyName("greeting_enabled")]
    public bool? GreetingEnabled { get; init; }

    [JsonPropertyName("greeting_message")]
    public string? GreetingMessage { get; init; }

    [JsonPropertyName("channel_id")]
    public decimal? ChannelId { get; init; }

    [JsonPropertyName("working_hours_enabled")]
    public bool? WorkingHoursEnabled { get; init; }

    [JsonPropertyName("enable_email_collect")]
    public bool? EnableEmailCollect { get; init; }

    [JsonPropertyName("csat_survey_enabled")]
    public bool? CsatSurveyEnabled { get; init; }

    [JsonPropertyName("auto_assignment_config")]
    public IDictionary<string, JsonElement>? AutoAssignmentConfig { get; init; }

    [JsonPropertyName("out_of_office_message")]
    public string? OutOfOfficeMessage { get; init; }

    [JsonPropertyName("working_hours")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? WorkingHours { get; init; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    [JsonPropertyName("callback_webhook_url")]
    public string? CallbackWebhookUrl { get; init; }

    [JsonPropertyName("allow_messages_after_resolved")]
    public bool? AllowMessagesAfterResolved { get; init; }

    [JsonPropertyName("lock_to_single_conversation")]
    public bool? LockToSingleConversation { get; init; }

    [JsonPropertyName("sender_name_type")]
    public string? SenderNameType { get; init; }

    [JsonPropertyName("business_name")]
    public string? BusinessName { get; init; }

    [JsonPropertyName("hmac_mandatory")]
    public bool? HmacMandatory { get; init; }

    [JsonPropertyName("selected_feature_flags")]
    public IReadOnlyList<string?>? SelectedFeatureFlags { get; init; }

    [JsonPropertyName("reply_time")]
    public string? ReplyTime { get; init; }

    [JsonPropertyName("messaging_service_sid")]
    public string? MessagingServiceSid { get; init; }

    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; init; }

    [JsonPropertyName("medium")]
    public string? Medium { get; init; }

    [JsonPropertyName("provider")]
    public string? Provider { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
