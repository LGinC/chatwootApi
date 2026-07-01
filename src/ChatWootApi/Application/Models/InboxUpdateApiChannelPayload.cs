using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record InboxUpdateApiChannelPayload
{
    [JsonPropertyName("webhook_url")]
    public string? WebhookUrl { get; init; }

    [JsonPropertyName("hmac_mandatory")]
    public bool? HmacMandatory { get; init; }

    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
