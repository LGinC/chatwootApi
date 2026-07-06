using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：消息Detailed。
/// </summary>
public sealed record MessageDetailed
{
    /// <summary>
    /// ID。
    /// </summary>
    [JsonPropertyName("id")]
    public decimal? Id { get; init; }

    /// <summary>
    /// 内容。
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    /// <summary>
    /// 收件箱ID。
    /// </summary>
    [JsonPropertyName("inbox_id")]
    public decimal? InboxId { get; init; }

    /// <summary>
    /// 会话ID。
    /// </summary>
    [JsonPropertyName("conversation_id")]
    public decimal? ConversationId { get; init; }

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
    /// 状态。
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// 内容属性。
    /// </summary>
    [JsonPropertyName("content_attributes")]
    public IDictionary<string, JsonElement>? ContentAttributes { get; init; }

    /// <summary>
    /// EchoID。
    /// </summary>
    [JsonPropertyName("echo_id")]
    public string? EchoId { get; init; }

    /// <summary>
    /// 创建时间。
    /// </summary>
    [JsonPropertyName("created_at")]
    public long? CreatedAt { get; init; }

    /// <summary>
    /// 私有。
    /// </summary>
    [JsonPropertyName("private")]
    public bool? Private { get; init; }

    /// <summary>
    /// 来源ID。
    /// </summary>
    [JsonPropertyName("source_id")]
    public string? SourceId { get; init; }

    /// <summary>
    /// 发送者。
    /// </summary>
    [JsonPropertyName("sender")]
    public ContactDetail? Sender { get; init; }

    /// <summary>
    /// 附件。
    /// </summary>
    [JsonPropertyName("attachments")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Attachments { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
