using System.Text.Json;
using System.Text.Json.Serialization;
using ChatWootApi.Platform.Models;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：用户
/// </summary>
public sealed record User
{
    /// <summary>
    /// ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 访问令牌
    /// </summary>
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; init; }

    /// <summary>
    /// 账号ID
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// 可用名称
    /// </summary>
    [JsonPropertyName("available_name")]
    public string? AvailableName { get; init; }

    /// <summary>
    /// 头像URL
    /// </summary>
    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; init; }

    /// <summary>
    /// 已确认
    /// </summary>
    [JsonPropertyName("confirmed")]
    public bool? Confirmed { get; init; }

    /// <summary>
    /// 显示名称
    /// </summary>
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }

    /// <summary>
    /// 消息签名
    /// </summary>
    [JsonPropertyName("message_signature")]
    public string? MessageSignature { get; init; }

    /// <summary>
    /// 邮箱
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// HMAC标识符
    /// </summary>
    [JsonPropertyName("hmac_identifier")]
    public string? HmacIdentifier { get; init; }

    /// <summary>
    /// 邀请人ID
    /// </summary>
    [JsonPropertyName("inviter_id")]
    public long? InviterId { get; init; }

    /// <summary>
    /// 名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 提供者
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; init; }

    /// <summary>
    /// 发布订阅令牌
    /// </summary>
    [JsonPropertyName("pubsub_token")]
    public string? PubsubToken { get; init; }

    /// <summary>
    /// 角色
    /// </summary>
    [JsonPropertyName("role")]
    public string? Role { get; init; }

    /// <summary>
    /// 界面设置
    /// </summary>
    [JsonPropertyName("ui_settings")]
    public IDictionary<string, JsonElement>? UiSettings { get; init; }

    /// <summary>
    /// UID
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; init; }

    /// <summary>
    /// 类型
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// 适用于通过平台 API 创建并具有关联的自定义属性的用户。
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }

    /// <summary>
    /// 账号
    /// </summary>
    [JsonPropertyName("accounts")]
    public IReadOnlyList<UserAccount>? Accounts { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
