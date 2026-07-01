using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Client;

public sealed record Message
{
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonPropertyName("content")]
    public string? Content { get; init; }

    [JsonPropertyName("message_type")]
    public int? MessageType { get; init; }

    [JsonPropertyName("content_type")]
    public string? ContentType { get; init; }

    [JsonPropertyName("content_attributes")]
    public IDictionary<string, JsonElement>? ContentAttributes { get; init; }

    [JsonPropertyName("created_at")]
    public long? CreatedAt { get; init; }

    [JsonPropertyName("conversation_id")]
    public long? ConversationId { get; init; }

    [JsonPropertyName("attachments")]
    public IReadOnlyList<MessageAttachment>? Attachments { get; init; }

    [JsonPropertyName("sender")]
    public MessageSender? Sender { get; init; }
}
