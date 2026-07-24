using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：扩展联系人（swagger <c>extended_contact</c> = contact + id + availability_status）
/// </summary>
public sealed record ExtendedContact : Contact
{
    /// <summary>
    /// 联系人 / 用户 ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 可用性状态
    /// </summary>
    [JsonPropertyName("availability_status")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<AgentAvailability>))]
    public AgentAvailability? AvailabilityStatus { get; init; }
}
