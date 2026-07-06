using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：公开消息更新载荷。
/// </summary>
public sealed record PublicMessageUpdatePayload
{
    /// <summary>
    /// 提交值。
    /// </summary>
    [JsonPropertyName("submitted_values")]
    public IDictionary<string, JsonElement>? SubmittedValues { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
