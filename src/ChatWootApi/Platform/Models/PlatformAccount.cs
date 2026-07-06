using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Platform;

/// <summary>
/// Chatwoot 平台模型：平台账号。
/// </summary>
public sealed record PlatformAccount
{
    /// <summary>
    /// ID。
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
