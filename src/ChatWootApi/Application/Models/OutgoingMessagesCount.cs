using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：外发消息数量分组项
/// </summary>
public sealed record OutgoingMessagesCount
{
    /// <summary>
    /// 分组实体 ID（坐席 / 团队 / 收件箱 / 标签）
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 分组实体名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 时间范围内该实体的外发消息总数
    /// </summary>
    [JsonPropertyName("outgoing_messages_count")]
    public int? Count { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
