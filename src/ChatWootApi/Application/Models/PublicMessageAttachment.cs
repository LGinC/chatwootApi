using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：公开消息附件
/// </summary>
public sealed record PublicMessageAttachment
{
    /// <summary>
    /// 附件 ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 父消息ID
    /// </summary>
    [JsonPropertyName("message_id")]
    public long? MessageId { get; init; }

    /// <summary>
    /// 附件类型
    /// </summary>
    [JsonPropertyName("file_type")]
    public string? FileType { get; init; }

    /// <summary>
    /// 账户id
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// 文件扩展名
    /// </summary>
    [JsonPropertyName("extension")]
    public string? Extension { get; init; }

    /// <summary>
    /// 文件的 URL。当附件变体没有外部 URL 时可以为 null。
    /// </summary>
    [JsonPropertyName("data_url")]
    public string? DataUrl { get; init; }

    /// <summary>
    /// 文件缩略图的 URL
    /// </summary>
    [JsonPropertyName("thumb_url")]
    public string? ThumbUrl { get; init; }

    /// <summary>
    /// 文件大小（以字节为单位）
    /// </summary>
    [JsonPropertyName("file_size")]
    public long? FileSize { get; init; }

    /// <summary>
    /// 可用附件的宽度
    /// </summary>
    [JsonPropertyName("width")]
    public long? Width { get; init; }

    /// <summary>
    /// 可用时附件的高度
    /// </summary>
    [JsonPropertyName("height")]
    public long? Height { get; init; }

    /// <summary>
    /// 位置附件的纬度
    /// </summary>
    [JsonPropertyName("coordinates_lat")]
    public decimal? CoordinatesLat { get; init; }

    /// <summary>
    /// 位置附件的经度
    /// </summary>
    [JsonPropertyName("coordinates_long")]
    public decimal? CoordinatesLong { get; init; }

    /// <summary>
    /// 位置、后备和联系人附件的后备标题（如果可用）
    /// </summary>
    [JsonPropertyName("fallback_title")]
    public string? FallbackTitle { get; init; }

    /// <summary>
    /// 联系人附件的元数据
    /// </summary>
    [JsonPropertyName("meta")]
    public IDictionary<string, JsonElement>? Meta { get; init; }

    /// <summary>
    /// 音频附件的转录文本
    /// </summary>
    [JsonPropertyName("transcribed_text")]
    public string? TranscribedText { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
