namespace ChatWootApi;

public interface IAccessTokenProvider
{
    ValueTask<string> GetAccessTokenAsync(AccessTokenKind tokenKind, CancellationToken cancellationToken = default);
}
