using System.Net;
using System.Reflection;
using System.Web;
using ChatWootApi.Application;
using ChatWootApi.Application.Models;
using ChatWootApi.Extensions;
using ChatWootApi.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace ChatWootApi.Tests;

public sealed class ApplicationConversationsApiTests
{
    [Fact]
    public async Task GeneratedClientSendsDocumentedConversationListQueryParameters()
    {
        using var handler = new CapturingHandler();
        var services = new ServiceCollection();
        services.AddRefitGeneratedClient<IApplicationConversationsApi>(CreateRefitSettings())
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://example.test/"))
            .AddHttpMessageHandler(() => new OmitEmptyQueryParametersHandler())
            .ConfigurePrimaryHttpMessageHandler(() => handler);

        using var serviceProvider = services.BuildServiceProvider();
        var api = serviceProvider.GetRequiredService<IApplicationConversationsApi>();

        await api.ConversationListAsync(
            12,
            assigneeType: ConversationAssigneeType.Me,
            status: ConversationStatus.Open,
            q: "billing",
            inboxId: 7,
            teamId: 9,
            labels: ["vip", "priority"],
            page: 2,
            cancellationToken: TestContext.Current.CancellationToken);

        Assert.Equal(HttpMethod.Get, handler.Request!.Method);
        Assert.Equal("/api/v1/accounts/12/conversations", handler.Request.RequestUri!.AbsolutePath);

        var query = HttpUtility.ParseQueryString(handler.Request.RequestUri.Query);
        Assert.Equal("me", query["assignee_type"]);
        Assert.Equal("open", query["status"]);
        Assert.Equal("billing", query["q"]);
        Assert.Equal("7", query["inbox_id"]);
        Assert.Equal("9", query["team_id"]);
        Assert.Equal("2", query["page"]);
        // Labels are joined into a single path placeholder value.
        Assert.Equal("vip,priority", query["labels"]);
    }

    [Fact]
    public async Task GeneratedClientOmitsUnsetConversationListQueryParameters()
    {
        using var handler = new CapturingHandler();
        var services = new ServiceCollection();
        services.AddRefitGeneratedClient<IApplicationConversationsApi>(CreateRefitSettings())
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://example.test/"))
            .AddHttpMessageHandler(() => new OmitEmptyQueryParametersHandler())
            .ConfigurePrimaryHttpMessageHandler(() => handler);

        using var serviceProvider = services.BuildServiceProvider();
        var api = serviceProvider.GetRequiredService<IApplicationConversationsApi>();

        await api.ConversationListAsync(12, cancellationToken: TestContext.Current.CancellationToken);

        Assert.Equal(
            "/api/v1/accounts/12/conversations",
            handler.Request!.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GeneratedClientOmitsOnlyUnsetConversationListQueryParameters()
    {
        using var handler = new CapturingHandler();
        var services = new ServiceCollection();
        services.AddRefitGeneratedClient<IApplicationConversationsApi>(CreateRefitSettings())
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://example.test/"))
            .AddHttpMessageHandler(() => new OmitEmptyQueryParametersHandler())
            .ConfigurePrimaryHttpMessageHandler(() => handler);

        using var serviceProvider = services.BuildServiceProvider();
        var api = serviceProvider.GetRequiredService<IApplicationConversationsApi>();

        await api.ConversationListAsync(12, status: ConversationStatus.Open, page: 2, cancellationToken: TestContext.Current.CancellationToken);

        Assert.Equal("/api/v1/accounts/12/conversations", handler.Request!.RequestUri!.AbsolutePath);

        var query = HttpUtility.ParseQueryString(handler.Request.RequestUri.Query);
        Assert.Equal("open", query["status"]);
        Assert.Equal("2", query["page"]);
        Assert.Null(query["assignee_type"]);
        Assert.Null(query["q"]);
        Assert.Null(query["inbox_id"]);
        Assert.Null(query["team_id"]);
        Assert.Null(query["labels"]);
    }

    [Fact]
    public async Task GeneratedClientSendsConversationFilterPageQuery()
    {
        using var handler = new CapturingHandler();
        var services = new ServiceCollection();
        services.AddRefitGeneratedClient<IApplicationConversationsApi>(CreateRefitSettings())
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://example.test/"))
            .AddHttpMessageHandler(() => new OmitEmptyQueryParametersHandler())
            .ConfigurePrimaryHttpMessageHandler(() => handler);

        using var serviceProvider = services.BuildServiceProvider();
        var api = serviceProvider.GetRequiredService<IApplicationConversationsApi>();

        await api.ConversationFilterAsync(12, new FilterPayload(), page: 3, cancellationToken: TestContext.Current.CancellationToken);

        Assert.Equal(HttpMethod.Post, handler.Request!.Method);
        Assert.Equal(
            "/api/v1/accounts/12/conversations/filter?page=3",
            handler.Request.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GeneratedClientOmitsConversationFilterPageWhenUnset()
    {
        using var handler = new CapturingHandler();
        var services = new ServiceCollection();
        services.AddRefitGeneratedClient<IApplicationConversationsApi>(CreateRefitSettings())
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://example.test/"))
            .AddHttpMessageHandler(() => new OmitEmptyQueryParametersHandler())
            .ConfigurePrimaryHttpMessageHandler(() => handler);

        using var serviceProvider = services.BuildServiceProvider();
        var api = serviceProvider.GetRequiredService<IApplicationConversationsApi>();

        await api.ConversationFilterAsync(12, new FilterPayload(), page: null, cancellationToken: TestContext.Current.CancellationToken);

        Assert.Equal(
            "/api/v1/accounts/12/conversations/filter",
            handler.Request!.RequestUri!.PathAndQuery);
    }

    [Fact]
    public void ConversationListAsyncPublicEntryPointPreservesOptionalParameters()
    {
        var methods = typeof(IApplicationConversationsApi)
            .GetMethods()
            .Where(method => method.Name == nameof(IApplicationConversationsApi.ConversationListAsync))
            .ToArray();

        var publicEntry = methods.Single(method =>
            method.GetParameters().Any(parameter => parameter.Name == "assigneeType" && parameter.HasDefaultValue));

        var parameters = publicEntry.GetParameters();
        Assert.Collection(
            parameters,
            accountId => Assert.Equal(typeof(long), accountId.ParameterType),
            assigneeType =>
            {
                Assert.Equal("assigneeType", assigneeType.Name);
                Assert.Equal(typeof(ConversationAssigneeType?), assigneeType.ParameterType);
            },
            status => Assert.Equal(typeof(ConversationStatus?), status.ParameterType),
            q => Assert.Equal(typeof(string), q.ParameterType),
            inboxId =>
            {
                Assert.Equal("inboxId", inboxId.Name);
                Assert.Equal(typeof(long?), inboxId.ParameterType);
            },
            teamId =>
            {
                Assert.Equal("teamId", teamId.Name);
                Assert.Equal(typeof(long?), teamId.ParameterType);
            },
            labels => Assert.Equal(typeof(IEnumerable<string>), labels.ParameterType),
            page => Assert.Equal(typeof(long?), page.ParameterType),
            cancellationToken => Assert.Equal(typeof(CancellationToken), cancellationToken.ParameterType));
    }

    [Fact]
    public void ConversationListAsyncGeneratedPathUsesDocumentedQueryPlaceholders()
    {
        var pathMethod = typeof(IApplicationConversationsApi)
            .GetMethods()
            .Single(method =>
                method.Name == nameof(IApplicationConversationsApi.ConversationListAsync) &&
                method.GetCustomAttribute<GetAttribute>() is not null);

        var get = pathMethod.GetCustomAttribute<GetAttribute>();
        Assert.NotNull(get);
        Assert.Contains("assignee_type={assigneeType}", get.Path);
        Assert.Contains("status={status}", get.Path);
        Assert.Contains("q={q}", get.Path);
        Assert.Contains("inbox_id={inboxId}", get.Path);
        Assert.Contains("team_id={teamId}", get.Path);
        Assert.Contains("labels={labels}", get.Path);
        Assert.Contains("page={page}", get.Path);

        // Path-template method must not rely on [Query] attributes.
        Assert.All(
            pathMethod.GetParameters(),
            parameter => Assert.Empty(parameter.GetCustomAttributes(typeof(QueryAttribute), inherit: true)));
    }

    private static RefitSettings CreateRefitSettings()
    {
        return new RefitSettings
        {
            UrlParameterFormatter = new ChatWootUrlParameterFormatter(),
        };
    }

    private sealed class CapturingHandler : HttpMessageHandler
    {
        public HttpRequestMessage? Request { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            Request = request;
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{}", System.Text.Encoding.UTF8, "application/json"),
            });
        }
    }
}
