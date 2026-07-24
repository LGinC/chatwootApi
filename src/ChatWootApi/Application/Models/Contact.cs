using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：联系人（swagger <c>contact</c>：payload 为联系人数组）
/// </summary>
public record Contact
{
    /// <summary>
    /// 联系人条目列表
    /// </summary>
    [JsonPropertyName("payload")]
    public IReadOnlyList<ContactListItem>? Payload { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
