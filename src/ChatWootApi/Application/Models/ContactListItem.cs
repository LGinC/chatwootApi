using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：联系人列表项目
/// </summary>
public sealed record ContactListItem
{
    /// <summary>
    /// 包含与联系人相关的附加属性的对象
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    /// <summary>
    /// 联系人的空闲状态
    /// </summary>
    [JsonPropertyName("availability_status")]
    public string? AvailabilityStatus { get; init; }

    /// <summary>
    /// 联系人的电子邮件地址
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// 联系人 ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 联系人姓名
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 联系人的电话号码
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; init; }

    /// <summary>
    /// 联系人是否被屏蔽
    /// </summary>
    [JsonPropertyName("blocked")]
    public bool? Blocked { get; init; }

    /// <summary>
    /// 联系人的标识符
    /// </summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }

    /// <summary>
    /// 联系人的缩略图
    /// </summary>
    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; init; }

    /// <summary>
    /// 联系人的自定义属性
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }

    /// <summary>
    /// 上次活动的时间戳
    /// </summary>
    [JsonPropertyName("last_activity_at")]
    public long? LastActivityAt { get; init; }

    /// <summary>
    /// 创建联系人时的时间戳
    /// </summary>
    [JsonPropertyName("created_at")]
    public long? CreatedAt { get; init; }

    /// <summary>
    /// 与此联系人关联的收件箱列表
    /// </summary>
    [JsonPropertyName("contact_inboxes")]
    public IReadOnlyList<ContactInbox>? ContactInboxes { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
