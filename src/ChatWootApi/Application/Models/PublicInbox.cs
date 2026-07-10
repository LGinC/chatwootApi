using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：公开收件箱
/// </summary>
public sealed record PublicInbox
{
    /// <summary>
    /// 收件箱标识符
    /// </summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }

    /// <summary>
    /// 收件箱名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 收件箱中定义的时区
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    /// <summary>
    /// 收件箱中定义的工作时间
    /// </summary>
    [JsonPropertyName("working_hours")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? WorkingHours { get; init; }

    /// <summary>
    /// 收件箱是否启用工作时间
    /// </summary>
    [JsonPropertyName("working_hours_enabled")]
    public bool? WorkingHoursEnabled { get; init; }

    /// <summary>
    /// 收件箱中是否启用客户满意度调查
    /// </summary>
    [JsonPropertyName("csat_survey_enabled")]
    public bool? CsatSurveyEnabled { get; init; }

    /// <summary>
    /// 收件箱是否开启问候语
    /// </summary>
    [JsonPropertyName("greeting_enabled")]
    public bool? GreetingEnabled { get; init; }

    /// <summary>
    /// 收件箱是否强制执行用户身份验证
    /// </summary>
    [JsonPropertyName("identity_validation_enabled")]
    public bool? IdentityValidationEnabled { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
