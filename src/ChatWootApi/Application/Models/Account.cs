using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：账号
/// </summary>
public sealed record Account
{
    /// <summary>
    /// 账户ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 账户名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 帐户中的用户角色
    /// </summary>
    [JsonPropertyName("role")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<AccountUserRole>))]
    public AccountUserRole? Role { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
