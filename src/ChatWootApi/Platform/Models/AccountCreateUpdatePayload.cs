using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Platform.Models;

/// <summary>
/// Chatwoot 平台模型：账号创建更新载荷
/// </summary>
public sealed record AccountCreateUpdatePayload
{
    /// <summary>
    /// 名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 区域设置
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    /// <summary>
    /// 域名
    /// </summary>
    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    /// <summary>
    /// 支持邮箱
    /// </summary>
    [JsonPropertyName("support_email")]
    public string? SupportEmail { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// Limits
    /// </summary>
    [JsonPropertyName("limits")]
    public IDictionary<string, object>? Limits { get; set; }

    /// <summary>
    /// 自定义属性
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, object>? CustomAttributes { get; set; }
}
