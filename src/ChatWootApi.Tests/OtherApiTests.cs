using System.Net.Http;
using System.Reflection;
using ChatWootApi;
using ChatWootApi.AccessTokens;
using ChatWootApi.Extensions;
using ChatWootApi.Other;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace ChatWootApi.Tests;

public sealed class OtherApiTests
{
    [Fact]
    public void CsatSurveyPageApiUsesSwaggerRouteTokenAndReturnsRawHttpResponse()
    {
        var method = GetCsatSurveyPageMethod();

        Assert.Equal(typeof(Task<HttpResponseMessage>), method.ReturnType);

        var getAttribute = method.GetCustomAttribute<GetAttribute>();
        Assert.NotNull(getAttribute);
        Assert.Equal("/survey/responses/{conversation_uuid}", getAttribute.Path);
    }

    [Fact]
    public void CsatSurveyPageApiBindsConversationUuidParameterToSwaggerPathToken()
    {
        var method = GetCsatSurveyPageMethod();

        var parameters = method.GetParameters();
        Assert.Collection(
            parameters,
            conversationUuid =>
            {
                Assert.Equal("conversationUuid", conversationUuid.Name);
                Assert.Equal(typeof(long), conversationUuid.ParameterType);

                var alias = conversationUuid.GetCustomAttribute<AliasAsAttribute>();
                Assert.NotNull(alias);
                Assert.Equal("conversation_uuid", alias.Name);
            },
            cancellationToken =>
            {
                Assert.Equal("cancellationToken", cancellationToken.Name);
                Assert.Equal(typeof(CancellationToken), cancellationToken.ParameterType);
                Assert.True(cancellationToken.HasDefaultValue);
            });
    }


    [Fact]
    public void AddChatWootOtherApiRegistersOtherApisWithoutAccessTokenHandlerRequirement()
    {
        var services = new ServiceCollection();

        services.AddChatWootOtherApi(options =>
        {
            options.BaseAddress = "https://example.test/";
        });

        Assert.Contains(services, descriptor => descriptor.ServiceType == typeof(IOtherCsatSurveyPageApi));
        Assert.DoesNotContain(services, descriptor => descriptor.ServiceType == typeof(IAccessTokenProvider));
        Assert.DoesNotContain(services, descriptor => descriptor.ServiceType == typeof(AccountAccessTokenDelegatingHandler));
        Assert.DoesNotContain(services, descriptor => descriptor.ServiceType == typeof(PlatformAccessTokenDelegatingHandler));

        using var provider = services.BuildServiceProvider(new ServiceProviderOptions
        {
            ValidateOnBuild = true,
            ValidateScopes = true,
        });

        Assert.IsAssignableFrom<IOtherCsatSurveyPageApi>(provider.GetRequiredService<IOtherCsatSurveyPageApi>());
    }

    private static MethodInfo GetCsatSurveyPageMethod()
    {
        var method = typeof(IOtherCsatSurveyPageApi).GetMethod(
            nameof(IOtherCsatSurveyPageApi.GetCsatSurveyPageAsync),
            BindingFlags.Instance | BindingFlags.Public);

        Assert.NotNull(method);

        return method;
    }
}
