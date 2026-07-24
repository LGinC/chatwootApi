using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：按渠道类型分组的会话状态统计（键为渠道类型名）
/// </summary>
[JsonConverter(typeof(ChatWootStringKeyedObjectConverter<ChannelSummary, ChannelConversationStatusCounts>))]
public sealed class ChannelSummary : Dictionary<string, ChannelConversationStatusCounts>
{
    /// <summary>
    /// 初始化空的渠道汇总。
    /// </summary>
    public ChannelSummary()
        : base(StringComparer.Ordinal)
    {
    }

    /// <summary>
    /// 使用现有条目初始化渠道汇总。
    /// </summary>
    public ChannelSummary(IDictionary<string, ChannelConversationStatusCounts> dictionary)
        : base(dictionary, StringComparer.Ordinal)
    {
    }
}

/// <summary>
/// Chatwoot 应用模型：某一渠道类型的会话状态计数
/// </summary>
public sealed record ChannelConversationStatusCounts
{
    /// <summary>
    /// 打开会话数
    /// </summary>
    [JsonPropertyName("open")]
    public int? Open { get; init; }

    /// <summary>
    /// 已解决会话数
    /// </summary>
    [JsonPropertyName("resolved")]
    public int? Resolved { get; init; }

    /// <summary>
    /// 待处理会话数
    /// </summary>
    [JsonPropertyName("pending")]
    public int? Pending { get; init; }

    /// <summary>
    /// 休眠会话数
    /// </summary>
    [JsonPropertyName("snoozed")]
    public int? Snoozed { get; init; }

    /// <summary>
    /// 总会话数
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
