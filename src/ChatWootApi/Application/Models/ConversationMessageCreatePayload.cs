using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record ConversationMessageCreatePayload
{
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    [JsonPropertyName("message_type")]
    public string? MessageType { get; init; }

    [JsonPropertyName("private")]
    public bool? Private { get; init; }

    [JsonPropertyName("content_type")]
    public string? ContentType { get; init; }

    [JsonPropertyName("content_attributes")]
    public IDictionary<string, JsonElement>? ContentAttributes { get; init; }

    [JsonPropertyName("campaign_id")]
    public long? CampaignId { get; init; }

    [JsonPropertyName("template_params")]
    public IDictionary<string, JsonElement>? TemplateParams { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
