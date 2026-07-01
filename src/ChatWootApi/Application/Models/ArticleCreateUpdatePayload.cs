using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record ArticleCreateUpdatePayload
{
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("slug")]
    public string? Slug { get; init; }

    [JsonPropertyName("position")]
    public long? Position { get; init; }

    [JsonPropertyName("content")]
    public string? Content { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("category_id")]
    public long? CategoryId { get; init; }

    [JsonPropertyName("author_id")]
    public long? AuthorId { get; init; }

    [JsonPropertyName("associated_article_id")]
    public long? AssociatedArticleId { get; init; }

    [JsonPropertyName("status")]
    public long? Status { get; init; }

    [JsonPropertyName("locale")]
    public string? Locale { get; init; }

    [JsonPropertyName("meta")]
    public IDictionary<string, JsonElement>? Meta { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
