using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：公开会话创建载荷。
/// </summary>
public sealed record PublicConversationCreatePayload
{
    /// <summary>
    /// 自定义属性。
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
