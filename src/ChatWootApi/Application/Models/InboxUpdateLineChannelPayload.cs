using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record InboxUpdateLineChannelPayload
{
    [JsonPropertyName("line_channel_id")]
    public string? LineChannelId { get; init; }

    [JsonPropertyName("line_channel_secret")]
    public string? LineChannelSecret { get; init; }

    [JsonPropertyName("line_channel_token")]
    public string? LineChannelToken { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
