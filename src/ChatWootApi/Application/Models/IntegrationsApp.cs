using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record IntegrationsApp
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("hook_type")]
    public string? HookType { get; init; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; init; }

    [JsonPropertyName("allow_multiple_hooks")]
    public bool? AllowMultipleHooks { get; init; }

    [JsonPropertyName("hooks")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Hooks { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
