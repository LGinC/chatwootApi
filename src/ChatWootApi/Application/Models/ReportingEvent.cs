using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record ReportingEvent
{
    [JsonPropertyName("id")]
    public decimal? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("value")]
    public decimal? Value { get; init; }

    [JsonPropertyName("value_in_business_hours")]
    public decimal? ValueInBusinessHours { get; init; }

    [JsonPropertyName("event_start_time")]
    public string? EventStartTime { get; init; }

    [JsonPropertyName("event_end_time")]
    public string? EventEndTime { get; init; }

    [JsonPropertyName("account_id")]
    public decimal? AccountId { get; init; }

    [JsonPropertyName("conversation_id")]
    public decimal? ConversationId { get; init; }

    [JsonPropertyName("inbox_id")]
    public decimal? InboxId { get; init; }

    [JsonPropertyName("user_id")]
    public decimal? UserId { get; init; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
