using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：会话分配载荷
/// </summary>
public sealed record ConversationAssignmentPayload
{
    /// <summary>
    /// 分配的用户 ID
    /// </summary>
    [JsonPropertyName("assignee_id")]
    public long? AssigneeId { get; set; }

    /// <summary>
    /// 团队 ID如果存在 assignee_id，此参数将被忽略
    /// </summary>
    [JsonPropertyName("team_id")]
    public long? TeamId { get; set; }
}
