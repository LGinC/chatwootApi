using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record AccountUpdatePayload
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("locale")]
    public string? Locale { get; init; }

    [JsonPropertyName("domain")]
    public string? Domain { get; init; }

    [JsonPropertyName("support_email")]
    public string? SupportEmail { get; init; }

    [JsonPropertyName("auto_resolve_after")]
    public long? AutoResolveAfter { get; init; }

    [JsonPropertyName("auto_resolve_message")]
    public string? AutoResolveMessage { get; init; }

    [JsonPropertyName("auto_resolve_ignore_waiting")]
    public bool? AutoResolveIgnoreWaiting { get; init; }

    [JsonPropertyName("industry")]
    public string? Industry { get; init; }

    [JsonPropertyName("company_size")]
    public string? CompanySize { get; init; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
