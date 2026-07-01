using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record AccountSummary
{
    [JsonPropertyName("avg_first_response_time")]
    public string? AvgFirstResponseTime { get; init; }

    [JsonPropertyName("avg_resolution_time")]
    public string? AvgResolutionTime { get; init; }

    [JsonPropertyName("conversations_count")]
    public decimal? ConversationsCount { get; init; }

    [JsonPropertyName("incoming_messages_count")]
    public decimal? IncomingMessagesCount { get; init; }

    [JsonPropertyName("outgoing_messages_count")]
    public decimal? OutgoingMessagesCount { get; init; }

    [JsonPropertyName("resolutions_count")]
    public decimal? ResolutionsCount { get; init; }

    [JsonPropertyName("previous")]
    public IDictionary<string, JsonElement>? Previous { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
