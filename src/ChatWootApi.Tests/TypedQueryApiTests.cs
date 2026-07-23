using System.Net;
using System.Web;
using ChatWootApi.Application;
using ChatWootApi.Application.Models;
using ChatWootApi.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace ChatWootApi.Tests;

public sealed class TypedQueryApiTests
{
    [Fact]
    public async Task AuditLogsSendsPageQuery()
    {
        var (api, handler) = CreateApi<IApplicationAuditLogsApi>();
        await api.GetAccountAuditLogsAsync(12, page: 3, cancellationToken: TestContext.Current.CancellationToken);
        Assert.Equal("/api/v1/accounts/12/audit_logs?page=3", handler.Request!.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task AuditLogsOmitsPageWhenUnset()
    {
        var (api, handler) = CreateApi<IApplicationAuditLogsApi>();
        await api.GetAccountAuditLogsAsync(12, page: null, cancellationToken: TestContext.Current.CancellationToken);
        Assert.Equal("/api/v1/accounts/12/audit_logs", handler.Request!.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task ContactSearchSendsDocumentedQuery()
    {
        var (api, handler) = CreateApi<IApplicationContactsApi>();
        await api.ContactSearchAsync(12, q: "alice@example.com", sort: ContactSort.EmailDesc, page: 2, cancellationToken: TestContext.Current.CancellationToken);

        Assert.Equal(
            "/api/v1/accounts/12/contacts/search?q=alice%40example.com&sort=-email&page=2",
            handler.Request!.RequestUri!.PathAndQuery);

        var query = HttpUtility.ParseQueryString(handler.Request.RequestUri.Query);
        Assert.Equal("alice@example.com", query["q"]);
        Assert.Equal("-email", query["sort"]);
        Assert.Equal("2", query["page"]);
    }

    [Fact]
    public async Task ContactSearchOmitsUnsetQueryParameters()
    {
        var (api, handler) = CreateApi<IApplicationContactsApi>();
        await api.ContactSearchAsync(12, q: null, cancellationToken: TestContext.Current.CancellationToken);
        Assert.Equal("/api/v1/accounts/12/contacts/search", handler.Request!.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task ContactFilterSendsPageQuery()
    {
        var (api, handler) = CreateApi<IApplicationContactsApi>();
        await api.ContactFilterAsync(12, new FilterPayload(), page: 4, cancellationToken: TestContext.Current.CancellationToken);
        Assert.Equal("/api/v1/accounts/12/contacts/filter?page=4", handler.Request!.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task CustomAttributesSendsAttributeModelQuery()
    {
        var (api, handler) = CreateApi<IApplicationCustomAttributesApi>();
        await api.GetAccountCustomAttributeAsync(12, CustomAttributeModel.ContactAttribute, cancellationToken: TestContext.Current.CancellationToken);
        Assert.Equal(
            "/api/v1/accounts/12/custom_attribute_definitions?attribute_model=1",
            handler.Request!.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task CustomFiltersSendsFilterTypeQuery()
    {
        var (api, handler) = CreateApi<IApplicationCustomFiltersApi>();
        await api.ListAllFiltersAsync(12, filterType: CustomFilterType.Conversation, cancellationToken: TestContext.Current.CancellationToken);
        Assert.Equal(
            "/api/v1/accounts/12/custom_filters?filter_type=conversation",
            handler.Request!.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task ReportsSendsMetricAndTypeQuery()
    {
        var (api, handler) = CreateApi<IApplicationReportsApi>();
        await api.ListAllConversationStatisticsAsync(
            12,
            metric: ReportMetric.ConversationsCount,
            type: ReportType.Agent,
            id: "7",
            since: "100",
            until: "200",
            cancellationToken: TestContext.Current.CancellationToken);

        var query = HttpUtility.ParseQueryString(handler.Request!.RequestUri!.Query);
        Assert.Equal("/api/v2/accounts/12/reports", handler.Request.RequestUri.AbsolutePath);
        Assert.Equal("conversations_count", query["metric"]);
        Assert.Equal("agent", query["type"]);
        Assert.Equal("7", query["id"]);
        Assert.Equal("100", query["since"]);
        Assert.Equal("200", query["until"]);
    }

    [Fact]
    public async Task ReportsSendsOutgoingMessagesGroupBy()
    {
        var (api, handler) = CreateApi<IApplicationReportsApi>();
        await api.GetOutgoingMessagesCountAsync(12, OutgoingMessagesGroupBy.Team, since: "1", until: "2", cancellationToken: TestContext.Current.CancellationToken);

        var query = HttpUtility.ParseQueryString(handler.Request!.RequestUri!.Query);
        Assert.Equal("/api/v2/accounts/12/reports/outgoing_messages_count", handler.Request.RequestUri.AbsolutePath);
        Assert.Equal("team", query["group_by"]);
        Assert.Equal("1", query["since"]);
        Assert.Equal("2", query["until"]);
    }

    [Fact]
    public async Task ReportsSendsInboxLabelMatrixArrays()
    {
        var (api, handler) = CreateApi<IApplicationReportsApi>();
        await api.GetInboxLabelMatrixAsync(12, inboxIds: [1, 2], labelIds: [9], cancellationToken: TestContext.Current.CancellationToken);

        var query = HttpUtility.ParseQueryString(handler.Request!.RequestUri!.Query);
        Assert.Equal("1,2", query["inbox_ids"]);
        Assert.Equal("9", query["label_ids"]);
    }

    [Fact]
    public void NoApplicationApiUsesDictionaryQuery()
    {
        var applicationApis = typeof(IApplicationConversationsApi).Assembly
            .GetTypes()
            .Where(type => type.IsInterface && type.Namespace == "ChatWootApi.Application")
            .ToArray();

        Assert.NotEmpty(applicationApis);

        foreach (var api in applicationApis)
        {
            foreach (var method in api.GetMethods())
            {
                foreach (var parameter in method.GetParameters())
                {
                    var usesDictionaryQuery =
                        parameter.ParameterType.IsGenericType &&
                        parameter.ParameterType.GetGenericTypeDefinition() == typeof(IDictionary<,>) &&
                        parameter.GetCustomAttributes(typeof(QueryAttribute), inherit: true).Length > 0;

                    Assert.False(
                        usesDictionaryQuery,
                        $"{api.Name}.{method.Name} still uses IDictionary query.");
                }
            }
        }
    }

    private static (TApi Api, CapturingHandler Handler) CreateApi<TApi>()
        where TApi : class
    {
        var handler = new CapturingHandler();
        var services = new ServiceCollection();
        services.AddRefitGeneratedClient<TApi>(new RefitSettings
            {
                UrlParameterFormatter = new ChatWootUrlParameterFormatter(),
            })
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://example.test/"))
            .ConfigurePrimaryHttpMessageHandler(() => handler);

        var provider = services.BuildServiceProvider();
        return (provider.GetRequiredService<TApi>(), handler);
    }

    private sealed class CapturingHandler : HttpMessageHandler
    {
        public HttpRequestMessage? Request { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            Request = request;
            var body = NeedsEmptyArray(request.RequestUri?.AbsolutePath) ? "[]" : "{}";
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(body, System.Text.Encoding.UTF8, "application/json"),
            });
        }

        private static bool NeedsEmptyArray(string? absolutePath)
        {
            if (absolutePath is null)
            {
                return false;
            }

            return absolutePath.Contains("custom_attribute_definitions", StringComparison.Ordinal)
                || absolutePath.Contains("custom_filters", StringComparison.Ordinal)
                || absolutePath.EndsWith("/reports", StringComparison.Ordinal);
        }
    }
}
