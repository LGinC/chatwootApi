using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record IntegrationsHookCreatePayload
{
    [JsonPropertyName("app_id")]
    public long? AppId { get; init; }

    [JsonPropertyName("inbox_id")]
    public long? InboxId { get; init; }

    [JsonPropertyName("status")]
    public long? Status { get; init; }

    [JsonPropertyName("settings")]
    public IDictionary<string, JsonElement>? Settings { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
