using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record PublicInbox
{
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    [JsonPropertyName("working_hours")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? WorkingHours { get; init; }

    [JsonPropertyName("working_hours_enabled")]
    public bool? WorkingHoursEnabled { get; init; }

    [JsonPropertyName("csat_survey_enabled")]
    public bool? CsatSurveyEnabled { get; init; }

    [JsonPropertyName("greeting_enabled")]
    public bool? GreetingEnabled { get; init; }

    [JsonPropertyName("identity_validation_enabled")]
    public bool? IdentityValidationEnabled { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
