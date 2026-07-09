using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：审计日志
/// </summary>
public sealed record AuditLog
{
    /// <summary>
    /// ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// AuditableID
    /// </summary>
    [JsonPropertyName("auditable_id")]
    public long? AuditableId { get; init; }

    /// <summary>
    /// Auditable类型
    /// </summary>
    [JsonPropertyName("auditable_type")]
    public string? AuditableType { get; init; }

    /// <summary>
    /// Auditable
    /// </summary>
    [JsonPropertyName("auditable")]
    public IDictionary<string, JsonElement>? Auditable { get; init; }

    /// <summary>
    /// AssociatedID
    /// </summary>
    [JsonPropertyName("associated_id")]
    public long? AssociatedId { get; init; }

    /// <summary>
    /// Associated类型
    /// </summary>
    [JsonPropertyName("associated_type")]
    public string? AssociatedType { get; init; }

    /// <summary>
    /// 用户ID
    /// </summary>
    [JsonPropertyName("user_id")]
    public long? UserId { get; init; }

    /// <summary>
    /// 用户类型
    /// </summary>
    [JsonPropertyName("user_type")]
    public string? UserType { get; init; }

    /// <summary>
    /// Username
    /// </summary>
    [JsonPropertyName("username")]
    public string? Username { get; init; }

    /// <summary>
    /// Action
    /// </summary>
    [JsonPropertyName("action")]
    public string? Action { get; init; }

    /// <summary>
    /// AuditedChanges
    /// </summary>
    [JsonPropertyName("audited_changes")]
    public IDictionary<string, JsonElement>? AuditedChanges { get; init; }

    /// <summary>
    /// Version
    /// </summary>
    [JsonPropertyName("version")]
    public long? Version { get; init; }

    /// <summary>
    /// Comment
    /// </summary>
    [JsonPropertyName("comment")]
    public string? Comment { get; init; }

    /// <summary>
    /// 请求UUID
    /// </summary>
    [JsonPropertyName("request_uuid")]
    public string? RequestUuid { get; init; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [JsonPropertyName("created_at")]
    public long? CreatedAt { get; init; }

    /// <summary>
    /// RemoteAddress
    /// </summary>
    [JsonPropertyName("remote_address")]
    public string? RemoteAddress { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
