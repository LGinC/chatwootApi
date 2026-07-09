using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：联系人会话消息
/// </summary>
public sealed record ContactConversationMessage
{
    /// <summary>
    /// ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 内容
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    /// <summary>
    /// 账号ID
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// 收件箱ID
    /// </summary>
    [JsonPropertyName("inbox_id")]
    public long? InboxId { get; init; }

    /// <summary>
    /// 会话ID
    /// </summary>
    [JsonPropertyName("conversation_id")]
    public long? ConversationId { get; init; }

    /// <summary>
    /// 消息类型
    /// </summary>
    [JsonPropertyName("message_type")]
    public long? MessageType { get; init; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [JsonPropertyName("created_at")]
    public long? CreatedAt { get; init; }

    /// <summary>
    /// 更新时间
    /// </summary>
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; init; }

    /// <summary>
    /// 私有
    /// </summary>
    [JsonPropertyName("private")]
    public bool? Private { get; init; }

    /// <summary>
    /// 状态
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// 来源ID
    /// </summary>
    [JsonPropertyName("source_id")]
    public string? SourceId { get; init; }

    /// <summary>
    /// 内容类型
    /// </summary>
    [JsonPropertyName("content_type")]
    public string? ContentType { get; init; }

    /// <summary>
    /// 内容属性
    /// </summary>
    [JsonPropertyName("content_attributes")]
    public IDictionary<string, JsonElement>? ContentAttributes { get; init; }

    /// <summary>
    /// 发送者类型
    /// </summary>
    [JsonPropertyName("sender_type")]
    public string? SenderType { get; init; }

    /// <summary>
    /// 发送者ID
    /// </summary>
    [JsonPropertyName("sender_id")]
    public long? SenderId { get; init; }

    /// <summary>
    /// External来源Ids
    /// </summary>
    [JsonPropertyName("external_source_ids")]
    public IDictionary<string, JsonElement>? ExternalSourceIds { get; init; }

    /// <summary>
    /// 附加属性
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    /// <summary>
    /// Processed消息内容
    /// </summary>
    [JsonPropertyName("processed_message_content")]
    public string? ProcessedMessageContent { get; init; }

    /// <summary>
    /// Sentiment
    /// </summary>
    [JsonPropertyName("sentiment")]
    public IDictionary<string, JsonElement>? Sentiment { get; init; }

    /// <summary>
    /// 会话
    /// </summary>
    [JsonPropertyName("conversation")]
    public IDictionary<string, JsonElement>? Conversation { get; init; }

    /// <summary>
    /// 发送者
    /// </summary>
    [JsonPropertyName("sender")]
    public IDictionary<string, JsonElement>? Sender { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
