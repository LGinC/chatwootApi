using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：Webhook
/// </summary>
public sealed record Webhook
{
    /// <summary>
    /// Webhook 的 ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 事件将发送到的 url
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; init; }

    /// <summary>
    /// Webhook 的名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 订阅事件列表
    /// </summary>
    [JsonPropertyName("subscriptions")]
    public IReadOnlyList<string?>? Subscriptions { get; init; }

    /// <summary>
    /// 用于签署 Webhook 请求的秘密。签名的 webhook 交付包括“X-Chatwoot-Timestamp”和“X-Chatwoot-Signature”；签名是“sha256=”，后跟使用此密钥的“{timestamp}.{raw_request_body}”的 HMAC-SHA256。当交付 ID 可用时，交付还包括“X-Chatwoot-Delivery”。
    /// </summary>
    [JsonPropertyName("secret")]
    public string? Secret { get; init; }

    /// <summary>
    /// webhook对象所属账户的id
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
