using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：Contactable收件箱响应
/// </summary>
public sealed record ContactableInboxesResponse
{
    /// <summary>
    /// 载荷
    /// </summary>
    [JsonPropertyName("payload")]
    public IReadOnlyList<ContactInbox>? Payload { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
