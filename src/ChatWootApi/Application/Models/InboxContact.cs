using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：收件箱联系人
/// </summary>
public sealed record InboxContact
{
    /// <summary>
    /// 收件箱 ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 收件箱的头像图片
    /// </summary>
    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; init; }

    /// <summary>
    /// 频道ID
    /// </summary>
    [JsonPropertyName("channel_id")]
    public long? ChannelId { get; init; }

    /// <summary>
    /// 收件箱名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 收件箱类型
    /// </summary>
    [JsonPropertyName("channel_type")]
    public string? ChannelType { get; init; }

    /// <summary>
    /// 收件箱的提供者
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
