using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：收件箱更新Whatsapp渠道载荷
/// </summary>
public sealed record InboxUpdateWhatsappChannelPayload
{
    /// <summary>
    /// 电话号码
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; init; }

    /// <summary>
    /// 提供者
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; init; }

    /// <summary>
    /// 提供者配置
    /// </summary>
    [JsonPropertyName("provider_config")]
    public IDictionary<string, JsonElement>? ProviderConfig { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
