using System.Net.Http.Headers;

namespace ChatWootApi.Extensions;

public abstract class AccessTokenDelegatingHandler(
    IAccessTokenProvider accessTokenProvider,
    AccessTokenKind tokenKind) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var accessToken = await accessTokenProvider.GetAccessTokenAsync(tokenKind, cancellationToken).ConfigureAwait(false);

        request.Headers.Remove("api_access_token");
        request.Headers.TryAddWithoutValidation("api_access_token", accessToken);

        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }
}

public sealed class AccountAccessTokenDelegatingHandler(IAccessTokenProvider accessTokenProvider)
    : AccessTokenDelegatingHandler(accessTokenProvider, AccessTokenKind.Account);

public sealed class PlatformAccessTokenDelegatingHandler(IAccessTokenProvider accessTokenProvider)
    : AccessTokenDelegatingHandler(accessTokenProvider, AccessTokenKind.Platform);
