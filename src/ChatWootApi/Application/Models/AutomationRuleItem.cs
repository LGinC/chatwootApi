using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record AutomationRuleItem
{
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("event_name")]
    public string? EventName { get; init; }

    [JsonPropertyName("conditions")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Conditions { get; init; }

    [JsonPropertyName("actions")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Actions { get; init; }

    [JsonPropertyName("created_on")]
    public long? CreatedOn { get; init; }

    [JsonPropertyName("active")]
    public bool? Active { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
