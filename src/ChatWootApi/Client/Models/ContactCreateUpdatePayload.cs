using System.Text.Json.Serialization;

namespace ChatWootApi.Client.Models;

/// <summary>
/// Chatwoot 客户端模型：联系人创建更新载荷
/// </summary>
public sealed record ContactCreateUpdatePayload
{
    /// <summary>
    /// 标识符
    /// </summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    /// <summary>
    /// 标识符Hash
    /// </summary>
    [JsonPropertyName("identifier_hash")]
    public string? IdentifierHash { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 电话号码
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    [JsonPropertyName("avatar")]
    public string? Avatar { get; set; }

    /// <summary>
    /// 自定义属性
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, object?>? CustomAttributes { get; set; }
}
