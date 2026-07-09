using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：收件箱创建Line渠道载荷
/// </summary>
public sealed record InboxCreateLineChannelPayload
{
    /// <summary>
    /// 类型
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Line渠道ID
    /// </summary>
    [JsonPropertyName("line_channel_id")]
    public string? LineChannelId { get; init; }

    /// <summary>
    /// Line渠道密钥
    /// </summary>
    [JsonPropertyName("line_channel_secret")]
    public string? LineChannelSecret { get; init; }

    /// <summary>
    /// Line渠道令牌
    /// </summary>
    [JsonPropertyName("line_channel_token")]
    public string? LineChannelToken { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
