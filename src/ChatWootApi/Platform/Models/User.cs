using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Platform;

public sealed record User
{
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonPropertyName("access_token")]
    public string? AccessToken { get; init; }

    [JsonPropertyName("account_id")]
    public long? AccountId { get; init; }

    [JsonPropertyName("available_name")]
    public string? AvailableName { get; init; }

    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; init; }

    [JsonPropertyName("confirmed")]
    public bool? Confirmed { get; init; }

    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }

    [JsonPropertyName("message_signature")]
    public string? MessageSignature { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [JsonPropertyName("hmac_identifier")]
    public string? HmacIdentifier { get; init; }

    [JsonPropertyName("inviter_id")]
    public long? InviterId { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("provider")]
    public string? Provider { get; init; }

    [JsonPropertyName("pubsub_token")]
    public string? PubsubToken { get; init; }

    [JsonPropertyName("role")]
    public string? Role { get; init; }

    [JsonPropertyName("ui_settings")]
    public IDictionary<string, JsonElement>? UiSettings { get; init; }

    [JsonPropertyName("uid")]
    public string? Uid { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }

    [JsonPropertyName("accounts")]
    public IReadOnlyList<UserAccount>? Accounts { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}

public sealed record UserAccount
{
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("active_at")]
    public DateTimeOffset? ActiveAt { get; init; }

    [JsonPropertyName("role")]
    public string? Role { get; init; }

    [JsonPropertyName("permissions")]
    public IReadOnlyList<string>? Permissions { get; init; }

    [JsonPropertyName("availability")]
    public string? Availability { get; init; }

    [JsonPropertyName("availability_status")]
    public string? AvailabilityStatus { get; init; }

    [JsonPropertyName("auto_offline")]
    public bool? AutoOffline { get; init; }

    [JsonPropertyName("custom_role_id")]
    public long? CustomRoleId { get; init; }

    [JsonPropertyName("custom_role")]
    public IDictionary<string, JsonElement>? CustomRole { get; init; }
}
