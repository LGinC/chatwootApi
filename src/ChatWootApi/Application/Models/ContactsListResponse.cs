using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：联系人列表响应。
/// </summary>
public sealed record ContactsListResponse
{
    /// <summary>
    /// 元数据。
    /// </summary>
    [JsonPropertyName("meta")]
    public ContactMeta? Meta { get; init; }

    /// <summary>
    /// 载荷。
    /// </summary>
    [JsonPropertyName("payload")]
    public IReadOnlyList<ContactListItem>? Payload { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
