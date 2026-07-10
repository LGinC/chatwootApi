using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：集成钩子
/// </summary>
public sealed record IntegrationsHook
{
    /// <summary>
    /// 集成钩子的ID
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// 集成应用程序的ID
    /// </summary>
    [JsonPropertyName("app_id")]
    public string? AppId { get; init; }

    /// <summary>
    /// 收件箱 ID（如果是收件箱集成）
    /// </summary>
    [JsonPropertyName("inbox_id")]
    public string? InboxId { get; init; }

    /// <summary>
    /// 集成的帐户 ID
    /// </summary>
    [JsonPropertyName("account_id")]
    public string? AccountId { get; init; }

    /// <summary>
    /// 账户是否启用集成钩子
    /// </summary>
    [JsonPropertyName("status")]
    public bool? Status { get; init; }

    /// <summary>
    /// 无论是帐户还是收件箱集成挂钩
    /// </summary>
    [JsonPropertyName("hook_type")]
    public bool? HookType { get; init; }

    /// <summary>
    /// 集成的相关设置
    /// </summary>
    [JsonPropertyName("settings")]
    public IDictionary<string, JsonElement>? Settings { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
