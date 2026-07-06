using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用审计日志API。
/// </summary>
public interface IApplicationAuditLogsApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：获取账号审计日志。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="query">查询参数。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v1/accounts/{accountId}/audit_logs")]
    Task<JsonElement> GetAccountAuditLogsAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);
}
