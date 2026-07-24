using System.Text.Json;
using System.Text.Json.Serialization;
using ChatWootApi.Application.Models;

namespace ChatWootApi.Platform.Models;

/// <summary>
/// Chatwoot 平台模型：账号创建更新载荷
/// </summary>
public sealed record AccountCreateUpdatePayload
{
    /// <summary>
    /// 账户名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 帐户的区域设置
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    /// <summary>
    /// 账户的域名
    /// </summary>
    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    /// <summary>
    /// 帐户的支持电子邮件
    /// </summary>
    [JsonPropertyName("support_email")]
    public string? SupportEmail { get; set; }

    /// <summary>
    /// 账户状态
    /// </summary>
    [JsonPropertyName("status")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<AccountStatus>))]
    public AccountStatus? Status { get; set; }

    /// <summary>
    /// 账户的限制
    /// </summary>
    [JsonPropertyName("limits")]
    public IDictionary<string, object>? Limits { get; set; }

    /// <summary>
    /// 账户的自定义属性
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, object>? CustomAttributes { get; set; }
}
