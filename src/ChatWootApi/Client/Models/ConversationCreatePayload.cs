using System.Text.Json.Serialization;

namespace ChatWootApi.Client.Models;

/// <summary>
/// Chatwoot 客户端模型：会话创建载荷
/// </summary>
public sealed record ConversationCreatePayload
{
    /// <summary>
    /// 自定义属性
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, object?>? CustomAttributes { get; set; }
}
