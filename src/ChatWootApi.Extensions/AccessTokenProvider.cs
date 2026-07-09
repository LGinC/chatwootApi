using ChatWootApi.AccessTokens;
using Microsoft.Extensions.Options;

namespace ChatWootApi.Extensions;

public sealed class AccessTokenProvider(IOptionsMonitor<ChatWootApiOptions> options) : IAccessTokenProvider
{
    private readonly AsyncLocal<string?> applicationAccessToken = new();

    public IDisposable UseApplicationAccessToken(string accessToken)
    {
        if (string.IsNullOrWhiteSpace(accessToken))
        {
            throw new ArgumentException("Application access token is required.", nameof(accessToken));
        }

        var previousAccessToken = applicationAccessToken.Value;
        applicationAccessToken.Value = accessToken;

        return new ApplicationAccessTokenScope(this, previousAccessToken);
    }

    public ValueTask<string> GetAccessTokenAsync(AccessTokenKind tokenKind, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var accessToken = tokenKind switch
        {
            AccessTokenKind.Account => applicationAccessToken.Value ?? options.CurrentValue.AccountAccessToken,
            AccessTokenKind.Platform => options.CurrentValue.PlatformAccessToken,
            _ => throw new ArgumentOutOfRangeException(nameof(tokenKind), tokenKind, null)
        };

        if (string.IsNullOrWhiteSpace(accessToken))
        {
            var optionName = tokenKind == AccessTokenKind.Account
                ? nameof(ChatWootApiOptions.AccountAccessToken)
                : nameof(ChatWootApiOptions.PlatformAccessToken);

            throw new InvalidOperationException($"{nameof(ChatWootApiOptions)}.{optionName} is required for {tokenKind} API calls.");
        }

        return ValueTask.FromResult(accessToken);
    }

    private sealed class ApplicationAccessTokenScope(
        AccessTokenProvider provider,
        string? previousAccessToken) : IDisposable
    {
        private bool disposed;

        public void Dispose()
        {
            if (disposed)
            {
                return;
            }

            provider.applicationAccessToken.Value = previousAccessToken;
            disposed = true;
        }
    }
}
