using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record Conversation
{
    [JsonPropertyName("id")]
    public decimal? Id { get; init; }

    [JsonPropertyName("messages")]
    public IReadOnlyList<Message>? Messages { get; init; }

    [JsonPropertyName("account_id")]
    public decimal? AccountId { get; init; }

    [JsonPropertyName("uuid")]
    public string? Uuid { get; init; }

    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    [JsonPropertyName("agent_last_seen_at")]
    public decimal? AgentLastSeenAt { get; init; }

    [JsonPropertyName("assignee_last_seen_at")]
    public decimal? AssigneeLastSeenAt { get; init; }

    [JsonPropertyName("can_reply")]
    public bool? CanReply { get; init; }

    [JsonPropertyName("contact_last_seen_at")]
    public decimal? ContactLastSeenAt { get; init; }

    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }

    [JsonPropertyName("inbox_id")]
    public decimal? InboxId { get; init; }

    [JsonPropertyName("labels")]
    public IReadOnlyList<string?>? Labels { get; init; }

    [JsonPropertyName("muted")]
    public bool? Muted { get; init; }

    [JsonPropertyName("snoozed_until")]
    public decimal? SnoozedUntil { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("created_at")]
    public decimal? CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public decimal? UpdatedAt { get; init; }

    [JsonPropertyName("timestamp")]
    public decimal? Timestamp { get; init; }

    [JsonPropertyName("first_reply_created_at")]
    public decimal? FirstReplyCreatedAt { get; init; }

    [JsonPropertyName("unread_count")]
    public decimal? UnreadCount { get; init; }

    [JsonPropertyName("last_non_activity_message")]
    public JsonElement? LastNonActivityMessage { get; init; }

    [JsonPropertyName("last_activity_at")]
    public decimal? LastActivityAt { get; init; }

    [JsonPropertyName("priority")]
    public string? Priority { get; init; }

    [JsonPropertyName("waiting_since")]
    public decimal? WaitingSince { get; init; }

    [JsonPropertyName("sla_policy_id")]
    public decimal? SlaPolicyId { get; init; }

    [JsonPropertyName("applied_sla")]
    public IDictionary<string, JsonElement>? AppliedSla { get; init; }

    [JsonPropertyName("sla_events")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? SlaEvents { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
