namespace ChatWootApi.AccessTokens;

/// <summary>
/// Chatwoot API 访问令牌类型
/// </summary>
public enum AccessTokenKind
{
    /// <summary>
    /// 应用 API 使用的账号访问令牌
    /// </summary>
    Account,
    /// <summary>
    /// 平台 API 使用的平台访问令牌
    /// </summary>
    Platform
}
