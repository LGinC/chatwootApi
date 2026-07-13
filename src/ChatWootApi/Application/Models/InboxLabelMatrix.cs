using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：收件箱标签矩阵
/// </summary>
public sealed record InboxLabelMatrix
{
    /// <summary>
    /// 报告中包含的收件箱列表
    /// </summary>
    [JsonPropertyName("inboxes")]
    public IReadOnlyList<InboxLabelMatrixInbox>? Inboxes { get; init; }

    /// <summary>
    /// 报告中包含的标签列表
    /// </summary>
    [JsonPropertyName("labels")]
    public IReadOnlyList<Label>? Labels { get; init; }

    /// <summary>
    /// 二维数组，其中矩阵 [i] [j] 表示收件箱 [i] 中带有标签 [j] 的对话计数
    /// </summary>
    [JsonPropertyName("matrix")]
    public IReadOnlyList<IReadOnlyList<long>?>? Matrix { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// 收件箱标签矩阵报表中的收件箱
/// </summary>
public sealed record InboxLabelMatrixInbox
{
    /// <summary>
    /// 收件箱 ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 收件箱名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 文档未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
