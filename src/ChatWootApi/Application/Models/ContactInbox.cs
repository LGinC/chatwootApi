using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：联系人收件箱
/// </summary>
public sealed record ContactInbox
{
    /// <summary>
    /// 来源ID
    /// </summary>
    [JsonPropertyName("source_id")]
    public string? SourceId { get; init; }

    /// <summary>
    /// 收件箱
    /// </summary>
    [JsonPropertyName("inbox")]
    public IDictionary<string, JsonElement>? Inbox { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
