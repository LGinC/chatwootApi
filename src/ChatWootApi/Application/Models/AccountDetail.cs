using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：账号详情
/// </summary>
public sealed record AccountDetail
{
    /// <summary>
    /// 账户ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 账户名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 帐户的区域设置
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; init; }

    /// <summary>
    /// 账户的域名
    /// </summary>
    [JsonPropertyName("domain")]
    public string? Domain { get; init; }

    /// <summary>
    /// 帐户的支持电子邮件
    /// </summary>
    [JsonPropertyName("support_email")]
    public string? SupportEmail { get; init; }

    /// <summary>
    /// 账户状态
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// 帐户的创建日期
    /// </summary>
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; init; }

    /// <summary>
    /// 帐户的缓存密钥
    /// </summary>
    [JsonPropertyName("cache_keys")]
    public IDictionary<string, JsonElement>? CacheKeys { get; init; }

    /// <summary>
    /// 为帐户启用的功能
    /// </summary>
    [JsonPropertyName("features")]
    public IDictionary<string, JsonElement>? Features { get; init; }

    /// <summary>
    /// 账户设置
    /// </summary>
    [JsonPropertyName("settings")]
    public IDictionary<string, JsonElement>? Settings { get; init; }

    /// <summary>
    /// 帐户的自定义属性
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
