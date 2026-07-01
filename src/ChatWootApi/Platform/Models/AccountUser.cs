using System.Text.Json.Serialization;

namespace ChatWootApi.Platform;

public sealed record AccountUser
{
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    [JsonPropertyName("user_id")]
    public long? UserId { get; init; }

    [JsonPropertyName("role")]
    public string? Role { get; init; }
}
