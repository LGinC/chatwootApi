using System.Text.Json;
using Refit;
using ChatWootApi.Application.Models;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用自动化规则API
/// </summary>
public interface IApplicationAutomationRuleApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：获取账号自动化规则
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>自动化规则</returns>
    [Get("/api/v1/accounts/{accountId}/automation_rules")]
    Task<AutomationRule> GetAccountAutomationRuleAsync(long accountId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：添加新自动化规则账号
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>自动化规则</returns>
    [Post("/api/v1/accounts/{accountId}/automation_rules")]
    Task<AutomationRule> AddNewAutomationRuleToAccountAsync(long accountId, [Body] AutomationRuleCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取详情单个自动化规则
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>自动化规则</returns>
    [Get("/api/v1/accounts/{accountId}/automation_rules/{id}")]
    Task<AutomationRule> GetDetailsOfASingleAutomationRuleAsync(long accountId, long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：更新自动化规则账号
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>自动化规则</returns>
    [Patch("/api/v1/accounts/{accountId}/automation_rules/{id}")]
    Task<AutomationRule> UpdateAutomationRuleInAccountAsync(long accountId, long id, [Body] AutomationRuleCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：删除自动化规则账号
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="id">资源 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>异步操作</returns>
    [Delete("/api/v1/accounts/{accountId}/automation_rules/{id}")]
    Task DeleteAutomationRuleFromAccountAsync(long accountId, long id, CancellationToken cancellationToken = default);
}