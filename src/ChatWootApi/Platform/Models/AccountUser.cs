using System.Text.Json.Serialization;
using ChatWootApi.Application.Models;

namespace ChatWootApi.Platform.Models;

/// <summary>
/// Chatwoot 平台模型：账号用户
/// </summary>
public sealed record AccountUser
{
    /// <summary>
    /// 账号ID
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// 用户ID
    /// </summary>
    [JsonPropertyName("user_id")]
    public long? UserId { get; init; }

    /// <summary>
    /// 角色
    /// </summary>
    [JsonPropertyName("role")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<AccountUserRole>))]
    public AccountUserRole? Role { get; init; }
}
