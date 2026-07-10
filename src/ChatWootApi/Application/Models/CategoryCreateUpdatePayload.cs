using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：分类创建更新载荷。
/// </summary>
public sealed record CategoryCreateUpdatePayload
{
    /// <summary>
    /// 类别名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 类别的描述
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// 要排序的门户列表中的类别位置
    /// </summary>
    [JsonPropertyName("position")]
    public long? Position { get; set; }

    /// <summary>
    /// URL 中使用的类别 slug
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    /// <summary>
    /// 类别的区域设置
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    /// <summary>
    /// 字符串形式的类别图标（表情符号）
    /// </summary>
    [JsonPropertyName("icon")]
    public string? Icon { get; set; }

    /// <summary>
    /// 定义父类别，例如产品文档在销售类别或工程类别中具有多个级别的功能。
    /// </summary>
    [JsonPropertyName("parent_category_id")]
    public long? ParentCategoryId { get; set; }

    /// <summary>
    /// 将相似的类别相互关联，例如不同语言的相同类别的产品文档
    /// </summary>
    [JsonPropertyName("associated_category_id")]
    public long? AssociatedCategoryId { get; set; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object>? ExtensionData { get; set; }
}
