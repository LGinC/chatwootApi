using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：联系人会话响应。
/// </summary>
public sealed record ContactConversationsResponse
{
    /// <summary>
    /// 载荷。
    /// </summary>
    [JsonPropertyName("payload")]
    public IReadOnlyList<JsonElement>? Payload { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
