using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：坐席创建载荷。
/// </summary>
public sealed record AgentCreatePayload : JsonExtensionDataPayload
{
    /// <summary>
    /// 创建空的坐席创建载荷。
    /// </summary>
    public AgentCreatePayload()
    {
    }

    /// <summary>
    /// 创建坐席创建载荷，并将附加字段转换为 JSON 元素。
    /// </summary>
    /// <param name="extensionData">附加 JSON 字段。</param>
    public AgentCreatePayload(IDictionary<string, object>? extensionData)
        : base(extensionData)
    {
    }

    /// <summary>
    /// 代理人全名
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 代理人的电子邮件
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// 无论是管理员还是代理人
    /// </summary>
    [JsonPropertyName("role")]
    public string? Role { get; set; }

    /// <summary>
    /// 代理的已配置可用性。
    /// </summary>
    [JsonPropertyName("availability")]
    public string? Availability { get; set; }

    /// <summary>
    /// 座席离开时是否自动标记为离线。
    /// </summary>
    [JsonPropertyName("auto_offline")]
    public bool? AutoOffline { get; set; }

}
