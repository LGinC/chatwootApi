using System.Text.Json.Serialization;

namespace ChatWootApi.Platform;

/// <summary>
/// Chatwoot 平台模型：账号用户创建更新载荷。
/// </summary>
public sealed record AccountUserCreateUpdatePayload
{
    /// <summary>
    /// 用户ID。
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; init; }

    /// <summary>
    /// 角色。
    /// </summary>
    [JsonPropertyName("role")]
    public string Role { get; init; } = string.Empty;
}
