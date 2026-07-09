using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：门户项目
/// </summary>
public sealed record PortalItem
{
    /// <summary>
    /// ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 归档
    /// </summary>
    [JsonPropertyName("archived")]
    public bool? Archived { get; init; }

    /// <summary>
    /// 颜色
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color { get; init; }

    /// <summary>
    /// 配置
    /// </summary>
    [JsonPropertyName("config")]
    public PortalConfig? Config { get; init; }

    /// <summary>
    /// 自定义域名
    /// </summary>
    [JsonPropertyName("custom_domain")]
    public string? CustomDomain { get; init; }

    /// <summary>
    /// HeaderText
    /// </summary>
    [JsonPropertyName("header_text")]
    public string? HeaderText { get; init; }

    /// <summary>
    /// HomepageLink
    /// </summary>
    [JsonPropertyName("homepage_link")]
    public string? HomepageLink { get; init; }

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
    /// Page标题
    /// </summary>
    [JsonPropertyName("page_title")]
    public string? PageTitle { get; init; }

    /// <summary>
    /// 账号ID
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
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
