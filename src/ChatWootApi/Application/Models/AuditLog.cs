using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record AuditLog
{
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonPropertyName("auditable_id")]
    public long? AuditableId { get; init; }

    [JsonPropertyName("auditable_type")]
    public string? AuditableType { get; init; }

    [JsonPropertyName("auditable")]
    public IDictionary<string, JsonElement>? Auditable { get; init; }

    [JsonPropertyName("associated_id")]
    public long? AssociatedId { get; init; }

    [JsonPropertyName("associated_type")]
    public string? AssociatedType { get; init; }

    [JsonPropertyName("user_id")]
    public long? UserId { get; init; }

    [JsonPropertyName("user_type")]
    public string? UserType { get; init; }

    [JsonPropertyName("username")]
    public string? Username { get; init; }

    [JsonPropertyName("action")]
    public string? Action { get; init; }

    [JsonPropertyName("audited_changes")]
    public IDictionary<string, JsonElement>? AuditedChanges { get; init; }

    [JsonPropertyName("version")]
    public long? Version { get; init; }

    [JsonPropertyName("comment")]
    public string? Comment { get; init; }

    [JsonPropertyName("request_uuid")]
    public string? RequestUuid { get; init; }

    [JsonPropertyName("created_at")]
    public long? CreatedAt { get; init; }

    [JsonPropertyName("remote_address")]
    public string? RemoteAddress { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
