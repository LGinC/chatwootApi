using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：账号用户创建更新载荷。
/// </summary>
public sealed record AccountUserCreateUpdatePayload : JsonExtensionDataPayload
{
    /// <summary>
    /// 用户ID
    /// </summary>
    [JsonPropertyName("user_id")]
    public long? UserId { get; set; }

    /// <summary>
    /// 用户是否是管理员或代理
    /// </summary>
    [JsonPropertyName("role")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<AccountUserRole>))]
    public AccountUserRole? Role { get; set; }
}
