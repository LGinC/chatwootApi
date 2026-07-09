namespace ChatWootApi.AccessTokens;

/// <summary>
/// 为 Chatwoot API 请求提供访问令牌
/// </summary>
public interface IAccessTokenProvider
{
    /// <summary>
    /// 获取指定类型的访问令牌
    /// </summary>
    /// <param name="tokenKind">访问令牌类型</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>访问令牌</returns>
    ValueTask<string> GetAccessTokenAsync(AccessTokenKind tokenKind, CancellationToken cancellationToken = default);
}
