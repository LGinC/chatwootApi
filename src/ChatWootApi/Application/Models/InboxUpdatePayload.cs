using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record InboxUpdatePayload
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("avatar")]
    public string? Avatar { get; init; }

    [JsonPropertyName("greeting_enabled")]
    public bool? GreetingEnabled { get; init; }

    [JsonPropertyName("greeting_message")]
    public string? GreetingMessage { get; init; }

    [JsonPropertyName("enable_email_collect")]
    public bool? EnableEmailCollect { get; init; }

    [JsonPropertyName("csat_survey_enabled")]
    public bool? CsatSurveyEnabled { get; init; }

    [JsonPropertyName("csat_config")]
    public IDictionary<string, JsonElement>? CsatConfig { get; init; }

    [JsonPropertyName("enable_auto_assignment")]
    public bool? EnableAutoAssignment { get; init; }

    [JsonPropertyName("working_hours_enabled")]
    public bool? WorkingHoursEnabled { get; init; }

    [JsonPropertyName("out_of_office_message")]
    public string? OutOfOfficeMessage { get; init; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    [JsonPropertyName("allow_messages_after_resolved")]
    public bool? AllowMessagesAfterResolved { get; init; }

    [JsonPropertyName("lock_to_single_conversation")]
    public bool? LockToSingleConversation { get; init; }

    [JsonPropertyName("portal_id")]
    public long? PortalId { get; init; }

    [JsonPropertyName("sender_name_type")]
    public string? SenderNameType { get; init; }

    [JsonPropertyName("business_name")]
    public string? BusinessName { get; init; }

    [JsonPropertyName("channel")]
    public JsonElement? Channel { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
