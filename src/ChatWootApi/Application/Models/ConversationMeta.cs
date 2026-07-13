using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：会话元数据
/// </summary>
public sealed record ConversationMeta
{
    /// <summary>
    /// 与对话相关的标签
    /// </summary>
    [JsonPropertyName("labels")]
    public IReadOnlyList<string?>? Labels { get; init; }

    /// <summary>
    /// 对话的附加属性
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    /// <summary>
    /// 联系方式
    /// </summary>
    [JsonPropertyName("contact")]
    public ContactDetail? Contact { get; init; }

    /// <summary>
    /// 分配给对话的代理
    /// </summary>
    [JsonPropertyName("assignee")]
    public Agent? Assignee { get; init; }

    /// <summary>
    /// 客服人员上次看到对话的时间戳
    /// </summary>
    [JsonPropertyName("agent_last_seen_at")]
    public string? AgentLastSeenAt { get; init; }

    /// <summary>
    /// 受让人上次看到对话的时间戳
    /// </summary>
    [JsonPropertyName("assignee_last_seen_at")]
    public string? AssigneeLastSeenAt { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
