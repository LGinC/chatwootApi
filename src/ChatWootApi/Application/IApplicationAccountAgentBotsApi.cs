using System.Text.Json;
using Refit;
ChatWootApi.Application.Models;
ChatWootApi.Application.Models;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用账号坐席机器人API
/// </summary>
public interface IApplicationAccountAgentBotsApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：列出全部账号坐席机器人
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>AgentBot 实例的只读列表</returns>
    [Get("/api/v1/accounts/{accountId}/agent_bots")]
    Task<IReadOnlyList<AgentBot>> ListAllAccountAgentBotsAsync(long accountId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：创建账号坐席机器人
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>AgentBot 实例</returns>
    [Post("/api/v1/accounts/{accountId}/agent_bots")]
    Task<AgentBot> CreateAnAccountAgentBotAsync(long accountId, [Body] AgentBotCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取详情单个账号坐席机器人
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>AgentBot 实例</returns>
    [Get("/api/v1/accounts/{accountId}/agent_bots/{id}")]
    Task<AgentBot> GetDetailsOfASingleAccountAgentBotAsync(long accountId, long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新账号坐席机器人
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>AgentBot 实例</returns>
    [Patch("/api/v1/accounts/{accountId}/agent_bots/{id}")]
    Task<AgentBot> UpdateAnAccountAgentBotAsync(long accountId, long id, [Body] AgentBotCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：删除账号坐席机器人
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>异步操作</returns>
    [Delete("/api/v1/accounts/{accountId}/agent_bots/{id}")]
    Task DeleteAnAccountAgentBotAsync(long accountId, long id, CancellationToken cancellationToken = default);
}
