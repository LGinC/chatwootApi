using System.Text.Json;
using Refit;
using ChatWootApi.Application.Models;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用报表API
/// </summary>
public interface IApplicationReportsApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：获取账号Reporting事件
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="query">查询参数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>上报事件列表</returns>
    [Get("/api/v1/accounts/{accountId}/reporting_events")]
    Task<ReportingEventsListResponse> GetAccountReportingEventsAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：列出全部会话Statistics
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="query">查询参数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>会话统计数据字典的只读列表</returns>
    [Get("/api/v2/accounts/{accountId}/reports")]
    Task<IReadOnlyList<ConversationStatistic>> ListAllConversationStatisticsAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：列出全部会话Statistics汇总
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="query">查询参数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>账户汇总报告</returns>
    [Get("/api/v2/accounts/{accountId}/reports/summary")]
    Task<AccountSummary> ListAllConversationStatisticsSummaryAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取账号会话指标
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="query">查询参数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>原始 JSON 响应数据</returns>
    [Get("/api/v2/accounts/{accountId}/reports/conversations")]
    Task<AccountConversationMetrics> GetAccountConversationMetricsAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取坐席会话指标
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="query">查询参数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>坐席会话指标的只读列表</returns>
    [Get("/api/v2/accounts/{accountId}/reports/conversations/")]
    Task<IReadOnlyList<AgentConversationMetrics>> GetAgentConversationMetricsAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取渠道汇总报表
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="query">查询参数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>渠道汇总报告</returns>
    [Get("/api/v2/accounts/{accountId}/summary_reports/channel")]
    Task<ChannelSummary> GetChannelSummaryReportAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取收件箱汇总报表
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="query">查询参数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>收件箱汇总报告</returns>
    [Get("/api/v2/accounts/{accountId}/summary_reports/inbox")]
    Task<InboxSummary> GetInboxSummaryReportAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取坐席汇总报表
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="query">查询参数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>坐席汇总报告</returns>
    [Get("/api/v2/accounts/{accountId}/summary_reports/agent")]
    Task<AgentSummary> GetAgentSummaryReportAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取团队汇总报表
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="query">查询参数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>团队汇总报告</returns>
    [Get("/api/v2/accounts/{accountId}/summary_reports/team")]
    Task<TeamSummary> GetTeamSummaryReportAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取首次响应时间分布
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="query">查询参数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>首次响应时间分布</returns>
    [Get("/api/v2/accounts/{accountId}/reports/first_response_time_distribution")]
    Task<FirstResponseTimeDistribution> GetFirstResponseTimeDistributionAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取收件箱标签矩阵
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="query">查询参数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>收件箱标签矩阵</returns>
    [Get("/api/v2/accounts/{accountId}/reports/inbox_label_matrix")]
    Task<InboxLabelMatrix> GetInboxLabelMatrixAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取外发消息数量
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="query">查询参数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>出站消息计数</returns>
    [Get("/api/v2/accounts/{accountId}/reports/outgoing_messages_count")]
    Task<OutgoingMessagesCount> GetOutgoingMessagesCountAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);
}
