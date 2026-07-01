using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record Article
{
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonPropertyName("content")]
    public string? Content { get; init; }

    [JsonPropertyName("meta")]
    public IDictionary<string, JsonElement>? Meta { get; init; }

    [JsonPropertyName("position")]
    public long? Position { get; init; }

    [JsonPropertyName("status")]
    public long? Status { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("slug")]
    public string? Slug { get; init; }

    [JsonPropertyName("views")]
    public long? Views { get; init; }

    [JsonPropertyName("portal_id")]
    public long? PortalId { get; init; }

    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    [JsonPropertyName("author_id")]
    public long? AuthorId { get; init; }

    [JsonPropertyName("category_id")]
    public long? CategoryId { get; init; }

    [JsonPropertyName("folder_id")]
    public long? FolderId { get; init; }

    [JsonPropertyName("associated_article_id")]
    public long? AssociatedArticleId { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
