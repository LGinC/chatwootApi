using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：账号汇总
/// </summary>
public sealed record AccountSummary
{
    /// <summary>
    /// 平均首次响应时间
    /// </summary>
    [JsonPropertyName("avg_first_response_time")]
    public string? AvgFirstResponseTime { get; init; }

    /// <summary>
    /// 平均解决时间
    /// </summary>
    [JsonPropertyName("avg_resolution_time")]
    public string? AvgResolutionTime { get; init; }

    /// <summary>
    /// 会话数量
    /// </summary>
    [JsonPropertyName("conversations_count")]
    public int? ConversationsCount { get; init; }

    /// <summary>
    /// 入站消息数量
    /// </summary>
    [JsonPropertyName("incoming_messages_count")]
    public int? IncomingMessagesCount { get; init; }

    /// <summary>
    /// 外发消息数量
    /// </summary>
    [JsonPropertyName("outgoing_messages_count")]
    public int? OutgoingMessagesCount { get; init; }

    /// <summary>
    /// 解决数量
    /// </summary>
    [JsonPropertyName("resolutions_count")]
    public int? ResolutionsCount { get; init; }

    /// <summary>
    /// 上一周期同结构汇总
    /// </summary>
    [JsonPropertyName("previous")]
    public AccountSummaryMetrics? Previous { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Chatwoot 应用模型：账号汇总指标（与 <see cref="AccountSummary"/> 顶层指标字段相同）
/// </summary>
public sealed record AccountSummaryMetrics
{
    /// <summary>
    /// 平均首次响应时间
    /// </summary>
    [JsonPropertyName("avg_first_response_time")]
    public string? AvgFirstResponseTime { get; init; }

    /// <summary>
    /// 平均解决时间
    /// </summary>
    [JsonPropertyName("avg_resolution_time")]
    public string? AvgResolutionTime { get; init; }

    /// <summary>
    /// 会话数量
    /// </summary>
    [JsonPropertyName("conversations_count")]
    public int? ConversationsCount { get; init; }

    /// <summary>
    /// 入站消息数量
    /// </summary>
    [JsonPropertyName("incoming_messages_count")]
    public int? IncomingMessagesCount { get; init; }

    /// <summary>
    /// 外发消息数量
    /// </summary>
    [JsonPropertyName("outgoing_messages_count")]
    public int? OutgoingMessagesCount { get; init; }

    /// <summary>
    /// 解决数量
    /// </summary>
    [JsonPropertyName("resolutions_count")]
    public int? ResolutionsCount { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
