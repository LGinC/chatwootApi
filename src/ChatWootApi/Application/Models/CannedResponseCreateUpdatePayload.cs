using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：预置响应创建更新载荷。
/// </summary>
public sealed record CannedResponseCreateUpdatePayload
{
    /// <summary>
    /// 内容。
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    /// <summary>
    /// 短代码。
    /// </summary>
    [JsonPropertyName("short_code")]
    public string? ShortCode { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
