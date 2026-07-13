using System.Text.Json;
using System.Text.Json.Serialization;
using ChatWootApi.Client.Models;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：消息
/// </summary>
public sealed record Message
{
    /// <summary>
    /// 消息ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 消息的文本内容
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    /// <summary>
    /// 账户ID
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// 收件箱 ID
    /// </summary>
    [JsonPropertyName("inbox_id")]
    public long? InboxId { get; init; }

    /// <summary>
    /// 对话的ID
    /// </summary>
    [JsonPropertyName("conversation_id")]
    public long? ConversationId { get; init; }

    /// <summary>
    /// 消息类型
    /// </summary>
    [JsonPropertyName("message_type")]
    public long? MessageType { get; init; }

    /// <summary>
    /// 消息创建时间
    /// </summary>
    [JsonPropertyName("created_at")]
    public long? CreatedAt { get; init; }

    /// <summary>
    /// 消息更新时间
    /// </summary>
    [JsonPropertyName("updated_at")]
    public long? UpdatedAt { get; init; }

    /// <summary>
    /// 显示消息是否私有的标志
    /// </summary>
    [JsonPropertyName("private")]
    public bool? Private { get; init; }

    /// <summary>
    /// 消息的状态
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// 消息的源ID
    /// </summary>
    [JsonPropertyName("source_id")]
    public string? SourceId { get; init; }

    /// <summary>
    /// 模板消息类型
    /// </summary>
    [JsonPropertyName("content_type")]
    public string? ContentType { get; init; }

    /// <summary>
    /// 每个 content_type 的内容属性
    /// </summary>
    [JsonPropertyName("content_attributes")]
    public IDictionary<string, JsonElement>? ContentAttributes { get; init; }

    /// <summary>
    /// 发件人类型
    /// </summary>
    [JsonPropertyName("sender_type")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<MessageSenderType>))]
    public MessageSenderType? SenderType { get; init; }

    /// <summary>
    /// 发件人 ID
    /// </summary>
    [JsonPropertyName("sender_id")]
    public long? SenderId { get; init; }

    /// <summary>
    /// 消息的外部源 ID
    /// </summary>
    [JsonPropertyName("external_source_ids")]
    public IDictionary<string, JsonElement>? ExternalSourceIds { get; init; }

    /// <summary>
    /// 消息的附加属性
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    /// <summary>
    /// 处理后的消息内容
    /// </summary>
    [JsonPropertyName("processed_message_content")]
    public string? ProcessedMessageContent { get; init; }

    /// <summary>
    /// 消息中的情绪
    /// </summary>
    [JsonPropertyName("sentiment")]
    public IDictionary<string, JsonElement>? Sentiment { get; init; }

    /// <summary>
    /// 对话对象
    /// </summary>
    [JsonPropertyName("conversation")]
    public Conversation? Conversation { get; init; }

    /// <summary>
    /// 附加到图像的文件对象
    /// </summary>
    [JsonPropertyName("attachment")]
    public MessageAttachment? Attachment { get; init; }

    /// <summary>
    /// 用户/代理/AgentBot 对象
    /// </summary>
    [JsonPropertyName("sender")]
    public MessageSender? Sender { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// 消息发件人类型。
/// </summary>
public enum MessageSenderType
{
    /// <summary>联系人。</summary>
    [JsonStringEnumMemberName("Contact")]
    Contact,

    /// <summary>用户。</summary>
    [JsonStringEnumMemberName("User")]
    User,

    /// <summary>坐席机器人。</summary>
    [JsonStringEnumMemberName("AgentBot")]
    AgentBot,

    /// <summary>Captain 助手。</summary>
    [JsonStringEnumMemberName("Captain::Assistant")]
    CaptainAssistant
}
