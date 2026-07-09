using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：门户创建更新载荷。
/// </summary>
public sealed record PortalCreateUpdatePayload
{
    /// <summary>
    /// 颜色。
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color { get; set; }

    /// <summary>
    /// 自定义域名。
    /// </summary>
    [JsonPropertyName("custom_domain")]
    public string? CustomDomain { get; set; }

    /// <summary>
    /// HeaderText。
    /// </summary>
    [JsonPropertyName("header_text")]
    public string? HeaderText { get; set; }

    /// <summary>
    /// HomepageLink。
    /// </summary>
    [JsonPropertyName("homepage_link")]
    public string? HomepageLink { get; set; }

    /// <summary>
    /// 名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Page标题。
    /// </summary>
    [JsonPropertyName("page_title")]
    public string? PageTitle { get; set; }

    /// <summary>
    /// Slug。
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    /// <summary>
    /// 归档。
    /// </summary>
    [JsonPropertyName("archived")]
    public bool? Archived { get; set; }

    /// <summary>
    /// 配置。
    /// </summary>
    [JsonPropertyName("config")]
    public IDictionary<string, object>? Config { get; set; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object>? ExtensionData { get; set; }
}
