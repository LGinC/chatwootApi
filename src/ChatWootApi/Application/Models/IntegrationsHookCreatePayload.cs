using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：集成钩子创建载荷。
/// </summary>
public sealed record IntegrationsHookCreatePayload
{
    /// <summary>
    /// AppID。
    /// </summary>
    [JsonPropertyName("app_id")]
    public long? AppId { get; init; }

    /// <summary>
    /// 收件箱ID。
    /// </summary>
    [JsonPropertyName("inbox_id")]
    public long? InboxId { get; init; }

    /// <summary>
    /// 状态。
    /// </summary>
    [JsonPropertyName("status")]
    public long? Status { get; init; }

    /// <summary>
    /// 设置。
    /// </summary>
    [JsonPropertyName("settings")]
    public IDictionary<string, JsonElement>? Settings { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
