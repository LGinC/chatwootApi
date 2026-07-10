using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：集成钩子更新载荷。
/// </summary>
public sealed record IntegrationsHookUpdatePayload : JsonExtensionDataPayload
{
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
}
