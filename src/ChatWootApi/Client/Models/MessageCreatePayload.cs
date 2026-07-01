using System.Text.Json.Serialization;

namespace ChatWootApi.Client;

public sealed record MessageCreatePayload
{
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    [JsonPropertyName("echo_id")]
    public string? EchoId { get; init; }
}
