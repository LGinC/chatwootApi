using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：公开消息创建载荷
/// </summary>
public sealed record PublicMessageCreatePayload
{
    /// <summary>
    /// 消息内容
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    /// <summary>
    /// 临时标识符将通过 websockets 传回
    /// </summary>
    [JsonPropertyName("echo_id")]
    public string? EchoId { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
