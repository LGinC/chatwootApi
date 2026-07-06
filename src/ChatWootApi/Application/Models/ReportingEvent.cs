using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：Reporting事件。
/// </summary>
public sealed record ReportingEvent
{
    /// <summary>
    /// ID。
    /// </summary>
    [JsonPropertyName("id")]
    public decimal? Id { get; init; }

    /// <summary>
    /// 名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 值。
    /// </summary>
    [JsonPropertyName("value")]
    public decimal? Value { get; init; }

    /// <summary>
    /// 值Business时间。
    /// </summary>
    [JsonPropertyName("value_in_business_hours")]
    public decimal? ValueInBusinessHours { get; init; }

    /// <summary>
    /// 事件Start时间。
    /// </summary>
    [JsonPropertyName("event_start_time")]
    public string? EventStartTime { get; init; }

    /// <summary>
    /// 事件End时间。
    /// </summary>
    [JsonPropertyName("event_end_time")]
    public string? EventEndTime { get; init; }

    /// <summary>
    /// 账号ID。
    /// </summary>
    [JsonPropertyName("account_id")]
    public decimal? AccountId { get; init; }

    /// <summary>
    /// 会话ID。
    /// </summary>
    [JsonPropertyName("conversation_id")]
    public decimal? ConversationId { get; init; }

    /// <summary>
    /// 收件箱ID。
    /// </summary>
    [JsonPropertyName("inbox_id")]
    public decimal? InboxId { get; init; }

    /// <summary>
    /// 用户ID。
    /// </summary>
    [JsonPropertyName("user_id")]
    public decimal? UserId { get; init; }

    /// <summary>
    /// 创建时间。
    /// </summary>
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; init; }

    /// <summary>
    /// 更新时间。
    /// </summary>
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
