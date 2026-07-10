using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：账号详情响应
/// </summary>
public sealed record AccountShowResponse
{
    /// <summary>
    /// Chatwoot 可用的最新版本
    /// </summary>
    [JsonPropertyName("latest_chatwoot_version")]
    public string? LatestChatwootVersion { get; init; }

    /// <summary>
    /// 已订阅的企业版功能列表
    /// </summary>
    [JsonPropertyName("subscribed_features")]
    public IReadOnlyList<string>? SubscribedFeatures { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
