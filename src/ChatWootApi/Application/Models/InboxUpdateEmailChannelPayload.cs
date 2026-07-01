using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

public sealed record InboxUpdateEmailChannelPayload
{
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [JsonPropertyName("imap_enabled")]
    public bool? ImapEnabled { get; init; }

    [JsonPropertyName("imap_login")]
    public string? ImapLogin { get; init; }

    [JsonPropertyName("imap_password")]
    public string? ImapPassword { get; init; }

    [JsonPropertyName("imap_address")]
    public string? ImapAddress { get; init; }

    [JsonPropertyName("imap_port")]
    public long? ImapPort { get; init; }

    [JsonPropertyName("imap_enable_ssl")]
    public bool? ImapEnableSsl { get; init; }

    [JsonPropertyName("imap_authentication")]
    public string? ImapAuthentication { get; init; }

    [JsonPropertyName("smtp_enabled")]
    public bool? SmtpEnabled { get; init; }

    [JsonPropertyName("smtp_login")]
    public string? SmtpLogin { get; init; }

    [JsonPropertyName("smtp_password")]
    public string? SmtpPassword { get; init; }

    [JsonPropertyName("smtp_address")]
    public string? SmtpAddress { get; init; }

    [JsonPropertyName("smtp_port")]
    public long? SmtpPort { get; init; }

    [JsonPropertyName("smtp_domain")]
    public string? SmtpDomain { get; init; }

    [JsonPropertyName("smtp_enable_starttls_auto")]
    public bool? SmtpEnableStarttlsAuto { get; init; }

    [JsonPropertyName("smtp_enable_ssl_tls")]
    public bool? SmtpEnableSslTls { get; init; }

    [JsonPropertyName("smtp_openssl_verify_mode")]
    public string? SmtpOpensslVerifyMode { get; init; }

    [JsonPropertyName("smtp_authentication")]
    public string? SmtpAuthentication { get; init; }

    [JsonPropertyName("provider")]
    public string? Provider { get; init; }

    [JsonPropertyName("verified_for_sending")]
    public bool? VerifiedForSending { get; init; }

    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
