using System.Text.Json.Serialization;

namespace ChatWootApi.Platform;

public sealed record AgentBotCreateUpdatePayload
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("outgoing_url")]
    public string? OutgoingUrl { get; init; }

    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    [JsonPropertyName("avatar")]
    public string? Avatar { get; init; }

    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; init; }
}
