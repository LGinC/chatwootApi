using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：收件箱创建Telegram渠道载荷。
/// </summary>
public sealed record InboxCreateTelegramChannelPayload
{
    /// <summary>
    /// 类型。
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// 机器人令牌。
    /// </summary>
    [JsonPropertyName("bot_token")]
    public string? BotToken { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
