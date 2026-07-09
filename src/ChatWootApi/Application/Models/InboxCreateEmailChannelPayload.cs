using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：收件箱创建邮箱渠道载荷
/// </summary>
public sealed record InboxCreateEmailChannelPayload
{
    /// <summary>
    /// 类型
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// 邮箱
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// ImapEnabled
    /// </summary>
    [JsonPropertyName("imap_enabled")]
    public bool? ImapEnabled { get; init; }

    /// <summary>
    /// ImapLogin
    /// </summary>
    [JsonPropertyName("imap_login")]
    public string? ImapLogin { get; init; }

    /// <summary>
    /// Imap密码
    /// </summary>
    [JsonPropertyName("imap_password")]
    public string? ImapPassword { get; init; }

    /// <summary>
    /// ImapAddress
    /// </summary>
    [JsonPropertyName("imap_address")]
    public string? ImapAddress { get; init; }

    /// <summary>
    /// ImapPort
    /// </summary>
    [JsonPropertyName("imap_port")]
    public long? ImapPort { get; init; }

    /// <summary>
    /// ImapEnableSsl
    /// </summary>
    [JsonPropertyName("imap_enable_ssl")]
    public bool? ImapEnableSsl { get; init; }

    /// <summary>
    /// ImapAuthentication
    /// </summary>
    [JsonPropertyName("imap_authentication")]
    public string? ImapAuthentication { get; init; }

    /// <summary>
    /// SmtpEnabled
    /// </summary>
    [JsonPropertyName("smtp_enabled")]
    public bool? SmtpEnabled { get; init; }

    /// <summary>
    /// SmtpLogin
    /// </summary>
    [JsonPropertyName("smtp_login")]
    public string? SmtpLogin { get; init; }

    /// <summary>
    /// Smtp密码
    /// </summary>
    [JsonPropertyName("smtp_password")]
    public string? SmtpPassword { get; init; }

    /// <summary>
    /// SmtpAddress
    /// </summary>
    [JsonPropertyName("smtp_address")]
    public string? SmtpAddress { get; init; }

    /// <summary>
    /// SmtpPort
    /// </summary>
    [JsonPropertyName("smtp_port")]
    public long? SmtpPort { get; init; }

    /// <summary>
    /// Smtp域名
    /// </summary>
    [JsonPropertyName("smtp_domain")]
    public string? SmtpDomain { get; init; }

    /// <summary>
    /// SmtpEnableStarttlsAuto
    /// </summary>
    [JsonPropertyName("smtp_enable_starttls_auto")]
    public bool? SmtpEnableStarttlsAuto { get; init; }

    /// <summary>
    /// SmtpEnableSslTls
    /// </summary>
    [JsonPropertyName("smtp_enable_ssl_tls")]
    public bool? SmtpEnableSslTls { get; init; }

    /// <summary>
    /// SmtpOpensslVerifyMode
    /// </summary>
    [JsonPropertyName("smtp_openssl_verify_mode")]
    public string? SmtpOpensslVerifyMode { get; init; }

    /// <summary>
    /// SmtpAuthentication
    /// </summary>
    [JsonPropertyName("smtp_authentication")]
    public string? SmtpAuthentication { get; init; }

    /// <summary>
    /// 提供者
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; init; }

    /// <summary>
    /// VerifiedSending
    /// </summary>
    [JsonPropertyName("verified_for_sending")]
    public bool? VerifiedForSending { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; init; }
}
