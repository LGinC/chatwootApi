using System.Text.Json.Serialization;

namespace ChatWootApi.Client;

public sealed record Contact
{
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonPropertyName("source_id")]
    public string? SourceId { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; init; }

    [JsonPropertyName("pubsub_token")]
    public string? PubsubToken { get; init; }
}
