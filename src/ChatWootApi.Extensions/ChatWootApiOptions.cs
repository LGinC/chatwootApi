namespace ChatWootApi.Extensions;

public sealed class ChatWootApiOptions
{
    public const string DefaultSectionName = "ChatWootApi";

    public string BaseAddress { get; set; } = "https://app.chatwoot.com/";

    public string? AccountAccessToken { get; set; }

    public string? PlatformAccessToken { get; set; }

    internal Uri GetBaseAddress()
    {
        if (!Uri.TryCreate(BaseAddress, UriKind.Absolute, out var uri))
        {
            throw new InvalidOperationException($"{nameof(ChatWootApiOptions)}.{nameof(BaseAddress)} must be an absolute URI.");
        }

        return uri;
    }
}
