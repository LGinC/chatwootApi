using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：文章创建更新载荷。
/// </summary>
public sealed record ArticleCreateUpdatePayload
{
    /// <summary>
    /// 标题。
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    /// <summary>
    /// Slug。
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; init; }

    /// <summary>
    /// 位置。
    /// </summary>
    [JsonPropertyName("position")]
    public long? Position { get; init; }

    /// <summary>
    /// 内容。
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    /// <summary>
    /// Description。
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// 分类ID。
    /// </summary>
    [JsonPropertyName("category_id")]
    public long? CategoryId { get; init; }

    /// <summary>
    /// AuthorID。
    /// </summary>
    [JsonPropertyName("author_id")]
    public long? AuthorId { get; init; }

    /// <summary>
    /// Associated文章ID。
    /// </summary>
    [JsonPropertyName("associated_article_id")]
    public long? AssociatedArticleId { get; init; }

    /// <summary>
    /// 状态。
    /// </summary>
    [JsonPropertyName("status")]
    public long? Status { get; init; }

    /// <summary>
    /// 区域设置。
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; init; }

    /// <summary>
    /// 元数据。
    /// </summary>
    [JsonPropertyName("meta")]
    public IDictionary<string, JsonElement>? Meta { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
