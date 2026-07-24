using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：门户元数据
/// </summary>
public sealed record PortalMeta
{
    /// <summary>
    /// 文章总数
    /// </summary>
    [JsonPropertyName("all_articles_count")]
    public int? AllArticlesCount { get; init; }

    /// <summary>
    /// 存档文章数量
    /// </summary>
    [JsonPropertyName("archived_articles_count")]
    public int? ArchivedArticlesCount { get; init; }

    /// <summary>
    /// 发表文章数
    /// </summary>
    [JsonPropertyName("published_count")]
    public int? PublishedCount { get; init; }

    /// <summary>
    /// 条款草案数量
    /// </summary>
    [JsonPropertyName("draft_articles_count")]
    public int? DraftArticlesCount { get; init; }

    /// <summary>
    /// 类别数量
    /// </summary>
    [JsonPropertyName("categories_count")]
    public int? CategoriesCount { get; init; }

    /// <summary>
    /// 门户的默认区域设置
    /// </summary>
    [JsonPropertyName("default_locale")]
    public string? DefaultLocale { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
