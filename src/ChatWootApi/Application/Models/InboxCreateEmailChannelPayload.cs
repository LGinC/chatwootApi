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
    /// 收件箱的电子邮件地址
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// 为入站电子邮件启用 IMAP
    /// </summary>
    [JsonPropertyName("imap_enabled")]
    public bool? ImapEnabled { get; init; }

    /// <summary>
    /// IMAP 登录用户名
    /// </summary>
    [JsonPropertyName("imap_login")]
    public string? ImapLogin { get; init; }

    /// <summary>
    /// IMAP登录密码
    /// </summary>
    [JsonPropertyName("imap_password")]
    public string? ImapPassword { get; init; }

    /// <summary>
    /// IMAP 服务器地址
    /// </summary>
    [JsonPropertyName("imap_address")]
    public string? ImapAddress { get; init; }

    /// <summary>
    /// IMAP 服务器端口
    /// </summary>
    [JsonPropertyName("imap_port")]
    public long? ImapPort { get; init; }

    /// <summary>
    /// 为 IMAP 启用 SSL
    /// </summary>
    [JsonPropertyName("imap_enable_ssl")]
    public bool? ImapEnableSsl { get; init; }

    /// <summary>
    /// IMAP认证方式
    /// </summary>
    [JsonPropertyName("imap_authentication")]
    public string? ImapAuthentication { get; init; }

    /// <summary>
    /// 为出站电子邮件启用 SMTP
    /// </summary>
    [JsonPropertyName("smtp_enabled")]
    public bool? SmtpEnabled { get; init; }

    /// <summary>
    /// SMTP 登录用户名
    /// </summary>
    [JsonPropertyName("smtp_login")]
    public string? SmtpLogin { get; init; }

    /// <summary>
    /// SMTP登录密码
    /// </summary>
    [JsonPropertyName("smtp_password")]
    public string? SmtpPassword { get; init; }

    /// <summary>
    /// SMTP 服务器地址
    /// </summary>
    [JsonPropertyName("smtp_address")]
    public string? SmtpAddress { get; init; }

    /// <summary>
    /// SMTP 服务器端口
    /// </summary>
    [JsonPropertyName("smtp_port")]
    public long? SmtpPort { get; init; }

    /// <summary>
    /// SMTP HELO 域
    /// </summary>
    [JsonPropertyName("smtp_domain")]
    public string? SmtpDomain { get; init; }

    /// <summary>
    /// 自动为 SMTP 启用 STARTTLS
    /// </summary>
    [JsonPropertyName("smtp_enable_starttls_auto")]
    public bool? SmtpEnableStarttlsAuto { get; init; }

    /// <summary>
    /// 为 SMTP 启用 SSL/TLS
    /// </summary>
    [JsonPropertyName("smtp_enable_ssl_tls")]
    public bool? SmtpEnableSslTls { get; init; }

    /// <summary>
    /// SMTP 的 OpenSSL 证书验证模式
    /// </summary>
    [JsonPropertyName("smtp_openssl_verify_mode")]
    public string? SmtpOpensslVerifyMode { get; init; }

    /// <summary>
    /// SMTP认证方式
    /// </summary>
    [JsonPropertyName("smtp_authentication")]
    public string? SmtpAuthentication { get; init; }

    /// <summary>
    /// 电子邮件提供商
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; init; }

    /// <summary>
    /// 是否验证收件箱以发送电子邮件
    /// </summary>
    [JsonPropertyName("verified_for_sending")]
    public bool? VerifiedForSending { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
