using Refit;

namespace ChatWootApi.Platform;

/// <summary>
/// Chatwoot 平台 API：平台用户API。
/// </summary>
public interface IPlatformUserApi
{
    /// <summary>
    /// 调用 Chatwoot 平台 API：创建用户。
    /// </summary>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Post("/platform/api/v1/users")]
    Task<User> CreateUserAsync([Body] UserCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 平台 API：获取用户。
    /// </summary>
    /// <param name="id">资源 ID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/platform/api/v1/users/{id}")]
    Task<User> GetUserAsync(long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 平台 API：更新用户。
    /// </summary>
    /// <param name="id">资源 ID。</param>
    /// <param name="payload">请求载荷。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Patch("/platform/api/v1/users/{id}")]
    Task<User> UpdateUserAsync(long id, [Body] UserCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 平台 API：删除用户。
    /// </summary>
    /// <param name="id">资源 ID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>异步操作。</returns>
    [Delete("/platform/api/v1/users/{id}")]
    Task DeleteUserAsync(long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 平台 API：获取用户SSOURL。
    /// </summary>
    /// <param name="id">资源 ID。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/platform/api/v1/users/{id}/login")]
    Task<UserSsoUrl> GetUserSsoUrlAsync(long id, CancellationToken cancellationToken = default);
}
