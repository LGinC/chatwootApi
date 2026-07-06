using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：会话标签。
/// </summary>
public sealed record ConversationLabels
{
    /// <summary>
    /// 载荷。
    /// </summary>
    [JsonPropertyName("payload")]
    public IReadOnlyList<string?>? Payload { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
