using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：收件箱联系人。
/// </summary>
public sealed record InboxContact
{
    /// <summary>
    /// ID。
    /// </summary>
    [JsonPropertyName("id")]
    public decimal? Id { get; init; }

    /// <summary>
    /// 头像URL。
    /// </summary>
    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; init; }

    /// <summary>
    /// 渠道ID。
    /// </summary>
    [JsonPropertyName("channel_id")]
    public decimal? ChannelId { get; init; }

    /// <summary>
    /// 名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 渠道类型。
    /// </summary>
    [JsonPropertyName("channel_type")]
    public string? ChannelType { get; init; }

    /// <summary>
    /// 提供者。
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
