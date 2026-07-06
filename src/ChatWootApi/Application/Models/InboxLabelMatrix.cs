using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用模型：收件箱标签矩阵。
/// </summary>
public sealed record InboxLabelMatrix
{
    /// <summary>
    /// 收件箱。
    /// </summary>
    [JsonPropertyName("inboxes")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Inboxes { get; init; }

    /// <summary>
    /// 标签。
    /// </summary>
    [JsonPropertyName("labels")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Labels { get; init; }

    /// <summary>
    /// 矩阵。
    /// </summary>
    [JsonPropertyName("matrix")]
    public IReadOnlyList<IReadOnlyList<decimal>?>? Matrix { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
