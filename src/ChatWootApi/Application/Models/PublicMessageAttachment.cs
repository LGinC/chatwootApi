using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：公开消息附件。
/// </summary>
public sealed record PublicMessageAttachment
{
    /// <summary>
    /// ID。
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 消息ID。
    /// </summary>
    [JsonPropertyName("message_id")]
    public long? MessageId { get; init; }

    /// <summary>
    /// 文件类型。
    /// </summary>
    [JsonPropertyName("file_type")]
    public string? FileType { get; init; }

    /// <summary>
    /// 账号ID。
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// Extension。
    /// </summary>
    [JsonPropertyName("extension")]
    public string? Extension { get; init; }

    /// <summary>
    /// DataURL。
    /// </summary>
    [JsonPropertyName("data_url")]
    public string? DataUrl { get; init; }

    /// <summary>
    /// ThumbURL。
    /// </summary>
    [JsonPropertyName("thumb_url")]
    public string? ThumbUrl { get; init; }

    /// <summary>
    /// 文件Size。
    /// </summary>
    [JsonPropertyName("file_size")]
    public long? FileSize { get; init; }

    /// <summary>
    /// Width。
    /// </summary>
    [JsonPropertyName("width")]
    public long? Width { get; init; }

    /// <summary>
    /// Height。
    /// </summary>
    [JsonPropertyName("height")]
    public long? Height { get; init; }

    /// <summary>
    /// CoordinatesLat。
    /// </summary>
    [JsonPropertyName("coordinates_lat")]
    public decimal? CoordinatesLat { get; init; }

    /// <summary>
    /// CoordinatesLong。
    /// </summary>
    [JsonPropertyName("coordinates_long")]
    public decimal? CoordinatesLong { get; init; }

    /// <summary>
    /// Fallback标题。
    /// </summary>
    [JsonPropertyName("fallback_title")]
    public string? FallbackTitle { get; init; }

    /// <summary>
    /// 元数据。
    /// </summary>
    [JsonPropertyName("meta")]
    public IDictionary<string, JsonElement>? Meta { get; init; }

    /// <summary>
    /// TranscribedText。
    /// </summary>
    [JsonPropertyName("transcribed_text")]
    public string? TranscribedText { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
