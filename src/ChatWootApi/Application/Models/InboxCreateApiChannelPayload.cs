using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：收件箱创建API渠道载荷
/// </summary>
public sealed record InboxCreateApiChannelPayload
{
    /// <summary>
    /// 类型
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// API 通道收件箱回调的 Webhook URL
    /// </summary>
    [JsonPropertyName("webhook_url")]
    public string? WebhookUrl { get; init; }

    /// <summary>
    /// 需要对传入的 API 通道消息进行 HMAC 验证
    /// </summary>
    [JsonPropertyName("hmac_mandatory")]
    public bool? HmacMandatory { get; init; }

    /// <summary>
    /// 存储在通过 API 通道创建的联系人上的其他属性
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
