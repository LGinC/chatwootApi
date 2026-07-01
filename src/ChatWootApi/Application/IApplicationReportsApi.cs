using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationReportsApi
{
    [Get("/api/v1/accounts/{accountId}/reporting_events")]
    Task<ReportingEventsListResponse> GetAccountReportingEventsAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/accounts/{accountId}/reports")]
    Task<IReadOnlyList<IDictionary<string, JsonElement>?>> ListAllConversationStatisticsAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/accounts/{accountId}/reports/summary")]
    Task<AccountSummary> ListAllConversationStatisticsSummaryAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/accounts/{accountId}/reports/conversations")]
    Task<JsonElement> GetAccountConversationMetricsAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/accounts/{accountId}/reports/conversations/")]
    Task<IReadOnlyList<AgentConversationMetrics>> GetAgentConversationMetricsAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/accounts/{accountId}/summary_reports/channel")]
    Task<ChannelSummary> GetChannelSummaryReportAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/accounts/{accountId}/summary_reports/inbox")]
    Task<InboxSummary> GetInboxSummaryReportAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/accounts/{accountId}/summary_reports/agent")]
    Task<AgentSummary> GetAgentSummaryReportAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/accounts/{accountId}/summary_reports/team")]
    Task<TeamSummary> GetTeamSummaryReportAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/accounts/{accountId}/reports/first_response_time_distribution")]
    Task<FirstResponseTimeDistribution> GetFirstResponseTimeDistributionAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/accounts/{accountId}/reports/inbox_label_matrix")]
    Task<InboxLabelMatrix> GetInboxLabelMatrixAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/accounts/{accountId}/reports/outgoing_messages_count")]
    Task<OutgoingMessagesCount> GetOutgoingMessagesCountAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);
}
