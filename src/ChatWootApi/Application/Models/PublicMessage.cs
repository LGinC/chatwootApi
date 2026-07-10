using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：公开消息
/// </summary>
public sealed record PublicMessage
{
    /// <summary>
    /// 消息id
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 消息的文本内容。对于仅包含附件的消息可以为 null。
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    /// <summary>
    /// 表示消息类型。可能的值：0（传入）、1（传出）、2（活动）、3（模板）
    /// </summary>
    [JsonPropertyName("message_type")]
    public long? MessageType { get; init; }

    /// <summary>
    /// 消息的内容类型
    /// </summary>
    [JsonPropertyName("content_type")]
    public string? ContentType { get; init; }

    /// <summary>
    /// 消息的附加内容属性
    /// </summary>
    [JsonPropertyName("content_attributes")]
    public IDictionary<string, JsonElement>? ContentAttributes { get; init; }

    /// <summary>
    /// 在消息的 Unix 时间戳处创建
    /// </summary>
    [JsonPropertyName("created_at")]
    public long? CreatedAt { get; init; }

    /// <summary>
    /// 消息所属会话的显示 ID
    /// </summary>
    [JsonPropertyName("conversation_id")]
    public long? ConversationId { get; init; }

    /// <summary>
    /// 附件（如有）
    /// </summary>
    [JsonPropertyName("attachments")]
    public IReadOnlyList<PublicMessageAttachment>? Attachments { get; init; }

    /// <summary>
    /// 发送者
    /// </summary>
    [JsonPropertyName("sender")]
    public PublicMessageSender? Sender { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
