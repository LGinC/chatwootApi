using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：会话分配载荷。
/// </summary>
public sealed record ConversationAssignmentPayload
{
    /// <summary>
    /// 分配的用户 ID。
    /// </summary>
    [JsonPropertyName("assignee_id")]
    public long? AssigneeId { get; init; }

    /// <summary>
    /// 团队 ID。如果存在 assignee_id，此参数将被忽略。
    /// </summary>
    [JsonPropertyName("team_id")]
    public long? TeamId { get; init; }
}
