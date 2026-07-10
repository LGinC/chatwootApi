using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：公开联系人记录
/// </summary>
public sealed record PublicContactRecord
{
    /// <summary>
    /// 联系人 ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 联系人姓名（如有）
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 联系人的电子邮件
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// 联系人的电话号码
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; init; }

    /// <summary>
    /// 联系人的标识符
    /// </summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }

    /// <summary>
    /// 联系人是否被屏蔽
    /// </summary>
    [JsonPropertyName("blocked")]
    public bool? Blocked { get; init; }

    /// <summary>
    /// 联系人存在时的附加属性
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    /// <summary>
    /// 联系人存在时的自定义属性
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }

    /// <summary>
    /// 联系人的联系人类型（如果可用）
    /// </summary>
    [JsonPropertyName("contact_type")]
    public string? ContactType { get; init; }

    /// <summary>
    /// 联系人的国家/地区代码
    /// </summary>
    [JsonPropertyName("country_code")]
    public string? CountryCode { get; init; }

    /// <summary>
    /// ISO 8601 格式的联系人上次活动时间戳
    /// </summary>
    [JsonPropertyName("last_activity_at")]
    public string? LastActivityAt { get; init; }

    /// <summary>
    /// 以 ISO 8601 格式创建联系人时间戳
    /// </summary>
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; init; }

    /// <summary>
    /// 以 ISO 8601 格式更新联系人的时间戳
    /// </summary>
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; init; }

    /// <summary>
    /// 联系人的姓氏
    /// </summary>
    [JsonPropertyName("last_name")]
    public string? LastName { get; init; }

    /// <summary>
    /// 联系人的中间名
    /// </summary>
    [JsonPropertyName("middle_name")]
    public string? MiddleName { get; init; }

    /// <summary>
    /// 联系人的位置
    /// </summary>
    [JsonPropertyName("location")]
    public string? Location { get; init; }

    /// <summary>
    /// 联系人的帐户 ID
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// 联系人的公司 ID
    /// </summary>
    [JsonPropertyName("company_id")]
    public long? CompanyId { get; init; }

    /// <summary>
    /// 应用于联系人的标签
    /// </summary>
    [JsonPropertyName("label_list")]
    public IReadOnlyList<string?>? LabelList { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
