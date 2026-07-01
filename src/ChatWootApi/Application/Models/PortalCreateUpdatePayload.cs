using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record PortalCreateUpdatePayload
{
    [JsonPropertyName("color")]
    public string? Color { get; init; }

    [JsonPropertyName("custom_domain")]
    public string? CustomDomain { get; init; }

    [JsonPropertyName("header_text")]
    public string? HeaderText { get; init; }

    [JsonPropertyName("homepage_link")]
    public string? HomepageLink { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("page_title")]
    public string? PageTitle { get; init; }

    [JsonPropertyName("slug")]
    public string? Slug { get; init; }

    [JsonPropertyName("archived")]
    public bool? Archived { get; init; }

    [JsonPropertyName("config")]
    public IDictionary<string, JsonElement>? Config { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
