using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record ContactsListResponse
{
    [JsonPropertyName("meta")]
    public ContactMeta? Meta { get; init; }

    [JsonPropertyName("payload")]
    public IReadOnlyList<ContactListItem>? Payload { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
