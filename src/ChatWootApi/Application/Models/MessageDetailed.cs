using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record MessageDetailed
{
    [JsonPropertyName("id")]
    public decimal? Id { get; init; }

    [JsonPropertyName("content")]
    public string? Content { get; init; }

    [JsonPropertyName("inbox_id")]
    public decimal? InboxId { get; init; }

    [JsonPropertyName("conversation_id")]
    public decimal? ConversationId { get; init; }

    [JsonPropertyName("message_type")]
    public long? MessageType { get; init; }

    [JsonPropertyName("content_type")]
    public string? ContentType { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("content_attributes")]
    public IDictionary<string, JsonElement>? ContentAttributes { get; init; }

    [JsonPropertyName("echo_id")]
    public string? EchoId { get; init; }

    [JsonPropertyName("created_at")]
    public long? CreatedAt { get; init; }

    [JsonPropertyName("private")]
    public bool? Private { get; init; }

    [JsonPropertyName("source_id")]
    public string? SourceId { get; init; }

    [JsonPropertyName("sender")]
    public ContactDetail? Sender { get; init; }

    [JsonPropertyName("attachments")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Attachments { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
