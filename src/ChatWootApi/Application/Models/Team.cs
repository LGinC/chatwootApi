using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：团队
/// </summary>
public sealed record Team
{
    /// <summary>
    /// 团队ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 团队名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 关于团队的描述
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// 如果开启此设置，系统在将对话分配给团队的同时，会自动将对话分配给团队中的座席
    /// </summary>
    [JsonPropertyName("allow_auto_assign")]
    public bool? AllowAutoAssign { get; init; }

    /// <summary>
    /// 团队帐户的 ID 是以下内容的一部分
    /// </summary>
    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    /// <summary>
    /// 该字段显示当前用户是否是团队的一部分
    /// </summary>
    [JsonPropertyName("is_member")]
    public bool? IsMember { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
