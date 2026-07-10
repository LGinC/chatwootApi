using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：收件箱更新Whatsapp渠道载荷
/// </summary>
public sealed record InboxUpdateWhatsappChannelPayload
{
    /// <summary>
    /// WhatsApp 电话号码
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; init; }

    /// <summary>
    /// WhatsApp 提供商。仅现有已弃用的 360dialog 设置支持“默认”。
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; init; }

    /// <summary>
    /// WhatsApp 提供商配置。云通道使用`api_key`、`phone_number_id`和`business_account_id`；旧版 360dialog 频道使用“api_key”。
    /// </summary>
    [JsonPropertyName("provider_config")]
    public IDictionary<string, JsonElement>? ProviderConfig { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
