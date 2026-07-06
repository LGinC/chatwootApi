using System.Text.Json.Serialization;

namespace ChatWootApi.Client;

/// <summary>
/// Chatwoot 客户端模型：收件箱。
/// </summary>
public sealed record Inbox
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
    public IReadOnlyList<InboxWorkingHour>? WorkingHours { get; init; }

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
}

/// <summary>
/// Chatwoot 客户端模型：收件箱工作时间。
/// </summary>
public sealed record InboxWorkingHour
{
    /// <summary>
    /// DayWeek。
    /// </summary>
    [JsonPropertyName("day_of_week")]
    public int? DayOfWeek { get; init; }

    /// <summary>
    /// 打开全部Day。
    /// </summary>
    [JsonPropertyName("open_all_day")]
    public bool? OpenAllDay { get; init; }

    /// <summary>
    /// Closed全部Day。
    /// </summary>
    [JsonPropertyName("closed_all_day")]
    public bool? ClosedAllDay { get; init; }

    /// <summary>
    /// 打开时间。
    /// </summary>
    [JsonPropertyName("open_hour")]
    public int? OpenHour { get; init; }

    /// <summary>
    /// 打开Minutes。
    /// </summary>
    [JsonPropertyName("open_minutes")]
    public int? OpenMinutes { get; init; }

    /// <summary>
    /// 关闭时间。
    /// </summary>
    [JsonPropertyName("close_hour")]
    public int? CloseHour { get; init; }

    /// <summary>
    /// 关闭Minutes。
    /// </summary>
    [JsonPropertyName("close_minutes")]
    public int? CloseMinutes { get; init; }
}
