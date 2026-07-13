using ChatWootApi.Client;
using TypingStatus = ChatWootApi.Application.Models.TypingStatus;
using System.Reflection;
using System.Text.Json;
using Refit;
using ChatWootApi.Client.Models;

namespace ChatWootApi.Tests;

public sealed class ClientSwaggerContractTests
{
    [Fact]
    public void ToggleTypingUsesDocumentedQueryAndBodyParameters()
    {
        var method = GetMethod(
            typeof(IClientConversationApi),
            nameof(IClientConversationApi.ToggleTypingAsync));

        var parameters = method.GetParameters();
        Assert.Collection(
            parameters,
            inboxIdentifier => Assert.Equal("inboxIdentifier", inboxIdentifier.Name),
            contactIdentifier => Assert.Equal("contactIdentifier", contactIdentifier.Name),
            conversationId => Assert.Equal("conversationId", conversationId.Name),
            typingStatus =>
            {
                var alias = typingStatus.GetCustomAttribute<AliasAsAttribute>();
                Assert.NotNull(alias);
                Assert.Equal("typing_status", alias.Name);
            },
            payload =>
            {
                Assert.Equal("payload", payload.Name);
                Assert.Equal(typeof(ConversationTypingStatusPayload), payload.ParameterType);
                Assert.NotNull(payload.GetCustomAttribute<BodyAttribute>());
            },
            cancellationToken => Assert.Equal("cancellationToken", cancellationToken.Name));
    }

    [Fact]
    public void ConversationTypingStatusPayloadSerializesSwaggerField()
    {
        var payload = new ConversationTypingStatusPayload
        {
            TypingStatus = TypingStatus.On,
        };

        var json = JsonSerializer.Serialize(payload);

        using var document = JsonDocument.Parse(json);
        Assert.Equal("on", document.RootElement.GetProperty("typing_status").GetString());
    }

    [Fact]
    public void ConversationTypingStatusPayloadDeserializesIgnoringCase()
    {
        var payload = JsonSerializer.Deserialize<ConversationTypingStatusPayload>("""{"typing_status":"OFF"}""");

        Assert.Equal(TypingStatus.Off, payload!.TypingStatus);
    }

    private static MethodInfo GetMethod(Type interfaceType, string methodName)
    {
        var method = interfaceType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);

        Assert.NotNull(method);
        return method;
    }
}
