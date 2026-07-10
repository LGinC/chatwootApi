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
    /// 代理的有效可用性状态，源自配置的可用性、自动离线设置和当前状态。要更新代理配置的可用性，请在创建或更新请求中使用可用性字段。
    /// </summary>
    [JsonPropertyName("availability_status")]
    public string? AvailabilityStatus { get; init; }

    /// <summary>
    /// 座席离开时是否自动标记为离线。
    /// </summary>
    [JsonPropertyName("auto_offline")]
    public bool? AutoOffline { get; init; }

    /// <summary>
    /// 代理是否已确认其电子邮件地址。
    /// </summary>
    [JsonPropertyName("confirmed")]
    public bool? Confirmed { get; init; }

    /// <summary>
    /// 代理人的电子邮件
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// 可用的代理名称
    /// </summary>
    [JsonPropertyName("available_name")]
    public string? AvailableName { get; init; }

    /// <summary>
    /// 代理人姓名
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 代理人的角色
    /// </summary>
    [JsonPropertyName("role")]
    public string? Role { get; init; }

    /// <summary>
    /// 代理的缩略图
    /// </summary>
    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; init; }

    /// <summary>
    /// 代理的自定义角色 ID
    /// </summary>
    [JsonPropertyName("custom_role_id")]
    public long? CustomRoleId { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
