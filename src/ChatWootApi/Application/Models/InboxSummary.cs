using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：收件箱汇总报表项
/// </summary>
public sealed record InboxSummary
{
    /// <summary>
    /// 收件箱 ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 日期范围内该收件箱创建的会话数
    /// </summary>
    [JsonPropertyName("conversations_count")]
    public int? ConversationsCount { get; init; }

    /// <summary>
    /// 日期范围内该收件箱解决的会话数
    /// </summary>
    [JsonPropertyName("resolved_conversations_count")]
    public int? ResolvedConversationsCount { get; init; }

    /// <summary>
    /// 平均解决时间（秒）
    /// </summary>
    [JsonPropertyName("avg_resolution_time")]
    public decimal? AvgResolutionTime { get; init; }

    /// <summary>
    /// 平均首次响应时间（秒）
    /// </summary>
    [JsonPropertyName("avg_first_response_time")]
    public decimal? AvgFirstResponseTime { get; init; }

    /// <summary>
    /// 平均回复间隔（秒）
    /// </summary>
    [JsonPropertyName("avg_reply_time")]
    public decimal? AvgReplyTime { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
