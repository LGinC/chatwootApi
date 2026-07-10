using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：门户项目
/// </summary>
public sealed record PortalItem
{
    /// <summary>
    /// 门户 ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 门户是否存档
    /// </summary>
    [JsonPropertyName("archived")]
    public bool? Archived { get; init; }

    /// <summary>
    /// 门户的颜色代码
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color { get; init; }

    /// <summary>
    /// 配置
    /// </summary>
    [JsonPropertyName("config")]
    public PortalConfig? Config { get; init; }

    /// <summary>
    /// 门户的自定义域
    /// </summary>
    [JsonPropertyName("custom_domain")]
    public string? CustomDomain { get; init; }

    /// <summary>
    /// 门户的标题文本
    /// </summary>
    [JsonPropertyName("header_text")]
    public string? HeaderText { get; init; }

    /// <summary>
    /// 门户网站的主页链接
    /// </summary>
    [JsonPropertyName("homepage_link")]
    public string? HomepageLink { get; init; }

    /// <summary>
    /// 门户名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 门户的 URL slug
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; init; }

    /// <summary>
    /// 门户的页面标题
    /// </summary>
    [JsonPropertyName("page_title")]
    public string? PageTitle { get; init; }

    /// <summary>
    /// 门户所属账户ID
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// 收件箱
    /// </summary>
    [JsonPropertyName("inbox")]
    public Inbox? Inbox { get; init; }

    /// <summary>
    /// 标志
    /// </summary>
    [JsonPropertyName("logo")]
    public PortalLogo? Logo { get; init; }

    /// <summary>
    /// 元数据
    /// </summary>
    [JsonPropertyName("meta")]
    public PortalMeta? Meta { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
