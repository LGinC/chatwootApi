using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：用户创建更新载荷。
/// </summary>
public sealed record UserCreateUpdatePayload : JsonExtensionDataPayload
{
    /// <summary>
    /// 用户名
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 用户的显示名称
    /// </summary>
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }

    /// <summary>
    /// 用户的电子邮件
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// 密码必须包含大写字母、小写字母、数字和特殊字符
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    /// <summary>
    /// 您想要与用户关联的自定义属性
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, object>? CustomAttributes { get; set; }
}
