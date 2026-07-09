using System.Text.Json.Serialization;

namespace ChatWootApi.Client.Models;

/// <summary>
/// Chatwoot 客户端模型：消息更新载荷
/// </summary>
public sealed record MessageUpdatePayload
{
    /// <summary>
    /// 提交值
    /// </summary>
    [JsonPropertyName("submitted_values")]
    public MessageSubmittedValues? SubmittedValues { get; set; }
}

/// <summary>
/// Chatwoot 客户端模型：消息提交值
/// </summary>
public sealed record MessageSubmittedValues
{
    /// <summary>
    /// 名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// 值
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    /// <summary>
    /// CSAT调查响应
    /// </summary>
    [JsonPropertyName("csat_survey_response")]
    public CsatSurveyResponse? CsatSurveyResponse { get; set; }
}

/// <summary>
/// Chatwoot 客户端模型：CSAT调查响应
/// </summary>
public sealed record CsatSurveyResponse
{
    /// <summary>
    /// 反馈消息
    /// </summary>
    [JsonPropertyName("feedback_message")]
    public string? FeedbackMessage { get; set; }

    /// <summary>
    /// 评分
    /// </summary>
    [JsonPropertyName("rating")]
    public int? Rating { get; set; }
}
