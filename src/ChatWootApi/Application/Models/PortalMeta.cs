using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record PortalMeta
{
    [JsonPropertyName("all_articles_count")]
    public long? AllArticlesCount { get; init; }

    [JsonPropertyName("archived_articles_count")]
    public long? ArchivedArticlesCount { get; init; }

    [JsonPropertyName("published_count")]
    public long? PublishedCount { get; init; }

    [JsonPropertyName("draft_articles_count")]
    public long? DraftArticlesCount { get; init; }

    [JsonPropertyName("categories_count")]
    public long? CategoriesCount { get; init; }

    [JsonPropertyName("default_locale")]
    public string? DefaultLocale { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
