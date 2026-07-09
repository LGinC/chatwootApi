using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：会话元数据
/// </summary>
public sealed record ConversationMeta
{
    /// <summary>
    /// 标签
    /// </summary>
    [JsonPropertyName("labels")]
    public IReadOnlyList<string?>? Labels { get; init; }

    /// <summary>
    /// 附加属性
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    /// <summary>
    /// 联系人
    /// </summary>
    [JsonPropertyName("contact")]
    public ContactDetail? Contact { get; init; }

    /// <summary>
    /// Assignee
    /// </summary>
    [JsonPropertyName("assignee")]
    public JsonElement? Assignee { get; init; }

    /// <summary>
    /// 坐席最后查看时间
    /// </summary>
    [JsonPropertyName("agent_last_seen_at")]
    public string? AgentLastSeenAt { get; init; }

    /// <summary>
    /// Assignee最后查看时间
    /// </summary>
    [JsonPropertyName("assignee_last_seen_at")]
    public string? AssigneeLastSeenAt { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
