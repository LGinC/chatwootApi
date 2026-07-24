using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：坐席更新载荷。
/// </summary>
public sealed record AgentUpdatePayload : JsonExtensionDataPayload
{
    /// <summary>
    /// 无论是管理员还是代理人
    /// </summary>
    [JsonPropertyName("role")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<AccountUserRole>))]
    public AccountUserRole? Role { get; set; }

    /// <summary>
    /// 代理的已配置可用性。
    /// </summary>
    [JsonPropertyName("availability")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<AgentAvailability>))]
    public AgentAvailability? Availability { get; set; }

    /// <summary>
    /// 座席离开时是否自动标记为离线。
    /// </summary>
    [JsonPropertyName("auto_offline")]
    public bool? AutoOffline { get; set; }
}
