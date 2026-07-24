using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：门户创建更新载荷。
/// </summary>
public sealed record PortalCreateUpdatePayload : JsonExtensionDataPayload
{
    /// <summary>
    /// 十六进制格式的帮助中心的标题颜色
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color { get; set; }

    /// <summary>
    /// 用于显示帮助中心的自定义域。
    /// </summary>
    [JsonPropertyName("custom_domain")]
    public string? CustomDomain { get; set; }

    /// <summary>
    /// 帮助中心标题
    /// </summary>
    [JsonPropertyName("header_text")]
    public string? HeaderText { get; set; }

    /// <summary>
    /// 链接到主仪表板
    /// </summary>
    [JsonPropertyName("homepage_link")]
    public string? HomepageLink { get; set; }

    /// <summary>
    /// 门户的名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 门户的页面标题
    /// </summary>
    [JsonPropertyName("page_title")]
    public string? PageTitle { get; set; }

    /// <summary>
    /// 用于在链接中显示的门户的 Slug
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    /// <summary>
    /// 检查门户是否处于活动状态
    /// </summary>
    [JsonPropertyName("archived")]
    public bool? Archived { get; set; }

    /// <summary>
    /// 有关支持区域设置的配置
    /// </summary>
    [JsonPropertyName("config")]
    public PortalCreateUpdateConfig? Config { get; set; }
}
