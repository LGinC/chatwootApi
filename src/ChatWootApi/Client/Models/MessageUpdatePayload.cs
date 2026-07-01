using System.Text.Json.Serialization;

namespace ChatWootApi.Client;

public sealed record MessageUpdatePayload
{
    [JsonPropertyName("submitted_values")]
    public MessageSubmittedValues? SubmittedValues { get; init; }
}

public sealed record MessageSubmittedValues
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("value")]
    public string? Value { get; init; }

    [JsonPropertyName("csat_survey_response")]
    public CsatSurveyResponse? CsatSurveyResponse { get; init; }
}

public sealed record CsatSurveyResponse
{
    [JsonPropertyName("feedback_message")]
    public string? FeedbackMessage { get; init; }

    [JsonPropertyName("rating")]
    public int? Rating { get; init; }
}
