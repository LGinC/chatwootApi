using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：会话列表。
/// </summary>
public sealed record ConversationList
{
    /// <summary>
    /// Data。
    /// </summary>
    [JsonPropertyName("data")]
    public IDictionary<string, JsonElement>? Data { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
