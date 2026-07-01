using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record AgentBot
{
    [JsonPropertyName("id")]
    public decimal? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; init; }

    [JsonPropertyName("outgoing_url")]
    public string? OutgoingUrl { get; init; }

    [JsonPropertyName("bot_type")]
    public string? BotType { get; init; }

    [JsonPropertyName("bot_config")]
    public IDictionary<string, JsonElement>? BotConfig { get; init; }

    [JsonPropertyName("account_id")]
    public decimal? AccountId { get; init; }

    [JsonPropertyName("access_token")]
    public string? AccessToken { get; init; }

    [JsonPropertyName("system_bot")]
    public bool? SystemBot { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
