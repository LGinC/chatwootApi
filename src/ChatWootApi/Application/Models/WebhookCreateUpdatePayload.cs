using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：Webhook创建更新载荷。
/// </summary>
public sealed record WebhookCreateUpdatePayload
{
    /// <summary>
    /// URL。
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; init; }

    /// <summary>
    /// 名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Subscriptions。
    /// </summary>
    [JsonPropertyName("subscriptions")]
    public IReadOnlyList<string?>? Subscriptions { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
