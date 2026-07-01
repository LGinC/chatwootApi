using Microsoft.Extensions.Options;

namespace ChatWootApi.Extensions;

public sealed class AccessTokenProvider(IOptionsMonitor<ChatWootApiOptions> options) : IAccessTokenProvider
{
    public ValueTask<string> GetAccessTokenAsync(AccessTokenKind tokenKind, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var accessToken = tokenKind switch
        {
            AccessTokenKind.Account => options.CurrentValue.AccountAccessToken,
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
}
