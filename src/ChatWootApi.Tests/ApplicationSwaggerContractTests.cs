using ChatWootApi.Application;
using ChatWootApi.Application.Models;
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

    private static MethodInfo GetMethod(Type interfaceType, string methodName)
    {
        var method = interfaceType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);

        Assert.NotNull(method);
        return method;
    }
}
