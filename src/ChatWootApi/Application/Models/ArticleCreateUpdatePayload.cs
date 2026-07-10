using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：文章创建更新载荷。
/// </summary>
public sealed record ArticleCreateUpdatePayload : JsonExtensionDataPayload
{
    /// <summary>
    /// 文章标题
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// 文章的主旨
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    /// <summary>
    /// 文章在类别中的位置
    /// </summary>
    [JsonPropertyName("position")]
    public long? Position { get; set; }

    /// <summary>
    /// 文字内容。
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    /// <summary>
    /// 文章的描述
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// 文章的类别id
    /// </summary>
    [JsonPropertyName("category_id")]
    public long? CategoryId { get; set; }

    /// <summary>
    /// 文章作者代理id
    /// </summary>
    [JsonPropertyName("author_id")]
    public long? AuthorId { get; set; }

    /// <summary>
    /// 将相似的文章相互关联，例如提供参考链接。
    /// </summary>
    [JsonPropertyName("associated_article_id")]
    public long? AssociatedArticleId { get; set; }

    /// <summary>
    /// 文章的状态。 0 为草稿，1 为已发布，2 为已存档
    /// </summary>
    [JsonPropertyName("status")]
    public long? Status { get; set; }

    /// <summary>
    /// 文章的区域设置
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    /// <summary>
    /// 用于搜索
    /// </summary>
    [JsonPropertyName("meta")]
    public IDictionary<string, object>? Meta { get; set; }
}
