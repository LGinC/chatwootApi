using System.Text.Json.Serialization;

namespace ChatWootApi.Client.Models;

/// <summary>
/// Chatwoot 客户端模型：联系人
/// </summary>
public sealed record Contact
{
    /// <summary>
    /// ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 来源ID
    /// </summary>
    [JsonPropertyName("source_id")]
    public string? SourceId { get; init; }

    /// <summary>
    /// 名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 邮箱
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// 电话号码
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; init; }

    /// <summary>
    /// 发布订阅令牌
    /// </summary>
    [JsonPropertyName("pubsub_token")]
    public string? PubsubToken { get; init; }
}
