using System.Net;
using ChatWootApi.Application;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace ChatWootApi.Tests;

public sealed class ApplicationMessagesApiTests
{
    [Fact]
    public async Task GeneratedClientSendsDocumentedAfterAndBeforeQueryParameters()
    {
        using var handler = new CapturingHandler();
        var services = new ServiceCollection();
        services.AddRefitGeneratedClient<IApplicationMessagesApi>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://example.test/"))
            .ConfigurePrimaryHttpMessageHandler(() => handler);

        using var serviceProvider = services.BuildServiceProvider();
        var api = serviceProvider.GetRequiredService<IApplicationMessagesApi>();

        await api.ListAllMessagesAsync(12, 34, after: 56, before: 78);

        Assert.Equal(HttpMethod.Get, handler.Request!.Method);
        Assert.Equal(
            "/api/v1/accounts/12/conversations/34/messages?after=56&before=78",
            handler.Request.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GeneratedClientOmitsUnsetCursorQueryParameters()
    {
        using var handler = new CapturingHandler();
        var services = new ServiceCollection();
        services.AddRefitGeneratedClient<IApplicationMessagesApi>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://example.test/"))
            .ConfigurePrimaryHttpMessageHandler(() => handler);

        using var serviceProvider = services.BuildServiceProvider();
        var api = serviceProvider.GetRequiredService<IApplicationMessagesApi>();

        await api.ListAllMessagesAsync(12, 34);

        Assert.Equal(
            "/api/v1/accounts/12/conversations/34/messages",
            handler.Request!.RequestUri!.PathAndQuery);
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
