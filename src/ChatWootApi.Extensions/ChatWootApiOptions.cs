namespace ChatWootApi.Extensions;

public sealed class ChatWootApiOptions
{
    public const string DefaultSectionName = "ChatWootApi";

    public string BaseAddress { get; set; } = "https://app.chatwoot.com/";

    public string? AccountAccessToken { get; set; }

    public string? PlatformAccessToken { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether HTTP request and response logging is enabled for all Chatwoot APIs.
    /// </summary>
    public bool EnableLogging { get; set; }

    /// <summary>
    /// Gets or sets the API interface names for which HTTP logging is enabled when <see cref="EnableLogging"/> is false.
    /// Both the short interface name and the full type name are supported.
    /// </summary>
    public string[] LoggingApiNames { get; set; } = [];

    /// <summary>
    /// Gets or sets a value indicating whether JSON or form request and response bodies are included in logs.
    /// Sensitive fields are masked before they are logged.
    /// </summary>
    public bool IncludeBodyInLogs { get; set; }

    internal bool IsLoggingEnabled(string apiName, string? apiFullName)
    {
        if (EnableLogging)
        {
            return true;
        }

        return LoggingApiNames?.Any(configuredName =>
            string.Equals(configuredName, apiName, StringComparison.OrdinalIgnoreCase) ||
            (!string.IsNullOrWhiteSpace(apiFullName) &&
                string.Equals(configuredName, apiFullName, StringComparison.OrdinalIgnoreCase))) == true;
    }

    internal Uri GetBaseAddress()
    {
        if (!Uri.TryCreate(BaseAddress, UriKind.Absolute, out var uri))
        {
            throw new InvalidOperationException($"{nameof(ChatWootApiOptions)}.{nameof(BaseAddress)} must be an absolute URI.");
        }

        return uri;
    }
}
