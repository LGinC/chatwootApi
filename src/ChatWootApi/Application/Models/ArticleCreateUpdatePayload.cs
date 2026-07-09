using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：文章创建更新载荷。
/// </summary>
public sealed record ArticleCreateUpdatePayload
{
    /// <summary>
    /// 标题。
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Slug。
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    /// <summary>
    /// 位置。
    /// </summary>
    [JsonPropertyName("position")]
    public long? Position { get; set; }

    /// <summary>
    /// 内容。
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    /// <summary>
    /// Description。
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// 分类ID。
    /// </summary>
    [JsonPropertyName("category_id")]
    public long? CategoryId { get; set; }

    /// <summary>
    /// AuthorID。
    /// </summary>
    [JsonPropertyName("author_id")]
    public long? AuthorId { get; set; }

    /// <summary>
    /// Associated文章ID。
    /// </summary>
    [JsonPropertyName("associated_article_id")]
    public long? AssociatedArticleId { get; set; }

    /// <summary>
    /// 状态。
    /// </summary>
    [JsonPropertyName("status")]
    public long? Status { get; set; }

    /// <summary>
    /// 区域设置。
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    /// <summary>
    /// 元数据。
    /// </summary>
    [JsonPropertyName("meta")]
    public IDictionary<string, object>? Meta { get; set; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object>? ExtensionData { get; set; }
}
