using System.Text.Json.Serialization;

namespace ChatWootApi.Client;

/// <summary>
/// Chatwoot 客户端模型：消息创建载荷。
/// </summary>
public sealed record MessageCreatePayload
{
    /// <summary>
    /// 内容。
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    /// <summary>
    /// EchoID。
    /// </summary>
    [JsonPropertyName("echo_id")]
    public string? EchoId { get; init; }
}
