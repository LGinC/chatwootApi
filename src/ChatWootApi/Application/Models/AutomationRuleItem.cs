using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：自动化规则项目。
/// </summary>
public sealed record AutomationRuleItem
{
    /// <summary>
    /// ID。
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 账号ID。
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

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
    /// Conditions。
    /// </summary>
    [JsonPropertyName("conditions")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Conditions { get; init; }

    /// <summary>
    /// Actions。
    /// </summary>
    [JsonPropertyName("actions")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Actions { get; init; }

    /// <summary>
    /// 创建On。
    /// </summary>
    [JsonPropertyName("created_on")]
    public long? CreatedOn { get; init; }

    /// <summary>
    /// Active。
    /// </summary>
    [JsonPropertyName("active")]
    public bool? Active { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
