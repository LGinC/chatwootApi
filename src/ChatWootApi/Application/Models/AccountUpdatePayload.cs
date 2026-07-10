using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：账号更新载荷。
/// </summary>
public sealed record AccountUpdatePayload
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
    /// 在指定分钟后自动解决对话
    /// </summary>
    [JsonPropertyName("auto_resolve_after")]
    public long? AutoResolveAfter { get; set; }

    /// <summary>
    /// 自动解析时发送的消息
    /// </summary>
    [JsonPropertyName("auto_resolve_message")]
    public string? AutoResolveMessage { get; set; }

    /// <summary>
    /// 是否忽略自动解析的等待对话
    /// </summary>
    [JsonPropertyName("auto_resolve_ignore_waiting")]
    public bool? AutoResolveIgnoreWaiting { get; set; }

    /// <summary>
    /// 行业类型
    /// </summary>
    [JsonPropertyName("industry")]
    public string? Industry { get; set; }

    /// <summary>
    /// 公司规模
    /// </summary>
    [JsonPropertyName("company_size")]
    public string? CompanySize { get; set; }

    /// <summary>
    /// 账户时区
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object>? ExtensionData { get; set; }
}
