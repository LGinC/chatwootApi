using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：集成App。
/// </summary>
public sealed record IntegrationsApp
{
    /// <summary>
    /// ID。
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// 名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Description。
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// 钩子类型。
    /// </summary>
    [JsonPropertyName("hook_type")]
    public string? HookType { get; init; }

    /// <summary>
    /// Enabled。
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; init; }

    /// <summary>
    /// AllowMultiple钩子。
    /// </summary>
    [JsonPropertyName("allow_multiple_hooks")]
    public bool? AllowMultipleHooks { get; init; }

    /// <summary>
    /// 钩子。
    /// </summary>
    [JsonPropertyName("hooks")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Hooks { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
