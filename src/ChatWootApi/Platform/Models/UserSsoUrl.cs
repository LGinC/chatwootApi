using System.Text.Json.Serialization;

namespace ChatWootApi.Platform;

public sealed record UserSsoUrl
{
    [JsonPropertyName("url")]
    public string? Url { get; init; }
}
