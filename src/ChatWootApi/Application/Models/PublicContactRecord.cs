using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：公开联系人记录。
/// </summary>
public sealed record PublicContactRecord
{
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
    /// 邮箱。
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// 电话号码。
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; init; }

    /// <summary>
    /// 标识符。
    /// </summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }

    /// <summary>
    /// Blocked。
    /// </summary>
    [JsonPropertyName("blocked")]
    public bool? Blocked { get; init; }

    /// <summary>
    /// 附加属性。
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    /// <summary>
    /// 自定义属性。
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }

    /// <summary>
    /// 联系人类型。
    /// </summary>
    [JsonPropertyName("contact_type")]
    public string? ContactType { get; init; }

    /// <summary>
    /// Country代码。
    /// </summary>
    [JsonPropertyName("country_code")]
    public string? CountryCode { get; init; }

    /// <summary>
    /// 最后Activity时间。
    /// </summary>
    [JsonPropertyName("last_activity_at")]
    public string? LastActivityAt { get; init; }

    /// <summary>
    /// 创建时间。
    /// </summary>
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; init; }

    /// <summary>
    /// 更新时间。
    /// </summary>
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; init; }

    /// <summary>
    /// 最后名称。
    /// </summary>
    [JsonPropertyName("last_name")]
    public string? LastName { get; init; }

    /// <summary>
    /// Middle名称。
    /// </summary>
    [JsonPropertyName("middle_name")]
    public string? MiddleName { get; init; }

    /// <summary>
    /// Location。
    /// </summary>
    [JsonPropertyName("location")]
    public string? Location { get; init; }

    /// <summary>
    /// 账号ID。
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// CompanyID。
    /// </summary>
    [JsonPropertyName("company_id")]
    public long? CompanyId { get; init; }

    /// <summary>
    /// 标签列表。
    /// </summary>
    [JsonPropertyName("label_list")]
    public IReadOnlyList<string?>? LabelList { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
