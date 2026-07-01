using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record PublicMessage
{
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonPropertyName("content")]
    public string? Content { get; init; }

    [JsonPropertyName("message_type")]
    public long? MessageType { get; init; }

    [JsonPropertyName("content_type")]
    public string? ContentType { get; init; }

    [JsonPropertyName("content_attributes")]
    public IDictionary<string, JsonElement>? ContentAttributes { get; init; }

    [JsonPropertyName("created_at")]
    public long? CreatedAt { get; init; }

    [JsonPropertyName("conversation_id")]
    public long? ConversationId { get; init; }

    [JsonPropertyName("attachments")]
    public IReadOnlyList<PublicMessageAttachment>? Attachments { get; init; }

    [JsonPropertyName("sender")]
    public PublicMessageSender? Sender { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
