using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：预置响应创建更新载荷。
/// </summary>
public sealed record CannedResponseCreateUpdatePayload
{
    /// <summary>
    /// 预设回复的消息内容
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    /// <summary>
    /// 用于快速访问预设回复的短代码
    /// </summary>
    [JsonPropertyName("short_code")]
    public string? ShortCode { get; set; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, object>? ExtensionData { get; set; }
}
