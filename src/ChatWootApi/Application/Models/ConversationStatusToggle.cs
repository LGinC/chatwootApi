using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：会话状态Toggle。
/// </summary>
public sealed record ConversationStatusToggle
{
    /// <summary>
    /// 元数据。
    /// </summary>
    [JsonPropertyName("meta")]
    public IDictionary<string, JsonElement>? Meta { get; init; }

    /// <summary>
    /// 载荷。
    /// </summary>
    [JsonPropertyName("payload")]
    public IDictionary<string, JsonElement>? Payload { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
