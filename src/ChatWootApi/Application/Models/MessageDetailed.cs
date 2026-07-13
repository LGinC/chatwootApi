using System.Text.Json;
using System.Text.Json.Serialization;
using ChatWootApi.Client.Models;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：消息Detailed
/// </summary>
public sealed record MessageDetailed
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
    /// 消息类型（0：传入、1：传出、2：活动、3：模板）
    /// </summary>
    [JsonPropertyName("message_type")]
    public long? MessageType { get; init; }

    /// <summary>
    /// 消息内容的类型
    /// </summary>
    [JsonPropertyName("content_type")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<MessageContentType>))]
    public MessageContentType? ContentType { get; init; }

    /// <summary>
    /// 消息的状态
    /// </summary>
    [JsonPropertyName("status")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<MessageStatus>))]
    public MessageStatus? Status { get; init; }

    /// <summary>
    /// 每个 content_type 的内容属性
    /// </summary>
    [JsonPropertyName("content_attributes")]
    public IDictionary<string, JsonElement>? ContentAttributes { get; init; }

    /// <summary>
    /// 消息的echo ID，用于重复数据删除
    /// </summary>
    [JsonPropertyName("echo_id")]
    public string? EchoId { get; init; }

    /// <summary>
    /// 消息创建时的时间戳
    /// </summary>
    [JsonPropertyName("created_at")]
    public long? CreatedAt { get; init; }

    /// <summary>
    /// 显示消息是否私密的标志
    /// </summary>
    [JsonPropertyName("private")]
    public bool? Private { get; init; }

    /// <summary>
    /// 消息的源ID
    /// </summary>
    [JsonPropertyName("source_id")]
    public string? SourceId { get; init; }

    /// <summary>
    /// 消息的发送者（仅适用于传入消息）
    /// </summary>
    [JsonPropertyName("sender")]
    public ContactDetail? Sender { get; init; }

    /// <summary>
    /// 与邮件关联的附件列表
    /// </summary>
    [JsonPropertyName("attachments")]
    public IReadOnlyList<MessageAttachment>? Attachments { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// 消息状态。
/// </summary>
public enum MessageStatus
{
    /// <summary>已发送。</summary>
    Sent,

    /// <summary>已送达。</summary>
    Delivered,

    /// <summary>已读。</summary>
    Read,

    /// <summary>发送失败。</summary>
    Failed
}

/// <summary>
/// 消息内容类型。
/// </summary>
public enum MessageContentType
{
    /// <summary>文本。</summary>
    [JsonStringEnumMemberName("text")]
    Text,

    /// <summary>单行文本输入。</summary>
    [JsonStringEnumMemberName("input_text")]
    InputText,

    /// <summary>多行文本输入。</summary>
    [JsonStringEnumMemberName("input_textarea")]
    InputTextarea,

    /// <summary>邮箱输入。</summary>
    [JsonStringEnumMemberName("input_email")]
    InputEmail,

    /// <summary>下拉选择输入。</summary>
    [JsonStringEnumMemberName("input_select")]
    InputSelect,

    /// <summary>卡片。</summary>
    [JsonStringEnumMemberName("cards")]
    Cards,

    /// <summary>表单。</summary>
    [JsonStringEnumMemberName("form")]
    Form,

    /// <summary>文章。</summary>
    [JsonStringEnumMemberName("article")]
    Article,

    /// <summary>传入邮件。</summary>
    [JsonStringEnumMemberName("incoming_email")]
    IncomingEmail,

    /// <summary>客户满意度输入。</summary>
    [JsonStringEnumMemberName("input_csat")]
    InputCsat,

    /// <summary>集成。</summary>
    [JsonStringEnumMemberName("integrations")]
    Integrations,

    /// <summary>贴纸。</summary>
    [JsonStringEnumMemberName("sticker")]
    Sticker,

    /// <summary>语音通话。</summary>
    [JsonStringEnumMemberName("voice_call")]
    VoiceCall
}
