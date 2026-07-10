using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：门户标志
/// </summary>
public sealed record PortalLogo
{
    /// <summary>
    /// 徽标文件的 ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 该徽标所属门户的 ID
    /// </summary>
    [JsonPropertyName("portal_id")]
    public long? PortalId { get; init; }

    /// <summary>
    /// 文件的 MIME 类型
    /// </summary>
    [JsonPropertyName("file_type")]
    public string? FileType { get; init; }

    /// <summary>
    /// 账户ID
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// 访问徽标文件的 URL
    /// </summary>
    [JsonPropertyName("file_url")]
    public string? FileUrl { get; init; }

    /// <summary>
    /// 斑点的 ID
    /// </summary>
    [JsonPropertyName("blob_id")]
    public long? BlobId { get; init; }

    /// <summary>
    /// 文件名
    /// </summary>
    [JsonPropertyName("filename")]
    public string? Filename { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
