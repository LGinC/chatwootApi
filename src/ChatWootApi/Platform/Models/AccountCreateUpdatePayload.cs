using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Platform;

public sealed record AccountCreateUpdatePayload
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("locale")]
    public string? Locale { get; init; }

    [JsonPropertyName("domain")]
    public string? Domain { get; init; }

    [JsonPropertyName("support_email")]
    public string? SupportEmail { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("limits")]
    public IDictionary<string, JsonElement>? Limits { get; init; }

    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }
}
