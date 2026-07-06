using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Platform;

/// <summary>
/// Chatwoot 平台模型：账号创建更新载荷。
/// </summary>
public sealed record AccountCreateUpdatePayload
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
    /// 状态。
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// Limits。
    /// </summary>
    [JsonPropertyName("limits")]
    public IDictionary<string, JsonElement>? Limits { get; init; }

    /// <summary>
    /// 自定义属性。
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }
}
