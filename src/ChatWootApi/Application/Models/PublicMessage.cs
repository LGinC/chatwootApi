using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：公开消息。
/// </summary>
public sealed record PublicMessage
{
    /// <summary>
    /// ID。
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 内容。
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    /// <summary>
    /// 消息类型。
    /// </summary>
    [JsonPropertyName("message_type")]
    public long? MessageType { get; init; }

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
    /// 创建时间。
    /// </summary>
    [JsonPropertyName("created_at")]
    public long? CreatedAt { get; init; }

    /// <summary>
    /// 会话ID。
    /// </summary>
    [JsonPropertyName("conversation_id")]
    public long? ConversationId { get; init; }

    /// <summary>
    /// 附件。
    /// </summary>
    [JsonPropertyName("attachments")]
    public IReadOnlyList<PublicMessageAttachment>? Attachments { get; init; }

    /// <summary>
    /// 发送者。
    /// </summary>
    [JsonPropertyName("sender")]
    public PublicMessageSender? Sender { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
