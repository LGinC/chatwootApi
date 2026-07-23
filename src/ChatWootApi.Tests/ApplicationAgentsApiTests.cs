using System.Net;
using System.Text.Json;
using ChatWootApi.Application;
using ChatWootApi.Application.Models;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace ChatWootApi.Tests;

public sealed class ApplicationAgentsApiTests
{
    [Fact]
    public async Task GeneratedClientSerializesExtensionDataAndDeserializesAgentResponse()
    {
        using var handler = new CapturingHandler(
            """
            {
              "id": 42,
              "name": "Ada",
              "custom_role_id": 7,
              "custom_response_field": "from-chatwoot"
            }
            """);
        var services = new ServiceCollection();
        services.AddRefitGeneratedClient<IApplicationAgentsApi>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://example.test/"))
            .ConfigurePrimaryHttpMessageHandler(() => handler);

        using var serviceProvider = services.BuildServiceProvider();
        var api = serviceProvider.GetRequiredService<IApplicationAgentsApi>();

        var agent = await api.AddNewAgentToAccountAsync(
            12,
            new AgentCreatePayload(new Dictionary<string, object>
            {
                ["custom_role_id"] = 7,
                ["welcome_message"] = new { Text = "Hello" },
            }),
            cancellationToken: TestContext.Current.CancellationToken);

        Assert.Equal(HttpMethod.Post, handler.Request!.Method);
        Assert.Equal("/api/v1/accounts/12/agents", handler.Request.RequestUri!.AbsolutePath);

        using var requestDocument = JsonDocument.Parse(handler.RequestBody);
        Assert.Equal(7, requestDocument.RootElement.GetProperty("custom_role_id").GetInt32());
        Assert.Equal(
            "Hello",
            requestDocument.RootElement.GetProperty("welcome_message").GetProperty("text").GetString());

        Assert.Equal(42, agent.Id);
        Assert.Equal("Ada", agent.Name);
        Assert.Equal(
            "from-chatwoot",
            agent.ExtensionData!["custom_response_field"].GetString());
    }

    private sealed class CapturingHandler(string responseJson) : HttpMessageHandler
    {
        public HttpRequestMessage? Request { get; private set; }

        public string RequestBody { get; private set; } = string.Empty;

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            Request = request;
            RequestBody = await request.Content!.ReadAsStringAsync(cancellationToken);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(responseJson, System.Text.Encoding.UTF8, "application/json"),
            };
        }
    }
}
