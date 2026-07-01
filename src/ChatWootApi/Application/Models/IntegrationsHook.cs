using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record IntegrationsHook
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("app_id")]
    public string? AppId { get; init; }

    [JsonPropertyName("inbox_id")]
    public string? InboxId { get; init; }

    [JsonPropertyName("account_id")]
    public string? AccountId { get; init; }

    [JsonPropertyName("status")]
    public bool? Status { get; init; }

    [JsonPropertyName("hook_type")]
    public bool? HookType { get; init; }

    [JsonPropertyName("settings")]
    public IDictionary<string, JsonElement>? Settings { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
