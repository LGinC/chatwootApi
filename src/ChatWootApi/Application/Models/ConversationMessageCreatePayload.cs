using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：会话消息创建载荷。
/// </summary>
public sealed record ConversationMessageCreatePayload
{
    /// <summary>
    /// 内容。
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    /// <summary>
    /// 消息类型。
    /// </summary>
    [JsonPropertyName("message_type")]
    public string? MessageType { get; init; }

    /// <summary>
    /// 私有。
    /// </summary>
    [JsonPropertyName("private")]
    public bool? Private { get; init; }

    /// <summary>
    /// 内容类型。
    /// </summary>
    [JsonPropertyName("content_type")]
    public string? ContentType { get; init; }

    /// <summary>
    /// 内容属性。
    /// </summary>
    [JsonPropertyName("content_attributes")]
    public IDictionary<string, JsonElement>? ContentAttributes { get; init; }

    /// <summary>
    /// CampaignID。
    /// </summary>
    [JsonPropertyName("campaign_id")]
    public long? CampaignId { get; init; }

    /// <summary>
    /// TemplateParams。
    /// </summary>
    [JsonPropertyName("template_params")]
    public IDictionary<string, JsonElement>? TemplateParams { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
