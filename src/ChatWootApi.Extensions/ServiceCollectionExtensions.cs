using ChatWootApi.AccessTokens;
using ChatWootApi.Application;
using ChatWootApi.Client;
using ChatWootApi.Other;
using ChatWootApi.Platform;
using ChatWootApi.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Refit;
using System.Text.Json;

namespace ChatWootApi.Extensions;

public static class ServiceCollectionExtensions
{
    private static readonly Lazy<RefitSettings> SharedRefitSettings = new(CreateSharedRefitSettings);

    public static IServiceCollection AddChatWootApplicationApi(
        this IServiceCollection services,
        IConfiguration configuration,
        string sectionName = ChatWootApiOptions.DefaultSectionName)
    {
        services.AddChatWootApiOptions(configuration, sectionName);

        return services.AddChatWootApplicationApiCore();
    }

    public static IServiceCollection AddChatWootApplicationApi(
        this IServiceCollection services,
        Action<ChatWootApiOptions> configureOptions)
    {
        services.Configure(configureOptions);

        return services.AddChatWootApplicationApiCore();
    }

    public static IServiceCollection AddChatWootClientApi(
        this IServiceCollection services,
        IConfiguration configuration,
        string sectionName = ChatWootApiOptions.DefaultSectionName)
    {
        services.AddChatWootApiOptions(configuration, sectionName);

        return services.AddChatWootClientApiCore();
    }

    public static IServiceCollection AddChatWootClientApi(
        this IServiceCollection services,
        Action<ChatWootApiOptions> configureOptions)
    {
        services.Configure(configureOptions);

        return services.AddChatWootClientApiCore();
    }

    public static IServiceCollection AddChatWootOtherApi(
        this IServiceCollection services,
        IConfiguration configuration,
        string sectionName = ChatWootApiOptions.DefaultSectionName)
    {
        services.AddChatWootApiOptions(configuration, sectionName);

        return services.AddChatWootOtherApiCore();
    }

    public static IServiceCollection AddChatWootOtherApi(
        this IServiceCollection services,
        Action<ChatWootApiOptions> configureOptions)
    {
        services.Configure(configureOptions);

        return services.AddChatWootOtherApiCore();
    }


    public static IServiceCollection AddChatWootPlatformApi(
        this IServiceCollection services,
        IConfiguration configuration,
        string sectionName = ChatWootApiOptions.DefaultSectionName)
    {
        services.AddChatWootApiOptions(configuration, sectionName);

        return services.AddChatWootPlatformApiCore();
    }

    public static IServiceCollection AddChatWootPlatformApi(
        this IServiceCollection services,
        Action<ChatWootApiOptions> configureOptions)
    {
        services.Configure(configureOptions);

        return services.AddChatWootPlatformApiCore();
    }

    private static IServiceCollection AddChatWootApiOptions(
        this IServiceCollection services,
        IConfiguration configuration,
        string sectionName)
    {
        if (services.Any(descriptor =>
            descriptor.ServiceType == typeof(ChatWootApiOptionsConfigurationMarker) &&
            descriptor.ImplementationInstance is ChatWootApiOptionsConfigurationMarker marker &&
            marker.SectionName == sectionName))
        {
            return services;
        }

        services.AddSingleton(new ChatWootApiOptionsConfigurationMarker(sectionName));
        services.AddOptions<ChatWootApiOptions>()
            .Bind(configuration.GetSection(sectionName));

        return services;
    }

    private static IServiceCollection AddChatWootClientApiCore(this IServiceCollection services)
    {
        services.AddClientRefitClient<IClientInboxApi>();
        services.AddClientRefitClient<IClientContactApi>();
        services.AddClientRefitClient<IClientConversationApi>();
        services.AddClientRefitClient<IClientMessageApi>();

        return services;
    }

    private static IServiceCollection AddChatWootOtherApiCore(this IServiceCollection services)
    {
        services.AddOtherRefitClient<IOtherCsatSurveyPageApi>();

        return services;
    }

    private static IServiceCollection AddChatWootApplicationApiCore(this IServiceCollection services)
    {
        services.AddAccessTokenServices();

        services.AddApplicationRefitClient<IApplicationAccountApi>();
        services.AddApplicationRefitClient<IApplicationAccountAgentBotsApi>();
        services.AddApplicationRefitClient<IApplicationAgentsApi>();
        services.AddApplicationRefitClient<IApplicationAuditLogsApi>();
        services.AddApplicationRefitClient<IApplicationAutomationRuleApi>();
        services.AddApplicationRefitClient<IApplicationCannedResponsesApi>();
        services.AddApplicationRefitClient<IApplicationContactLabelsApi>();
        services.AddApplicationRefitClient<IApplicationContactsApi>();
        services.AddApplicationRefitClient<IApplicationConversationAssignmentsApi>();
        services.AddApplicationRefitClient<IApplicationConversationsApi>();
        services.AddApplicationRefitClient<IApplicationCustomAttributesApi>();
        services.AddApplicationRefitClient<IApplicationCustomFiltersApi>();
        services.AddApplicationRefitClient<IApplicationHelpCenterApi>();
        services.AddApplicationRefitClient<IApplicationInboxesApi>();
        services.AddApplicationRefitClient<IApplicationIntegrationsApi>();
        services.AddApplicationRefitClient<IApplicationLabelsApi>();
        services.AddApplicationRefitClient<IApplicationMessagesApi>();
        services.AddApplicationRefitClient<IApplicationProfileApi>();
        services.AddApplicationRefitClient<IApplicationReportsApi>();
        services.AddApplicationRefitClient<IApplicationTeamsApi>();
        services.AddApplicationRefitClient<IApplicationWebhooksApi>();

        return services;
    }

    private static IServiceCollection AddChatWootPlatformApiCore(this IServiceCollection services)
    {
        services.AddAccessTokenServices();

        services.AddPlatformRefitClient<IPlatformAccountApi>();
        services.AddPlatformRefitClient<IPlatformAccountUserApi>();
        services.AddPlatformRefitClient<IPlatformAgentBotApi>();
        services.AddPlatformRefitClient<IPlatformUserApi>();

        return services;
    }

    private static IServiceCollection AddAccessTokenServices(this IServiceCollection services)
    {
        services.TryAddSingleton<AccessTokenProvider>();
        services.TryAddSingleton<IAccessTokenProvider>(serviceProvider => serviceProvider.GetRequiredService<AccessTokenProvider>());
        services.TryAddTransient<AccountAccessTokenDelegatingHandler>();
        services.TryAddTransient<PlatformAccessTokenDelegatingHandler>();

        return services;
    }

    private static IHttpClientBuilder AddClientRefitClient<TApi>(this IServiceCollection services)
        where TApi : class
    {
        return services.AddRefitGeneratedClient<TApi>(CreateRefitSettings())
            .ConfigureHttpClient(ConfigureBaseAddress);
    }

    private static IHttpClientBuilder AddOtherRefitClient<TApi>(this IServiceCollection services)
        where TApi : class
    {
        return services.AddRefitGeneratedClient<TApi>(CreateRefitSettings())
            .ConfigureHttpClient(ConfigureBaseAddress);
    }

    private static IHttpClientBuilder AddApplicationRefitClient<TApi>(this IServiceCollection services)
        where TApi : class
    {
        return services.AddRefitGeneratedClient<TApi>(CreateRefitSettings())
            .ConfigureHttpClient(ConfigureBaseAddress)
            .AddHttpMessageHandler<AccountAccessTokenDelegatingHandler>();
    }

    private static IHttpClientBuilder AddPlatformRefitClient<TApi>(this IServiceCollection services)
        where TApi : class
    {
        return services.AddRefitGeneratedClient<TApi>(CreateRefitSettings())
            .ConfigureHttpClient(ConfigureBaseAddress)
            .AddHttpMessageHandler<PlatformAccessTokenDelegatingHandler>();
    }

    private static RefitSettings CreateRefitSettings() => SharedRefitSettings.Value;

    private static RefitSettings CreateSharedRefitSettings()
    {
        var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            TypeInfoResolver = ChatWootJsonSerializerContext.Default
        };

        return new RefitSettings(new SystemTextJsonContentSerializer(jsonOptions));
    }

    private static void ConfigureBaseAddress(IServiceProvider serviceProvider, HttpClient httpClient)
    {
        var options = serviceProvider.GetRequiredService<IOptionsMonitor<ChatWootApiOptions>>();
        httpClient.BaseAddress = options.CurrentValue.GetBaseAddress();
    }

    private sealed record ChatWootApiOptionsConfigurationMarker(string SectionName);
}
