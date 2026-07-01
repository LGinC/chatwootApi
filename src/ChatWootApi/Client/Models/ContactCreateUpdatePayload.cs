using System.Text.Json.Serialization;

namespace ChatWootApi.Client;

public sealed record ContactCreateUpdatePayload
{
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }

    [JsonPropertyName("identifier_hash")]
    public string? IdentifierHash { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; init; }

    [JsonPropertyName("avatar")]
    public string? Avatar { get; init; }

    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, object?>? CustomAttributes { get; init; }
}
