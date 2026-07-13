using System.Net;
using System.Text;
using ChatWootApi.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ChatWootApi.Tests;

public sealed class HttpLoggingTests
{
    [Fact]
    public async Task EnabledLoggingWritesRequestAndResponseWithoutSensitiveValues()
    {
        var logMessages = new List<string>();
        using var loggerFactory = LoggerFactory.Create(logging =>
        {
            logging.SetMinimumLevel(LogLevel.Information);
            logging.AddProvider(new TestLoggerProvider(logMessages));
        });

        using var loggingHandler = new HttpLoggingDelegatingHandler(
            "IApplicationContactsApi",
            "ChatWootApi.Application.IApplicationContactsApi",
            new TestOptionsMonitor(new ChatWootApiOptions
            {
                EnableLogging = true,
                IncludeBodyInLogs = true,
            }),
            loggerFactory.CreateLogger("ChatWootApi.HttpLogging.IApplicationContactsApi"))
        {
            InnerHandler = new StubHandler(_ => new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(
                    "{\"access_token\":\"response-secret\",\"email\":\"response@example.com\",\"name\":\"Ada\"}",
                    Encoding.UTF8,
                    "application/json"),
            }),
        };

        using var client = new HttpClient(loggingHandler);
        using var request = new HttpRequestMessage(
            HttpMethod.Post,
            "https://example.test/contacts?access_token=query-secret&visible=value")
        {
            Content = new StringContent(
                "{\"api_access_token\":\"body-secret\",\"email\":\"request@example.com\",\"name\":\"Grace\"}",
                Encoding.UTF8,
                "application/json"),
        };
        request.Headers.TryAddWithoutValidation("api_access_token", "header-secret");

        using var response = await client.SendAsync(request);

        var allLogs = string.Join(Environment.NewLine, logMessages);

        Assert.Contains("ChatWoot API request started", allLogs);
        Assert.Contains("ChatWoot API response received", allLogs);
        Assert.Contains("[REDACTED]", allLogs);
        Assert.Contains("visible=value", allLogs);
        Assert.DoesNotContain("query-secret", allLogs);
        Assert.DoesNotContain("header-secret", allLogs);
        Assert.DoesNotContain("body-secret", allLogs);
        Assert.DoesNotContain("response-secret", allLogs);
        Assert.DoesNotContain("request@example.com", allLogs);
        Assert.DoesNotContain("response@example.com", allLogs);
    }

    [Fact]
    public async Task SpecifiedApiLoggingDoesNotLogOtherApis()
    {
        var logMessages = new List<string>();
        using var loggerFactory = LoggerFactory.Create(logging =>
        {
            logging.SetMinimumLevel(LogLevel.Information);
            logging.AddProvider(new TestLoggerProvider(logMessages));
        });

        var options = new TestOptionsMonitor(new ChatWootApiOptions
        {
            LoggingApiNames = ["IApplicationContactsApi"],
        });

        using var selectedHandler = CreateHandler(
            "IApplicationContactsApi",
            options,
            loggerFactory,
            new StubHandler(_ => new HttpResponseMessage(HttpStatusCode.OK)));
        using var unselectedHandler = CreateHandler(
            "IApplicationAgentsApi",
            options,
            loggerFactory,
            new StubHandler(_ => new HttpResponseMessage(HttpStatusCode.OK)));

        using (var selectedClient = new HttpClient(selectedHandler))
        using (var selectedResponse = await selectedClient.GetAsync("https://example.test/selected"))
        {
        }

        using (var unselectedClient = new HttpClient(unselectedHandler))
        using (var unselectedResponse = await unselectedClient.GetAsync("https://example.test/unselected"))
        {
        }

        Assert.Equal(
            2,
            logMessages.Count(message => message.Contains("IApplicationContactsApi", StringComparison.Ordinal)));
        Assert.DoesNotContain(logMessages, message => message.Contains("IApplicationAgentsApi", StringComparison.Ordinal));
    }

    private static HttpLoggingDelegatingHandler CreateHandler(
        string apiName,
        IOptionsMonitor<ChatWootApiOptions> options,
        ILoggerFactory loggerFactory,
        HttpMessageHandler innerHandler)
    {
        return new HttpLoggingDelegatingHandler(
            apiName,
            $"ChatWootApi.Application.{apiName}",
            options,
            loggerFactory.CreateLogger($"ChatWootApi.HttpLogging.{apiName}"))
        {
            InnerHandler = innerHandler,
        };
    }

    private sealed class StubHandler(Func<HttpRequestMessage, HttpResponseMessage> responseFactory) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(responseFactory(request));
        }
    }

    private sealed class TestOptionsMonitor(ChatWootApiOptions currentValue) : IOptionsMonitor<ChatWootApiOptions>
    {
        public ChatWootApiOptions CurrentValue => currentValue;

        public ChatWootApiOptions Get(string? name) => currentValue;

        public IDisposable OnChange(Action<ChatWootApiOptions, string?> listener) => NoopDisposable.Instance;
    }

    private sealed class TestLoggerProvider(ICollection<string> messages) : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName) => new TestLogger(messages);

        public void Dispose()
        {
        }
    }

    private sealed class TestLogger(ICollection<string> messages) : ILogger
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => NoopDisposable.Instance;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            messages.Add(formatter(state, exception));
        }
    }

    private sealed class NoopDisposable : IDisposable
    {
        public static readonly NoopDisposable Instance = new();

        public void Dispose()
        {
        }
    }
}
