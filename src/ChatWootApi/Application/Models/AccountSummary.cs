using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：账号汇总
/// </summary>
public sealed record AccountSummary
{
    /// <summary>
    /// Avg首次响应时间
    /// </summary>
    [JsonPropertyName("avg_first_response_time")]
    public string? AvgFirstResponseTime { get; init; }

    /// <summary>
    /// AvgResolution时间
    /// </summary>
    [JsonPropertyName("avg_resolution_time")]
    public string? AvgResolutionTime { get; init; }

    /// <summary>
    /// 会话数量
    /// </summary>
    [JsonPropertyName("conversations_count")]
    public decimal? ConversationsCount { get; init; }

    /// <summary>
    /// Incoming消息数量
    /// </summary>
    [JsonPropertyName("incoming_messages_count")]
    public decimal? IncomingMessagesCount { get; init; }

    /// <summary>
    /// 外发消息数量
    /// </summary>
    [JsonPropertyName("outgoing_messages_count")]
    public decimal? OutgoingMessagesCount { get; init; }

    /// <summary>
    /// Resolutions数量
    /// </summary>
    [JsonPropertyName("resolutions_count")]
    public decimal? ResolutionsCount { get; init; }

    /// <summary>
    /// Previous
    /// </summary>
    [JsonPropertyName("previous")]
    public IDictionary<string, JsonElement>? Previous { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
