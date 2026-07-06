using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：联系人列表项目。
/// </summary>
public sealed record ContactListItem
{
    /// <summary>
    /// 附加属性。
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    /// <summary>
    /// 可用状态状态。
    /// </summary>
    [JsonPropertyName("availability_status")]
    public string? AvailabilityStatus { get; init; }

    /// <summary>
    /// 邮箱。
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// ID。
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 电话号码。
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; init; }

    /// <summary>
    /// Blocked。
    /// </summary>
    [JsonPropertyName("blocked")]
    public bool? Blocked { get; init; }

    /// <summary>
    /// 标识符。
    /// </summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }

    /// <summary>
    /// 缩略图。
    /// </summary>
    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; init; }

    /// <summary>
    /// 自定义属性。
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }

    /// <summary>
    /// 最后Activity时间。
    /// </summary>
    [JsonPropertyName("last_activity_at")]
    public long? LastActivityAt { get; init; }

    /// <summary>
    /// 创建时间。
    /// </summary>
    [JsonPropertyName("created_at")]
    public long? CreatedAt { get; init; }

    /// <summary>
    /// 联系人收件箱。
    /// </summary>
    [JsonPropertyName("contact_inboxes")]
    public IReadOnlyList<ContactInbox>? ContactInboxes { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
