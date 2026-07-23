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
    /// <param name="page">分页页码</param>
    /// <param name="since">起始时间戳（Unix 秒）</param>
    /// <param name="until">结束时间戳（Unix 秒）</param>
    /// <param name="inboxId">按收件箱 ID 筛选</param>
    /// <param name="userId">按坐席 ID 筛选</param>
    /// <param name="name">按事件名称筛选</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>上报事件列表</returns>
    [Get("/api/v1/accounts/{accountId}/reporting_events?page={page}&since={since}&until={until}&inbox_id={inboxId}&user_id={userId}&name={name}")]
    Task<ReportingEventsListResponse> GetAccountReportingEventsAsync(
        long accountId,
        long? page = null,
        string? since = null,
        string? until = null,
        long? inboxId = null,
        long? userId = null,
        string? name = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：列出全部会话Statistics
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="metric">指标类型</param>
    /// <param name="type">报表对象类型</param>
    /// <param name="id">agent/inbox/label 等具体对象 ID</param>
    /// <param name="since">起始时间戳</param>
    /// <param name="until">结束时间戳</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>会话统计数据的只读列表</returns>
    [Get("/api/v2/accounts/{accountId}/reports?metric={metric}&type={type}&id={id}&since={since}&until={until}")]
    Task<IReadOnlyList<ConversationStatistic>> ListAllConversationStatisticsAsync(
        long accountId,
        ReportMetric metric,
        ReportType type,
        string? id = null,
        string? since = null,
        string? until = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：列出全部会话Statistics汇总
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="type">报表对象类型</param>
    /// <param name="id">agent/inbox/label 等具体对象 ID</param>
    /// <param name="since">起始时间戳</param>
    /// <param name="until">结束时间戳</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>账户汇总报告</returns>
    [Get("/api/v2/accounts/{accountId}/reports/summary?type={type}&id={id}&since={since}&until={until}")]
    Task<AccountSummary> ListAllConversationStatisticsSummaryAsync(
        long accountId,
        ReportType type,
        string? id = null,
        string? since = null,
        string? until = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取账号会话指标
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="type">报表对象类型，文档要求 account</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>账号会话指标</returns>
    [Get("/api/v2/accounts/{accountId}/reports/conversations?type={type}")]
    Task<AccountConversationMetrics> GetAccountConversationMetricsAsync(
        long accountId,
        ReportType type = ReportType.Account,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取坐席会话指标
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="type">报表对象类型，文档要求 agent</param>
    /// <param name="userId">坐席用户 ID</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>坐席会话指标的只读列表</returns>
    [Get("/api/v2/accounts/{accountId}/reports/conversations/?type={type}&user_id={userId}")]
    Task<IReadOnlyList<AgentConversationMetrics>> GetAgentConversationMetricsAsync(
        long accountId,
        ReportType type = ReportType.Agent,
        string? userId = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取渠道汇总报表
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="since">起始时间戳</param>
    /// <param name="until">结束时间戳</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>渠道汇总报告</returns>
    [Get("/api/v2/accounts/{accountId}/summary_reports/channel?since={since}&until={until}")]
    Task<ChannelSummary> GetChannelSummaryReportAsync(
        long accountId,
        string? since = null,
        string? until = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取收件箱汇总报表
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="since">起始时间戳</param>
    /// <param name="until">结束时间戳</param>
    /// <param name="businessHours">是否仅统计工作时间</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>收件箱汇总报告</returns>
    [Get("/api/v2/accounts/{accountId}/summary_reports/inbox?since={since}&until={until}&business_hours={businessHours}")]
    Task<InboxSummary> GetInboxSummaryReportAsync(
        long accountId,
        string? since = null,
        string? until = null,
        bool? businessHours = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取坐席汇总报表
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="since">起始时间戳</param>
    /// <param name="until">结束时间戳</param>
    /// <param name="businessHours">是否仅统计工作时间</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>坐席汇总报告</returns>
    [Get("/api/v2/accounts/{accountId}/summary_reports/agent?since={since}&until={until}&business_hours={businessHours}")]
    Task<AgentSummary> GetAgentSummaryReportAsync(
        long accountId,
        string? since = null,
        string? until = null,
        bool? businessHours = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取团队汇总报表
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="since">起始时间戳</param>
    /// <param name="until">结束时间戳</param>
    /// <param name="businessHours">是否仅统计工作时间</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>团队汇总报告</returns>
    [Get("/api/v2/accounts/{accountId}/summary_reports/team?since={since}&until={until}&business_hours={businessHours}")]
    Task<TeamSummary> GetTeamSummaryReportAsync(
        long accountId,
        string? since = null,
        string? until = null,
        bool? businessHours = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取首次响应时间分布
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="since">起始时间戳</param>
    /// <param name="until">结束时间戳</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>首次响应时间分布</returns>
    [Get("/api/v2/accounts/{accountId}/reports/first_response_time_distribution?since={since}&until={until}")]
    Task<FirstResponseTimeDistribution> GetFirstResponseTimeDistributionAsync(
        long accountId,
        string? since = null,
        string? until = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取收件箱标签矩阵
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="since">起始时间戳</param>
    /// <param name="until">结束时间戳</param>
    /// <param name="inboxIds">收件箱 ID 列表</param>
    /// <param name="labelIds">标签 ID 列表</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>收件箱标签矩阵</returns>
    Task<InboxLabelMatrix> GetInboxLabelMatrixAsync(
        long accountId,
        string? since = null,
        string? until = null,
        IEnumerable<long>? inboxIds = null,
        IEnumerable<long>? labelIds = null,
        CancellationToken cancellationToken = default)
        => GetInboxLabelMatrixAsync(
            accountId,
            since,
            until,
            JoinIds(inboxIds),
            JoinIds(labelIds),
            cancellationToken);

    /// <summary>获取收件箱标签矩阵（逗号分隔 ID 字符串）。</summary>
    [Get("/api/v2/accounts/{accountId}/reports/inbox_label_matrix?since={since}&until={until}&inbox_ids={inboxIds}&label_ids={labelIds}")]
    Task<InboxLabelMatrix> GetInboxLabelMatrixAsync(
        long accountId,
        string? since,
        string? until,
        string? inboxIds,
        string? labelIds,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 调用 Chatwoot 应用 API：获取外发消息数量
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="groupBy">分组维度</param>
    /// <param name="since">起始时间戳</param>
    /// <param name="until">结束时间戳</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>出站消息计数</returns>
    [Get("/api/v2/accounts/{accountId}/reports/outgoing_messages_count?group_by={groupBy}&since={since}&until={until}")]
    Task<OutgoingMessagesCount> GetOutgoingMessagesCountAsync(
        long accountId,
        OutgoingMessagesGroupBy groupBy,
        string? since = null,
        string? until = null,
        CancellationToken cancellationToken = default);

    private static string? JoinIds(IEnumerable<long>? ids)
    {
        if (ids is null)
        {
            return null;
        }

        var joined = string.Join(',', ids);
        return joined.Length == 0 ? null : joined;
    }
}
