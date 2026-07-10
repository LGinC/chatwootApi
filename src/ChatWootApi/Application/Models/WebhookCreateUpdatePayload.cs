using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：Webhook创建更新载荷。
/// </summary>
public sealed record WebhookCreateUpdatePayload : JsonExtensionDataPayload
{
    /// <summary>
    /// 应发送事件的 url
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Webhook 的名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 您想要订阅的事件。
    /// </summary>
    [JsonPropertyName("subscriptions")]
    public IReadOnlyList<string?>? Subscriptions { get; set; }
}
