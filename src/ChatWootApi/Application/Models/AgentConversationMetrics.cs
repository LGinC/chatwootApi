using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：坐席会话指标。
/// </summary>
public sealed record AgentConversationMetrics
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
    /// 邮箱。
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// 缩略图。
    /// </summary>
    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; init; }

    /// <summary>
    /// 可用状态。
    /// </summary>
    [JsonPropertyName("availability")]
    public string? Availability { get; init; }

    /// <summary>
    /// Metric。
    /// </summary>
    [JsonPropertyName("metric")]
    public IDictionary<string, JsonElement>? Metric { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
