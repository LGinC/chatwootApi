using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：团队
/// </summary>
public sealed record Team
{
    /// <summary>
    /// ID
    /// </summary>
    [JsonPropertyName("id")]
    public decimal? Id { get; init; }

    /// <summary>
    /// 名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Description
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// AllowAutoAssign
    /// </summary>
    [JsonPropertyName("allow_auto_assign")]
    public bool? AllowAutoAssign { get; init; }

    /// <summary>
    /// 账号ID
    /// </summary>
    [JsonPropertyName("account_id")]
    public decimal? AccountId { get; init; }

    /// <summary>
    /// Is成员
    /// </summary>
    [JsonPropertyName("is_member")]
    public bool? IsMember { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
