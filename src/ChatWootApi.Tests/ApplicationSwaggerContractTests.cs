using ChatWootApi.Application;
using ChatWootApi.Application.Models;
using Refit;
using System.Reflection;

namespace ChatWootApi.Tests;

public sealed class ApplicationSwaggerContractTests
{
    [Fact]
    public void ContactUpdateReturnsDocumentedContactBaseResponse()
    {
        var method = GetMethod(
            typeof(IApplicationContactsApi),
            nameof(IApplicationContactsApi.ContactUpdateAsync));

        Assert.Equal(typeof(Task<ContactBase>), method.ReturnType);
    }

    [Fact]
    public void GetInboxAgentBotReturnsDocumentedAgentBotResponse()
    {
        var method = GetMethod(
            typeof(IApplicationInboxesApi),
            nameof(IApplicationInboxesApi.GetInboxAgentBotAsync));

        Assert.Equal(typeof(Task<AgentBot>), method.ReturnType);
    }

    [Fact]
    public void AddNewAgentToInboxMatchesSwaggerRequestAndResponse()
    {
        var method = GetMethod(
            typeof(IApplicationInboxesApi),
            nameof(IApplicationInboxesApi.AddNewAgentToInboxAsync));

        Assert.Equal(typeof(Task<InboxMembersResponse>), method.ReturnType);

        var parameters = method.GetParameters();
        Assert.Collection(
            parameters,
            accountId => Assert.Equal(typeof(long), accountId.ParameterType),
            payload =>
            {
                Assert.Equal(typeof(InboxMembersCreatePayload), payload.ParameterType);
                Assert.NotNull(payload.GetCustomAttribute<BodyAttribute>());
            },
            cancellationToken => Assert.Equal(typeof(CancellationToken), cancellationToken.ParameterType));
    }

    [Fact]
    public void ListAllMessagesUsesDocumentedCursorQueryParameters()
    {
        var method = GetMethod(
            typeof(IApplicationMessagesApi),
            nameof(IApplicationMessagesApi.ListAllMessagesAsync));

        var parameters = method.GetParameters();
        Assert.Collection(
            parameters,
            accountId => Assert.Equal(typeof(long), accountId.ParameterType),
            conversationId => Assert.Equal(typeof(long), conversationId.ParameterType),
            after => Assert.Equal(typeof(long?), after.ParameterType),
            before => Assert.Equal(typeof(long?), before.ParameterType),
            cancellationToken => Assert.Equal(typeof(CancellationToken), cancellationToken.ParameterType));
    }

    private static MethodInfo GetMethod(Type interfaceType, string methodName)
    {
        var method = interfaceType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);

        Assert.NotNull(method);
        return method;
    }
}
