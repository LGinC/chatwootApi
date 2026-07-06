using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用报表API。
/// </summary>
public interface IApplicationReportsApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：获取账号Reporting事件。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="query">查询参数。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v1/accounts/{accountId}/reporting_events")]
    Task<ReportingEventsListResponse> GetAccountReportingEventsAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：列出全部会话Statistics。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="query">查询参数。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v2/accounts/{accountId}/reports")]
    Task<IReadOnlyList<IDictionary<string, JsonElement>?>> ListAllConversationStatisticsAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：列出全部会话Statistics汇总。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="query">查询参数。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v2/accounts/{accountId}/reports/summary")]
    Task<AccountSummary> ListAllConversationStatisticsSummaryAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取账号会话指标。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="query">查询参数。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v2/accounts/{accountId}/reports/conversations")]
    Task<JsonElement> GetAccountConversationMetricsAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取坐席会话指标。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="query">查询参数。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v2/accounts/{accountId}/reports/conversations/")]
    Task<IReadOnlyList<AgentConversationMetrics>> GetAgentConversationMetricsAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取渠道汇总报表。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="query">查询参数。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v2/accounts/{accountId}/summary_reports/channel")]
    Task<ChannelSummary> GetChannelSummaryReportAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取收件箱汇总报表。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="query">查询参数。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v2/accounts/{accountId}/summary_reports/inbox")]
    Task<InboxSummary> GetInboxSummaryReportAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取坐席汇总报表。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="query">查询参数。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v2/accounts/{accountId}/summary_reports/agent")]
    Task<AgentSummary> GetAgentSummaryReportAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取团队汇总报表。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="query">查询参数。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v2/accounts/{accountId}/summary_reports/team")]
    Task<TeamSummary> GetTeamSummaryReportAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取首次响应时间分布。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="query">查询参数。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v2/accounts/{accountId}/reports/first_response_time_distribution")]
    Task<FirstResponseTimeDistribution> GetFirstResponseTimeDistributionAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取收件箱标签矩阵。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="query">查询参数。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v2/accounts/{accountId}/reports/inbox_label_matrix")]
    Task<InboxLabelMatrix> GetInboxLabelMatrixAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取外发消息数量。
    /// </summary>
    /// <param name="accountId">账号 ID。</param>
    /// <param name="query">查询参数。</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌。</param>
    /// <returns>API 响应。</returns>
    [Get("/api/v2/accounts/{accountId}/reports/outgoing_messages_count")]
    Task<OutgoingMessagesCount> GetOutgoingMessagesCountAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);
}
