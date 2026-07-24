using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：按渠道分组的首次响应时间分布（键为渠道类型名）
/// </summary>
[JsonConverter(typeof(ChatWootStringKeyedObjectConverter<FirstResponseTimeDistribution, FirstResponseTimeBuckets>))]
public sealed class FirstResponseTimeDistribution : Dictionary<string, FirstResponseTimeBuckets>
{
    /// <summary>
    /// 初始化空的首次响应时间分布。
    /// </summary>
    public FirstResponseTimeDistribution()
        : base(StringComparer.Ordinal)
    {
    }

    /// <summary>
    /// 使用现有条目初始化首次响应时间分布。
    /// </summary>
    public FirstResponseTimeDistribution(IDictionary<string, FirstResponseTimeBuckets> dictionary)
        : base(dictionary, StringComparer.Ordinal)
    {
    }
}

/// <summary>
/// Chatwoot 应用模型：首次响应时间分桶计数
/// </summary>
public sealed record FirstResponseTimeBuckets
{
    /// <summary>
    /// 首次响应时间 &lt; 1 小时的会话数
    /// </summary>
    [JsonPropertyName("0-1h")]
    public int? ZeroToOneHour { get; init; }

    /// <summary>
    /// 首次响应时间 1–4 小时的会话数
    /// </summary>
    [JsonPropertyName("1-4h")]
    public int? OneToFourHours { get; init; }

    /// <summary>
    /// 首次响应时间 4–8 小时的会话数
    /// </summary>
    [JsonPropertyName("4-8h")]
    public int? FourToEightHours { get; init; }

    /// <summary>
    /// 首次响应时间 8–24 小时的会话数
    /// </summary>
    [JsonPropertyName("8-24h")]
    public int? EightToTwentyFourHours { get; init; }

    /// <summary>
    /// 首次响应时间 &gt; 24 小时的会话数
    /// </summary>
    [JsonPropertyName("24h+")]
    public int? OverTwentyFourHours { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
