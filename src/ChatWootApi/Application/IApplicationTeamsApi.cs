using System.Text.Json;
using Refit;
using ChatWootApi.Application.Models;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用团队API
/// </summary>
public interface IApplicationTeamsApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：列出全部团队
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>团队（Team）的只读列表</returns>
    [Get("/api/v1/accounts/{accountId}/teams")]
    Task<IReadOnlyList<Team>> ListAllTeamsAsync(long accountId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：创建团队
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>团队（Team）</returns>
    [Post("/api/v1/accounts/{accountId}/teams")]
    Task<Team> CreateATeamAsync(long accountId, [Body] TeamCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取详情单个团队
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="teamId">teamID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>团队（Team）</returns>
    [Get("/api/v1/accounts/{accountId}/teams/{teamId}")]
    Task<Team> GetDetailsOfASingleTeamAsync(long accountId, long teamId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新团队
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="teamId">teamID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>团队（Team）</returns>
    [Patch("/api/v1/accounts/{accountId}/teams/{teamId}")]
    Task<Team> UpdateATeamAsync(long accountId, long teamId, [Body] TeamCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：删除团队
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="teamId">teamID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>异步操作</returns>
    [Delete("/api/v1/accounts/{accountId}/teams/{teamId}")]
    Task DeleteATeamAsync(long accountId, long teamId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取团队成员
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="teamId">teamID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>坐席（Agent）信息的只读列表</returns>
    [Get("/api/v1/accounts/{accountId}/teams/{teamId}/team_members")]
    Task<IReadOnlyList<Agent>> GetTeamMembersAsync(long accountId, long teamId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：添加新坐席团队
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="teamId">teamID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>坐席（Agent）信息的只读列表</returns>
    [Post("/api/v1/accounts/{accountId}/teams/{teamId}/team_members")]
    Task<IReadOnlyList<Agent>> AddNewAgentToTeamAsync(long accountId, long teamId, [Body] JsonElement payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新坐席团队
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="teamId">teamID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>坐席（Agent）信息的只读列表</returns>
    [Patch("/api/v1/accounts/{accountId}/teams/{teamId}/team_members")]
    Task<IReadOnlyList<Agent>> UpdateAgentsInTeamAsync(long accountId, long teamId, [Body] JsonElement payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：删除坐席团队
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="teamId">teamID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>异步操作</returns>
    [Delete("/api/v1/accounts/{accountId}/teams/{teamId}/team_members")]
    Task DeleteAgentInTeamAsync(long accountId, long teamId, [Body] JsonElement payload, CancellationToken cancellationToken = default);
}
