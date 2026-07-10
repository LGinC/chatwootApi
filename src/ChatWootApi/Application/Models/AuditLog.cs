using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：审计日志
/// </summary>
public sealed record AuditLog
{
    /// <summary>
    /// 审核日志条目的唯一标识符
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 审计对象ID
    /// </summary>
    [JsonPropertyName("auditable_id")]
    public long? AuditableId { get; init; }

    /// <summary>
    /// 审核对象的类型（例如对话、联系人、用户）
    /// </summary>
    [JsonPropertyName("auditable_type")]
    public string? AuditableType { get; init; }

    /// <summary>
    /// 审核对象数据
    /// </summary>
    [JsonPropertyName("auditable")]
    public IDictionary<string, JsonElement>? Auditable { get; init; }

    /// <summary>
    /// 关联对象的ID（通常是账户ID）
    /// </summary>
    [JsonPropertyName("associated_id")]
    public long? AssociatedId { get; init; }

    /// <summary>
    /// 关联对象的类型
    /// </summary>
    [JsonPropertyName("associated_type")]
    public string? AssociatedType { get; init; }

    /// <summary>
    /// 执行操作的用户的 ID
    /// </summary>
    [JsonPropertyName("user_id")]
    public long? UserId { get; init; }

    /// <summary>
    /// 执行操作的用户类型
    /// </summary>
    [JsonPropertyName("user_type")]
    public string? UserType { get; init; }

    /// <summary>
    /// 执行操作的用户的电子邮件/用户名
    /// </summary>
    [JsonPropertyName("username")]
    public string? Username { get; init; }

    /// <summary>
    /// 对对象执行的操作
    /// </summary>
    [JsonPropertyName("action")]
    public string? Action { get; init; }

    /// <summary>
    /// 包含对审核对象所做的更改的 JSON 对象
    /// </summary>
    [JsonPropertyName("audited_changes")]
    public IDictionary<string, JsonElement>? AuditedChanges { get; init; }

    /// <summary>
    /// 审核日志条目的版本号
    /// </summary>
    [JsonPropertyName("version")]
    public long? Version { get; init; }

    /// <summary>
    /// 与审核日志条目关联的可选注释
    /// </summary>
    [JsonPropertyName("comment")]
    public string? Comment { get; init; }

    /// <summary>
    /// 用于标识生成此审核日志的请求的 UUID
    /// </summary>
    [JsonPropertyName("request_uuid")]
    public string? RequestUuid { get; init; }

    /// <summary>
    /// 创建审核日志条目时的 Unix 时间戳
    /// </summary>
    [JsonPropertyName("created_at")]
    public long? CreatedAt { get; init; }

    /// <summary>
    /// 执行操作的 IP 地址
    /// </summary>
    [JsonPropertyName("remote_address")]
    public string? RemoteAddress { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
