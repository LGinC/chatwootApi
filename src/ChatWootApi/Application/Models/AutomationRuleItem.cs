using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：自动化规则项目
/// </summary>
public sealed record AutomationRuleItem
{
    /// <summary>
    /// 自动化规则的ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 账户编号
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// 规则名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 提供有关规则的更多背景信息的描述
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// 自动化规则事件，我们在其上调用操作（conversation_created、conversation_updated、message_created）
    /// </summary>
    [JsonPropertyName("event_name")]
    public string? EventName { get; init; }

    /// <summary>
    /// 对话/消息过滤器起作用的条件数组
    /// </summary>
    [JsonPropertyName("conditions")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Conditions { get; init; }

    /// <summary>
    /// 当条件匹配时我们执行的操作数组
    /// </summary>
    [JsonPropertyName("actions")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Actions { get; init; }

    /// <summary>
    /// 创建规则时的时间戳
    /// </summary>
    [JsonPropertyName("created_on")]
    public long? CreatedOn { get; init; }

    /// <summary>
    /// 启用/禁用自动化规则
    /// </summary>
    [JsonPropertyName("active")]
    public bool? Active { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
