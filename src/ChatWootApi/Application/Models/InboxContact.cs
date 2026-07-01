using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record InboxContact
{
    [JsonPropertyName("id")]
    public decimal? Id { get; init; }

    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; init; }

    [JsonPropertyName("channel_id")]
    public decimal? ChannelId { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("channel_type")]
    public string? ChannelType { get; init; }

    [JsonPropertyName("provider")]
    public string? Provider { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
