using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：集成钩子创建载荷。
/// </summary>
public sealed record IntegrationsHookCreatePayload
{
    /// <summary>
    /// 正在为其创建集成挂钩的应用程序的 ID
    /// </summary>
    [JsonPropertyName("app_id")]
    public long? AppId { get; set; }

    /// <summary>
    /// 收件箱 ID（如果挂钩是收件箱挂钩）
    /// </summary>
    [JsonPropertyName("inbox_id")]
    public long? InboxId { get; set; }

    /// <summary>
    /// 集成的状态（0 表示不活动，1 表示活动）
    /// </summary>
    [JsonPropertyName("status")]
    public long? Status { get; set; }

    /// <summary>
    /// 集成所需的设置
    /// </summary>
    [JsonPropertyName("settings")]
    public IDictionary<string, object>? Settings { get; set; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object>? ExtensionData { get; set; }
}
