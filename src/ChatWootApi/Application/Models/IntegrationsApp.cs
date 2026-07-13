using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：集成App
/// </summary>
public sealed record IntegrationsApp
{
    /// <summary>
    /// 集成的 ID
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// 集成的名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 关于团队的描述
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// 集成是帐户集成还是收件箱集成
    /// </summary>
    [JsonPropertyName("hook_type")]
    public string? HookType { get; init; }

    /// <summary>
    /// 账户是否启用集成
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; init; }

    /// <summary>
    /// 是否可以创建多个hook进行集成
    /// </summary>
    [JsonPropertyName("allow_multiple_hooks")]
    public bool? AllowMultipleHooks { get; init; }

    /// <summary>
    /// 如果有为此集成创建的任何挂钩
    /// </summary>
    [JsonPropertyName("hooks")]
    public IReadOnlyList<IntegrationsHook>? Hooks { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
