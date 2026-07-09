using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：账号更新载荷。
/// </summary>
public sealed record AccountUpdatePayload
{
    /// <summary>
    /// 名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 区域设置。
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    /// <summary>
    /// 域名。
    /// </summary>
    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    /// <summary>
    /// 支持邮箱。
    /// </summary>
    [JsonPropertyName("support_email")]
    public string? SupportEmail { get; set; }

    /// <summary>
    /// AutoResolveAfter。
    /// </summary>
    [JsonPropertyName("auto_resolve_after")]
    public long? AutoResolveAfter { get; set; }

    /// <summary>
    /// AutoResolve消息。
    /// </summary>
    [JsonPropertyName("auto_resolve_message")]
    public string? AutoResolveMessage { get; set; }

    /// <summary>
    /// AutoResolveIgnoreWaiting。
    /// </summary>
    [JsonPropertyName("auto_resolve_ignore_waiting")]
    public bool? AutoResolveIgnoreWaiting { get; set; }

    /// <summary>
    /// Industry。
    /// </summary>
    [JsonPropertyName("industry")]
    public string? Industry { get; set; }

    /// <summary>
    /// CompanySize。
    /// </summary>
    [JsonPropertyName("company_size")]
    public string? CompanySize { get; set; }

    /// <summary>
    /// Timezone。
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object>? ExtensionData { get; set; }
}
