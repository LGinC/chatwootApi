using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：门户配置
/// </summary>
public sealed record PortalConfig
{
    /// <summary>
    /// 允许区域设置
    /// </summary>
    [JsonPropertyName("allowed_locales")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? AllowedLocales { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
