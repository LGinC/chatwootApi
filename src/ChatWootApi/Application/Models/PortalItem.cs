using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record PortalItem
{
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonPropertyName("archived")]
    public bool? Archived { get; init; }

    [JsonPropertyName("color")]
    public string? Color { get; init; }

    [JsonPropertyName("config")]
    public PortalConfig? Config { get; init; }

    [JsonPropertyName("custom_domain")]
    public string? CustomDomain { get; init; }

    [JsonPropertyName("header_text")]
    public string? HeaderText { get; init; }

    [JsonPropertyName("homepage_link")]
    public string? HomepageLink { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("slug")]
    public string? Slug { get; init; }

    [JsonPropertyName("page_title")]
    public string? PageTitle { get; init; }

    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    [JsonPropertyName("inbox")]
    public Inbox? Inbox { get; init; }

    [JsonPropertyName("logo")]
    public PortalLogo? Logo { get; init; }

    [JsonPropertyName("meta")]
    public PortalMeta? Meta { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
