using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：收件箱更新API渠道载荷
/// </summary>
public sealed record InboxUpdateApiChannelPayload
{
    /// <summary>
    /// WebhookURL
    /// </summary>
    [JsonPropertyName("webhook_url")]
    public string? WebhookUrl { get; init; }

    /// <summary>
    /// HMACMandatory
    /// </summary>
    [JsonPropertyName("hmac_mandatory")]
    public bool? HmacMandatory { get; init; }

    /// <summary>
    /// 附加属性
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
