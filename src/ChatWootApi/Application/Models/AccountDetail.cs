using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：账号详情
/// </summary>
public sealed record AccountDetail
{
    /// <summary>
    /// ID
    /// </summary>
    [JsonPropertyName("id")]
    public decimal? Id { get; init; }

    /// <summary>
    /// 名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 区域设置
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; init; }

    /// <summary>
    /// 域名
    /// </summary>
    [JsonPropertyName("domain")]
    public string? Domain { get; init; }

    /// <summary>
    /// 支持邮箱
    /// </summary>
    [JsonPropertyName("support_email")]
    public string? SupportEmail { get; init; }

    /// <summary>
    /// 状态
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; init; }

    /// <summary>
    /// CacheKeys
    /// </summary>
    [JsonPropertyName("cache_keys")]
    public IDictionary<string, JsonElement>? CacheKeys { get; init; }

    /// <summary>
    /// Features
    /// </summary>
    [JsonPropertyName("features")]
    public IDictionary<string, JsonElement>? Features { get; init; }

    /// <summary>
    /// 设置
    /// </summary>
    [JsonPropertyName("settings")]
    public IDictionary<string, JsonElement>? Settings { get; init; }

    /// <summary>
    /// 自定义属性
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
