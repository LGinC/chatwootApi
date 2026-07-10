using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：更新或移除收件箱坐席的请求载荷。
/// </summary>
public sealed record InboxMembersUpdatePayload
{
    /// <summary>
    /// 收件箱 ID。
    /// </summary>
    [JsonPropertyName("inbox_id")]
    public string InboxId { get; init; } = string.Empty;

    /// <summary>
    /// 目标用户 ID 列表。
    /// </summary>
    [JsonPropertyName("user_ids")]
    public IReadOnlyList<long> UserIds { get; init; } = [];
}
