using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record ContactConversationMessage
{
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonPropertyName("content")]
    public string? Content { get; init; }

    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    [JsonPropertyName("inbox_id")]
    public long? InboxId { get; init; }

    [JsonPropertyName("conversation_id")]
    public long? ConversationId { get; init; }

    [JsonPropertyName("message_type")]
    public long? MessageType { get; init; }

    [JsonPropertyName("created_at")]
    public long? CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; init; }

    [JsonPropertyName("private")]
    public bool? Private { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("source_id")]
    public string? SourceId { get; init; }

    [JsonPropertyName("content_type")]
    public string? ContentType { get; init; }

    [JsonPropertyName("content_attributes")]
    public IDictionary<string, JsonElement>? ContentAttributes { get; init; }

    [JsonPropertyName("sender_type")]
    public string? SenderType { get; init; }

    [JsonPropertyName("sender_id")]
    public long? SenderId { get; init; }

    [JsonPropertyName("external_source_ids")]
    public IDictionary<string, JsonElement>? ExternalSourceIds { get; init; }

    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    [JsonPropertyName("processed_message_content")]
    public string? ProcessedMessageContent { get; init; }

    [JsonPropertyName("sentiment")]
    public IDictionary<string, JsonElement>? Sentiment { get; init; }

    [JsonPropertyName("conversation")]
    public IDictionary<string, JsonElement>? Conversation { get; init; }

    [JsonPropertyName("sender")]
    public IDictionary<string, JsonElement>? Sender { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
