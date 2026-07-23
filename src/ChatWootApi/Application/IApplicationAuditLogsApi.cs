using Refit;
using ChatWootApi.Application.Models;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用审计日志API
/// </summary>
public interface IApplicationAuditLogsApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：获取账号审计日志
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="page">分页页码</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>审计日志分页响应</returns>
    Task<AuditLogsResponse> GetAccountAuditLogsAsync(
        long accountId,
        long? page = null,
        CancellationToken cancellationToken = default)
        => page is long pageNumber
            ? GetAccountAuditLogsByPageAsync(accountId, pageNumber, cancellationToken)
            : GetAccountAuditLogsAsync(accountId, cancellationToken);

    /// <summary>获取账号审计日志（不带分页）。</summary>
    [Get("/api/v1/accounts/{accountId}/audit_logs")]
    Task<AuditLogsResponse> GetAccountAuditLogsAsync(
        long accountId,
        CancellationToken cancellationToken = default);

    /// <summary>按页码获取账号审计日志。</summary>
    [Get("/api/v1/accounts/{accountId}/audit_logs?page={page}")]
    Task<AuditLogsResponse> GetAccountAuditLogsByPageAsync(
        long accountId,
        long page,
        CancellationToken cancellationToken = default);
}
