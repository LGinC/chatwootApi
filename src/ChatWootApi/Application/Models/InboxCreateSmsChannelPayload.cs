using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record InboxCreateSmsChannelPayload
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; init; }

    [JsonPropertyName("provider_config")]
    public IDictionary<string, JsonElement>? ProviderConfig { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
