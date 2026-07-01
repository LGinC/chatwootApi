using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Client;

public sealed record MessageAttachment
{
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonPropertyName("message_id")]
    public long? MessageId { get; init; }

    [JsonPropertyName("file_type")]
    public string? FileType { get; init; }

    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    [JsonPropertyName("extension")]
    public string? Extension { get; init; }

    [JsonPropertyName("data_url")]
    public string? DataUrl { get; init; }

    [JsonPropertyName("thumb_url")]
    public string? ThumbUrl { get; init; }

    [JsonPropertyName("file_size")]
    public long? FileSize { get; init; }

    [JsonPropertyName("width")]
    public int? Width { get; init; }

    [JsonPropertyName("height")]
    public int? Height { get; init; }

    [JsonPropertyName("coordinates_lat")]
    public decimal? CoordinatesLat { get; init; }

    [JsonPropertyName("coordinates_long")]
    public decimal? CoordinatesLong { get; init; }

    [JsonPropertyName("fallback_title")]
    public string? FallbackTitle { get; init; }

    [JsonPropertyName("meta")]
    public IDictionary<string, JsonElement>? Meta { get; init; }

    [JsonPropertyName("transcribed_text")]
    public string? TranscribedText { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
