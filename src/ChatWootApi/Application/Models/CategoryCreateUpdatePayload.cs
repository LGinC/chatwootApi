using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：分类创建更新载荷。
/// </summary>
public sealed record CategoryCreateUpdatePayload
{
    /// <summary>
    /// 名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Description。
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// 位置。
    /// </summary>
    [JsonPropertyName("position")]
    public long? Position { get; set; }

    /// <summary>
    /// Slug。
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    /// <summary>
    /// 区域设置。
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    /// <summary>
    /// Icon。
    /// </summary>
    [JsonPropertyName("icon")]
    public string? Icon { get; set; }

    /// <summary>
    /// Parent分类ID。
    /// </summary>
    [JsonPropertyName("parent_category_id")]
    public long? ParentCategoryId { get; set; }

    /// <summary>
    /// Associated分类ID。
    /// </summary>
    [JsonPropertyName("associated_category_id")]
    public long? AssociatedCategoryId { get; set; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object>? ExtensionData { get; set; }
}
