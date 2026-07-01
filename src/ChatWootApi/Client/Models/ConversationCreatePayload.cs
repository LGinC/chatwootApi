using System.Text.Json.Serialization;

namespace ChatWootApi.Client;

public sealed record ConversationCreatePayload
{
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, object?>? CustomAttributes { get; init; }
}
