using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：分类
/// </summary>
public sealed record Category
{
    /// <summary>
    /// ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 文字内容。
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// 区域设置
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; init; }

    /// <summary>
    /// 名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Slug
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; init; }

    /// <summary>
    /// 位置
    /// </summary>
    [JsonPropertyName("position")]
    public long? Position { get; init; }

    /// <summary>
    /// 门户ID
    /// </summary>
    [JsonPropertyName("portal_id")]
    public long? PortalId { get; init; }

    /// <summary>
    /// 账号ID
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// 将相似的类别相互关联，例如不同语言的相同类别的产品文档
    /// </summary>
    [JsonPropertyName("associated_category_id")]
    public long? AssociatedCategoryId { get; init; }

    /// <summary>
    /// 定义父类别，例如产品文档在销售类别或工程类别中具有多个级别的功能。
    /// </summary>
    [JsonPropertyName("parent_category_id")]
    public long? ParentCategoryId { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
