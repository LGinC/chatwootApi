using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record AutomationRuleCreateUpdatePayload
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("event_name")]
    public string? EventName { get; init; }

    [JsonPropertyName("active")]
    public bool? Active { get; init; }

    [JsonPropertyName("actions")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Actions { get; init; }

    [JsonPropertyName("conditions")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Conditions { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
