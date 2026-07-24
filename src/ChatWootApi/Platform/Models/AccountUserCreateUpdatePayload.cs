using System.Text.Json.Serialization;
using ChatWootApi.Application.Models;

namespace ChatWootApi.Platform.Models;

/// <summary>
/// Chatwoot 平台模型：账号用户创建更新载荷
/// </summary>
public sealed record AccountUserCreateUpdatePayload
{
    /// <summary>
    /// 用户ID
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 用户是否是管理员或代理
    /// </summary>
    [JsonPropertyName("role")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<AccountUserRole>))]
    public AccountUserRole Role { get; set; }
}
