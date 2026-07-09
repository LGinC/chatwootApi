using System.Text.Json;
using Refit;
using ChatWootApi.Application.Models;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用个人资料API
/// </summary>
public interface IApplicationProfileApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：Fetch个人资料
    /// </summary>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>用户信息</returns>
    [Get("/api/v1/profile")]
    Task<User> FetchProfileAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新个人资料
    /// </summary>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>用户信息</returns>
    [Put("/api/v1/profile")]
    Task<User> UpdateProfileAsync([Body] JsonElement payload, CancellationToken cancellationToken = default);
}