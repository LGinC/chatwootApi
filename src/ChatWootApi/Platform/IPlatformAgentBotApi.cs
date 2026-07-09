using Refit;
ChatWootApi.Application.Models;
ChatWootApi.Application.Models;

namespace ChatWootApi.Platform;

/// <summary>
/// Chatwoot 平台 API：平台坐席机器人API
/// </summary>
public interface IPlatformAgentBotApi
{
    /// <summary>
    /// 调用 Chatwoot 平台 API：列出坐席机器人
    /// </summary>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>AgentBot 实例的只读列表</returns>
    [Get("/platform/api/v1/agent_bots")]
    Task<IReadOnlyList<AgentBot>> ListAgentBotsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 平台 API：创建坐席机器人
    /// </summary>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>AgentBot 实例</returns>
    [Post("/platform/api/v1/agent_bots")]
    Task<AgentBot> CreateAgentBotAsync([Body] AgentBotCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 平台 API：获取坐席机器人
    /// </summary>
    /// <param name="id">资源 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>AgentBot 实例</returns>
    [Get("/platform/api/v1/agent_bots/{id}")]
    Task<AgentBot> GetAgentBotAsync(long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 平台 API：更新坐席机器人
    /// </summary>
    /// <param name="id">资源 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>AgentBot 实例</returns>
    [Patch("/platform/api/v1/agent_bots/{id}")]
    Task<AgentBot> UpdateAgentBotAsync(long id, [Body] AgentBotCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 平台 API：删除坐席机器人
    /// </summary>
    /// <param name="id">资源 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>异步操作</returns>
    [Delete("/platform/api/v1/agent_bots/{id}")]
    Task DeleteAgentBotAsync(long id, CancellationToken cancellationToken = default);
}
