using System.Text.Json.Serialization;

namespace ChatWootApi.Client;

public sealed record Conversation
{
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonPropertyName("uuid")]
    public string? Uuid { get; init; }

    [JsonPropertyName("inbox_id")]
    public long? InboxId { get; init; }

    [JsonPropertyName("contact_last_seen_at")]
    public long? ContactLastSeenAt { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("agent_last_seen_at")]
    public long? AgentLastSeenAt { get; init; }

    [JsonPropertyName("messages")]
    public IReadOnlyList<Message>? Messages { get; init; }

    [JsonPropertyName("contact")]
    public ContactRecord? Contact { get; init; }
}
