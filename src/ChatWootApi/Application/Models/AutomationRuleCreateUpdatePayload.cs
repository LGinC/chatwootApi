using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：自动化规则创建更新载荷。
/// </summary>
public sealed record AutomationRuleCreateUpdatePayload
{
    /// <summary>
    /// 名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Description。
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// 事件名称。
    /// </summary>
    [JsonPropertyName("event_name")]
    public string? EventName { get; set; }

    /// <summary>
    /// Active。
    /// </summary>
    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    /// <summary>
    /// Actions。
    /// </summary>
    [JsonPropertyName("actions")]
    public IReadOnlyList<IDictionary<string, object>?>? Actions { get; set; }

    /// <summary>
    /// Conditions。
    /// </summary>
    [JsonPropertyName("conditions")]
    public IReadOnlyList<IDictionary<string, object>?>? Conditions { get; set; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object>? ExtensionData { get; set; }
}
