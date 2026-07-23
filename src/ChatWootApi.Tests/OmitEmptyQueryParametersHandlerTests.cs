using System.Net;
using ChatWootApi.Extensions;

namespace ChatWootApi.Tests;

public sealed class OmitEmptyQueryParametersHandlerTests
{
    [Fact]
    public async Task RemovesEmptyQueryValuesFromRelativeUri()
    {
        using var inner = new CapturingHandler();
        using var handler = new OmitEmptyQueryParametersHandler { InnerHandler = inner };

        using var invoker = new HttpMessageInvoker(handler);
        using var request = new HttpRequestMessage(
            HttpMethod.Get,
            "/api/v1/accounts/12/conversations?assignee_type=&status=open&q=&inbox_id=&team_id=&labels=&page=2");

        await invoker.SendAsync(request, CancellationToken.None);

        Assert.Equal(
            "/api/v1/accounts/12/conversations?status=open&page=2",
            inner.Request!.RequestUri!.OriginalString);
    }

    [Fact]
    public async Task RemovesEntireQueryWhenAllValuesEmpty()
    {
        using var inner = new CapturingHandler();
        using var handler = new OmitEmptyQueryParametersHandler { InnerHandler = inner };

        using var invoker = new HttpMessageInvoker(handler);
        using var request = new HttpRequestMessage(
            HttpMethod.Get,
            "/api/v1/accounts/12/conversations?assignee_type=&status=&q=&inbox_id=&team_id=&labels=&page=");

        await invoker.SendAsync(request, CancellationToken.None);

        Assert.Equal(
            "/api/v1/accounts/12/conversations",
            inner.Request!.RequestUri!.OriginalString);
    }

    [Fact]
    public async Task LeavesNonEmptyQueryUnchanged()
    {
        using var inner = new CapturingHandler();
        using var handler = new OmitEmptyQueryParametersHandler { InnerHandler = inner };

        using var invoker = new HttpMessageInvoker(handler);
        using var request = new HttpRequestMessage(
            HttpMethod.Get,
            "/api/v1/accounts/12/conversations?status=open&page=2");

        await invoker.SendAsync(request, CancellationToken.None);

        Assert.Equal(
            "/api/v1/accounts/12/conversations?status=open&page=2",
            inner.Request!.RequestUri!.OriginalString);
    }

    [Fact]
    public async Task RemovesEmptyQueryValuesFromAbsoluteUri()
    {
        using var inner = new CapturingHandler();
        using var handler = new OmitEmptyQueryParametersHandler { InnerHandler = inner };

        using var invoker = new HttpMessageInvoker(handler);
        using var request = new HttpRequestMessage(
            HttpMethod.Get,
            "https://example.test/api/v1/accounts/12/conversations?status=open&team_id=&page=");

        await invoker.SendAsync(request, CancellationToken.None);

        Assert.Equal(
            "https://example.test/api/v1/accounts/12/conversations?status=open",
            inner.Request!.RequestUri!.AbsoluteUri);
    }

    private sealed class CapturingHandler : HttpMessageHandler
    {
        public HttpRequestMessage? Request { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            Request = request;
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
}
