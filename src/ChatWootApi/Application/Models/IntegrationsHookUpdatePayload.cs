using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：集成钩子更新载荷。
/// </summary>
public sealed record IntegrationsHookUpdatePayload
{
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
