using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：账号更新载荷。
/// </summary>
public sealed record AccountUpdatePayload
{
    /// <summary>
    /// 名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 区域设置。
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; init; }

    /// <summary>
    /// 域名。
    /// </summary>
    [JsonPropertyName("domain")]
    public string? Domain { get; init; }

    /// <summary>
    /// 支持邮箱。
    /// </summary>
    [JsonPropertyName("support_email")]
    public string? SupportEmail { get; init; }

    /// <summary>
    /// AutoResolveAfter。
    /// </summary>
    [JsonPropertyName("auto_resolve_after")]
    public long? AutoResolveAfter { get; init; }

    /// <summary>
    /// AutoResolve消息。
    /// </summary>
    [JsonPropertyName("auto_resolve_message")]
    public string? AutoResolveMessage { get; init; }

    /// <summary>
    /// AutoResolveIgnoreWaiting。
    /// </summary>
    [JsonPropertyName("auto_resolve_ignore_waiting")]
    public bool? AutoResolveIgnoreWaiting { get; init; }

    /// <summary>
    /// Industry。
    /// </summary>
    [JsonPropertyName("industry")]
    public string? Industry { get; init; }

    /// <summary>
    /// CompanySize。
    /// </summary>
    [JsonPropertyName("company_size")]
    public string? CompanySize { get; init; }

    /// <summary>
    /// Timezone。
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
