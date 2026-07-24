using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：坐席会话指标
/// </summary>
public sealed record AgentConversationMetrics
{
    /// <summary>
    /// ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 邮箱
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// 缩略图
    /// </summary>
    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; init; }

    /// <summary>
    /// 可用状态
    /// </summary>
    [JsonPropertyName("availability")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<AgentAvailability>))]
    public AgentAvailability? Availability { get; init; }

    /// <summary>
    /// 会话计数指标
    /// </summary>
    [JsonPropertyName("metric")]
    public AgentConversationMetricCounts? Metric { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Chatwoot 应用模型：坐席会话计数指标
/// </summary>
public sealed record AgentConversationMetricCounts
{
    /// <summary>
    /// 打开会话数
    /// </summary>
    [JsonPropertyName("open")]
    public int? Open { get; init; }

    /// <summary>
    /// 未处理会话数
    /// </summary>
    [JsonPropertyName("unattended")]
    public int? Unattended { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
