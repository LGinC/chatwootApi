using System.Text.Json.Serialization;

namespace ChatWootApi.Platform;

public sealed record AccountUserCreateUpdatePayload
{
    [JsonPropertyName("user_id")]
    public long UserId { get; init; }

    [JsonPropertyName("role")]
    public string Role { get; init; } = string.Empty;
}
