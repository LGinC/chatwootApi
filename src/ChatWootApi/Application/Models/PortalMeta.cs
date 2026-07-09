using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：门户元数据
/// </summary>
public sealed record PortalMeta
{
    /// <summary>
    /// 全部Articles数量
    /// </summary>
    [JsonPropertyName("all_articles_count")]
    public long? AllArticlesCount { get; init; }

    /// <summary>
    /// 归档Articles数量
    /// </summary>
    [JsonPropertyName("archived_articles_count")]
    public long? ArchivedArticlesCount { get; init; }

    /// <summary>
    /// 已发布数量
    /// </summary>
    [JsonPropertyName("published_count")]
    public long? PublishedCount { get; init; }

    /// <summary>
    /// 草稿Articles数量
    /// </summary>
    [JsonPropertyName("draft_articles_count")]
    public long? DraftArticlesCount { get; init; }

    /// <summary>
    /// Categories数量
    /// </summary>
    [JsonPropertyName("categories_count")]
    public long? CategoriesCount { get; init; }

    /// <summary>
    /// Default区域设置
    /// </summary>
    [JsonPropertyName("default_locale")]
    public string? DefaultLocale { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
