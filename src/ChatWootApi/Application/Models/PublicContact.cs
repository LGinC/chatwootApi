using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：公开联系人。
/// </summary>
public sealed record PublicContact
{
    /// <summary>
    /// ID。
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 来源ID。
    /// </summary>
    [JsonPropertyName("source_id")]
    public string? SourceId { get; init; }

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
    /// 发布订阅令牌。
    /// </summary>
    [JsonPropertyName("pubsub_token")]
    public string? PubsubToken { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
