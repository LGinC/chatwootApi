using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record ConversationShow
{
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
