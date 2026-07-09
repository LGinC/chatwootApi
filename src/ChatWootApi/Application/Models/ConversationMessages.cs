using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：会话消息
/// </summary>
public sealed record ConversationMessages
{
    /// <summary>
    /// 元数据
    /// </summary>
    [JsonPropertyName("meta")]
    public ConversationMeta? Meta { get; init; }

    /// <summary>
    /// 载荷
    /// </summary>
    [JsonPropertyName("payload")]
    public IReadOnlyList<MessageDetailed>? Payload { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
