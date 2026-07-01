using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record PortalLogo
{
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonPropertyName("portal_id")]
    public long? PortalId { get; init; }

    [JsonPropertyName("file_type")]
    public string? FileType { get; init; }

    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    [JsonPropertyName("file_url")]
    public string? FileUrl { get; init; }

    [JsonPropertyName("blob_id")]
    public long? BlobId { get; init; }

    [JsonPropertyName("filename")]
    public string? Filename { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
