using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：公开消息发送者
/// </summary>
public sealed record PublicMessageSender
{
    /// <summary>
    /// 发件人 ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 发件人姓名（如果有）
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 发件人的头像 URL。适用于 user、agent_bot 和 Captain_assistant 类型的发件人。对于联系人发件人不存在（请改用缩略图）。
    /// </summary>
    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; init; }

    /// <summary>
    /// 发件人的头像/缩略图 URL。联系发件人使用此字段；用户发件人也可能包含它。
    /// </summary>
    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; init; }

    /// <summary>
    /// 发件人类型
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// 用户发件人的显示名称
    /// </summary>
    [JsonPropertyName("available_name")]
    public string? AvailableName { get; init; }

    /// <summary>
    /// 用户发件人的可用性状态
    /// </summary>
    [JsonPropertyName("availability_status")]
    public string? AvailabilityStatus { get; init; }

    /// <summary>
    /// 当发件人是联系人时，发件人的电子邮件
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// 当发件人是联系人时，发件人的电话号码
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; init; }

    /// <summary>
    /// 当发件人是联系人时发件人的标识符
    /// </summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }

    /// <summary>
    /// 当发件人是联系人时是否阻止发件人
    /// </summary>
    [JsonPropertyName("blocked")]
    public bool? Blocked { get; init; }

    /// <summary>
    /// 当发件人是联系人并且有空时的附加属性
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    /// <summary>
    /// 当发件人是联系人并且有空时的自定义属性
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }

    /// <summary>
    /// 发送者为队长助理时的描述
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// 当发送者是队长助理时，创建 ISO 8601 格式的时间戳
    /// </summary>
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
