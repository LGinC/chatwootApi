using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：门户标志
/// </summary>
public sealed record PortalLogo
{
    /// <summary>
    /// ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 门户ID
    /// </summary>
    [JsonPropertyName("portal_id")]
    public long? PortalId { get; init; }

    /// <summary>
    /// 文件类型
    /// </summary>
    [JsonPropertyName("file_type")]
    public string? FileType { get; init; }

    /// <summary>
    /// 账号ID
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// 文件URL
    /// </summary>
    [JsonPropertyName("file_url")]
    public string? FileUrl { get; init; }

    /// <summary>
    /// BlobID
    /// </summary>
    [JsonPropertyName("blob_id")]
    public long? BlobId { get; init; }

    /// <summary>
    /// Filename
    /// </summary>
    [JsonPropertyName("filename")]
    public string? Filename { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
