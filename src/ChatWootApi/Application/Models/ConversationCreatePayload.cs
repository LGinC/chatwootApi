using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record ConversationCreatePayload
{
    [JsonPropertyName("source_id")]
    public string? SourceId { get; init; }

    [JsonPropertyName("inbox_id")]
    public long? InboxId { get; init; }

    [JsonPropertyName("contact_id")]
    public long? ContactId { get; init; }

    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("assignee_id")]
    public long? AssigneeId { get; init; }

    [JsonPropertyName("team_id")]
    public long? TeamId { get; init; }

    [JsonPropertyName("snoozed_until")]
    public string? SnoozedUntil { get; init; }

    [JsonPropertyName("message")]
    public IDictionary<string, JsonElement>? Message { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
