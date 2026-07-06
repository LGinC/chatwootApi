using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：分类。
/// </summary>
public sealed record Category
{
    /// <summary>
    /// ID。
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// Description。
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// 区域设置。
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; init; }

    /// <summary>
    /// 名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

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
    /// 门户ID。
    /// </summary>
    [JsonPropertyName("portal_id")]
    public long? PortalId { get; init; }

    /// <summary>
    /// 账号ID。
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// Associated分类ID。
    /// </summary>
    [JsonPropertyName("associated_category_id")]
    public long? AssociatedCategoryId { get; init; }

    /// <summary>
    /// Parent分类ID。
    /// </summary>
    [JsonPropertyName("parent_category_id")]
    public long? ParentCategoryId { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
