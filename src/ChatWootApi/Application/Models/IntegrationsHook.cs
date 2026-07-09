using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：集成钩子
/// </summary>
public sealed record IntegrationsHook
{
    /// <summary>
    /// ID
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// AppID
    /// </summary>
    [JsonPropertyName("app_id")]
    public string? AppId { get; init; }

    /// <summary>
    /// 收件箱ID
    /// </summary>
    [JsonPropertyName("inbox_id")]
    public string? InboxId { get; init; }

    /// <summary>
    /// 账号ID
    /// </summary>
    [JsonPropertyName("account_id")]
    public string? AccountId { get; init; }

    /// <summary>
    /// 状态
    /// </summary>
    [JsonPropertyName("status")]
    public bool? Status { get; init; }

    /// <summary>
    /// 钩子类型
    /// </summary>
    [JsonPropertyName("hook_type")]
    public bool? HookType { get; init; }

    /// <summary>
    /// 设置
    /// </summary>
    [JsonPropertyName("settings")]
    public IDictionary<string, JsonElement>? Settings { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
