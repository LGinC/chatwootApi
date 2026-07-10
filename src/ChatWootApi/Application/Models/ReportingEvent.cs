using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：Reporting事件
/// </summary>
public sealed record ReportingEvent
{
    /// <summary>
    /// 上报事件ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 事件名称（例如，first_response、resolve、reply_time）
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 指标值（以秒为单位）
    /// </summary>
    [JsonPropertyName("value")]
    public decimal? Value { get; init; }

    /// <summary>
    /// 指标值（以秒为单位），仅针对工作时间计算
    /// </summary>
    [JsonPropertyName("value_in_business_hours")]
    public decimal? ValueInBusinessHours { get; init; }

    /// <summary>
    /// 事件开始时的时间戳
    /// </summary>
    [JsonPropertyName("event_start_time")]
    public string? EventStartTime { get; init; }

    /// <summary>
    /// 事件结束时的时间戳
    /// </summary>
    [JsonPropertyName("event_end_time")]
    public string? EventEndTime { get; init; }

    /// <summary>
    /// 账户ID
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// 对话ID
    /// </summary>
    [JsonPropertyName("conversation_id")]
    public long? ConversationId { get; init; }

    /// <summary>
    /// 收件箱 ID
    /// </summary>
    [JsonPropertyName("inbox_id")]
    public long? InboxId { get; init; }

    /// <summary>
    /// 用户/代理 ID
    /// </summary>
    [JsonPropertyName("user_id")]
    public long? UserId { get; init; }

    /// <summary>
    /// 上报事件创建时的时间戳
    /// </summary>
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; init; }

    /// <summary>
    /// 报告事件上次更新的时间戳
    /// </summary>
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
