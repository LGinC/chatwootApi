using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：联系人基础（swagger <c>contact_base</c> = generic_id + contact）
/// </summary>
public sealed record ContactBase : Contact
{
    /// <summary>
    /// 联系人 ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }
}
