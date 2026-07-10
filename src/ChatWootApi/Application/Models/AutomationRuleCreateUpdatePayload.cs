using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：自动化规则创建更新载荷。
/// </summary>
public sealed record AutomationRuleCreateUpdatePayload
{
    /// <summary>
    /// 规则名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 关于自动化和操作的描述
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// 当您想要执行自动化操作时的事件
    /// </summary>
    [JsonPropertyName("event_name")]
    public string? EventName { get; set; }

    /// <summary>
    /// 启用/禁用自动化规则
    /// </summary>
    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    /// <summary>
    /// 条件匹配时要执行的操作数组，例如，如果消息包含内容帮助，则添加标签支持。
    /// </summary>
    [JsonPropertyName("actions")]
    public IReadOnlyList<IDictionary<string, object>?>? Actions { get; set; }

    /// <summary>
    /// 对话过滤器起作用的条件数组，例如消息内容包含文本帮助。
    /// </summary>
    [JsonPropertyName("conditions")]
    public IReadOnlyList<IDictionary<string, object>?>? Conditions { get; set; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object>? ExtensionData { get; set; }
}
