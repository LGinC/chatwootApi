using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：向收件箱添加坐席的请求载荷。
/// </summary>
public sealed record InboxMembersCreatePayload
{
    /// <summary>
    /// 收件箱 ID。
    /// </summary>
    [JsonPropertyName("inbox_id")]
    public long InboxId { get; init; }

    /// <summary>
    /// 要添加到收件箱的用户 ID 列表。
    /// </summary>
    [JsonPropertyName("user_ids")]
    public IReadOnlyList<long> UserIds { get; init; } = [];
}
