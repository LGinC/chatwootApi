using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record PortalConfig
{
    [JsonPropertyName("allowed_locales")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? AllowedLocales { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
