using System.Text.Json.Serialization;

namespace ChatWootApi.Client;

public sealed record Inbox
{
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    [JsonPropertyName("working_hours")]
    public IReadOnlyList<InboxWorkingHour>? WorkingHours { get; init; }

    [JsonPropertyName("working_hours_enabled")]
    public bool? WorkingHoursEnabled { get; init; }

    [JsonPropertyName("csat_survey_enabled")]
    public bool? CsatSurveyEnabled { get; init; }

    [JsonPropertyName("greeting_enabled")]
    public bool? GreetingEnabled { get; init; }

    [JsonPropertyName("identity_validation_enabled")]
    public bool? IdentityValidationEnabled { get; init; }
}

public sealed record InboxWorkingHour
{
    [JsonPropertyName("day_of_week")]
    public int? DayOfWeek { get; init; }

    [JsonPropertyName("open_all_day")]
    public bool? OpenAllDay { get; init; }

    [JsonPropertyName("closed_all_day")]
    public bool? ClosedAllDay { get; init; }

    [JsonPropertyName("open_hour")]
    public int? OpenHour { get; init; }

    [JsonPropertyName("open_minutes")]
    public int? OpenMinutes { get; init; }

    [JsonPropertyName("close_hour")]
    public int? CloseHour { get; init; }

    [JsonPropertyName("close_minutes")]
    public int? CloseMinutes { get; init; }
}
