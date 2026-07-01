using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record Agent
{
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    [JsonPropertyName("availability_status")]
    public string? AvailabilityStatus { get; init; }

    [JsonPropertyName("auto_offline")]
    public bool? AutoOffline { get; init; }

    [JsonPropertyName("confirmed")]
    public bool? Confirmed { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [JsonPropertyName("available_name")]
    public string? AvailableName { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("role")]
    public string? Role { get; init; }

    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; init; }

    [JsonPropertyName("custom_role_id")]
    public long? CustomRoleId { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
