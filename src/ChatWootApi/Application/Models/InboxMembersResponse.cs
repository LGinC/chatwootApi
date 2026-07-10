using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：收件箱坐席响应。
/// </summary>
public sealed record InboxMembersResponse
{
    /// <summary>
    /// 收件箱中的有效坐席列表。
    /// </summary>
    [JsonPropertyName("payload")]
    public IReadOnlyList<Agent>? Payload { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
