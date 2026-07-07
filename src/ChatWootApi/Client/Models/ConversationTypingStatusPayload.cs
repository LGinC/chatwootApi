using System.Text.Json.Serialization;

namespace ChatWootApi.Client;

/// <summary>
/// Chatwoot 客户端模型：会话输入状态载荷。
/// </summary>
public sealed record ConversationTypingStatusPayload
{
    /// <summary>
    /// 输入状态，on 或 off。
    /// </summary>
    [JsonPropertyName("typing_status")]
    public string? TypingStatus { get; init; }
}
