using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：自动化规则创建更新载荷。
/// </summary>
public sealed record AutomationRuleCreateUpdatePayload
{
    /// <summary>
    /// 名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Description。
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// 事件名称。
    /// </summary>
    [JsonPropertyName("event_name")]
    public string? EventName { get; init; }

    /// <summary>
    /// Active。
    /// </summary>
    [JsonPropertyName("active")]
    public bool? Active { get; init; }

    /// <summary>
    /// Actions。
    /// </summary>
    [JsonPropertyName("actions")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Actions { get; init; }

    /// <summary>
    /// Conditions。
    /// </summary>
    [JsonPropertyName("conditions")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Conditions { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
