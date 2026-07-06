using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：公开收件箱。
/// </summary>
public sealed record PublicInbox
{
    /// <summary>
    /// 标识符。
    /// </summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }

    /// <summary>
    /// 名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Timezone。
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    /// <summary>
    /// 工作时间。
    /// </summary>
    [JsonPropertyName("working_hours")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? WorkingHours { get; init; }

    /// <summary>
    /// 工作时间Enabled。
    /// </summary>
    [JsonPropertyName("working_hours_enabled")]
    public bool? WorkingHoursEnabled { get; init; }

    /// <summary>
    /// CSAT调查Enabled。
    /// </summary>
    [JsonPropertyName("csat_survey_enabled")]
    public bool? CsatSurveyEnabled { get; init; }

    /// <summary>
    /// GreetingEnabled。
    /// </summary>
    [JsonPropertyName("greeting_enabled")]
    public bool? GreetingEnabled { get; init; }

    /// <summary>
    /// IdentityValidationEnabled。
    /// </summary>
    [JsonPropertyName("identity_validation_enabled")]
    public bool? IdentityValidationEnabled { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
