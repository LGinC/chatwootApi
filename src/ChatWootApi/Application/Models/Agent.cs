using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：坐席
/// </summary>
public sealed record Agent
{
    /// <summary>
    /// ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 账号ID
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// 可用状态状态
    /// </summary>
    [JsonPropertyName("availability_status")]
    public string? AvailabilityStatus { get; init; }

    /// <summary>
    /// AutoOffline
    /// </summary>
    [JsonPropertyName("auto_offline")]
    public bool? AutoOffline { get; init; }

    /// <summary>
    /// 已确认
    /// </summary>
    [JsonPropertyName("confirmed")]
    public bool? Confirmed { get; init; }

    /// <summary>
    /// 邮箱
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// 可用名称
    /// </summary>
    [JsonPropertyName("available_name")]
    public string? AvailableName { get; init; }

    /// <summary>
    /// 名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 角色
    /// </summary>
    [JsonPropertyName("role")]
    public string? Role { get; init; }

    /// <summary>
    /// 缩略图
    /// </summary>
    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; init; }

    /// <summary>
    /// 自定义角色ID
    /// </summary>
    [JsonPropertyName("custom_role_id")]
    public long? CustomRoleId { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
