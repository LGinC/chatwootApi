using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record ConversationMeta
{
    [JsonPropertyName("labels")]
    public IReadOnlyList<string?>? Labels { get; init; }

    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    [JsonPropertyName("contact")]
    public ContactDetail? Contact { get; init; }

    [JsonPropertyName("assignee")]
    public JsonElement? Assignee { get; init; }

    [JsonPropertyName("agent_last_seen_at")]
    public string? AgentLastSeenAt { get; init; }

    [JsonPropertyName("assignee_last_seen_at")]
    public string? AssigneeLastSeenAt { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
