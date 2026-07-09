using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：集成钩子创建载荷。
/// </summary>
public sealed record IntegrationsHookCreatePayload
{
    /// <summary>
    /// AppID。
    /// </summary>
    [JsonPropertyName("app_id")]
    public long? AppId { get; set; }

    /// <summary>
    /// 收件箱ID。
    /// </summary>
    [JsonPropertyName("inbox_id")]
    public long? InboxId { get; set; }

    /// <summary>
    /// 状态。
    /// </summary>
    [JsonPropertyName("status")]
    public long? Status { get; set; }

    /// <summary>
    /// 设置。
    /// </summary>
    [JsonPropertyName("settings")]
    public IDictionary<string, object>? Settings { get; set; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object>? ExtensionData { get; set; }
}
