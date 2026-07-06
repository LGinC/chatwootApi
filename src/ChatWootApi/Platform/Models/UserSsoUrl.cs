using System.Text.Json.Serialization;

namespace ChatWootApi.Platform;

/// <summary>
/// Chatwoot 平台模型：用户SSOURL。
/// </summary>
public sealed record UserSsoUrl
{
    /// <summary>
    /// URL。
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; init; }
}
