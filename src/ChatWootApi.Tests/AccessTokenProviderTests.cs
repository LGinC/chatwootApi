using ChatWootApi;
using ChatWootApi.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;

namespace ChatWootApi.Tests;

public sealed class AccessTokenProviderTests
{
    [Fact]
    public async Task ScopedApplicationAccessTokenOverridesConfiguredAccountTokenAndDisposalRestoresConfiguredToken()
    {
        var provider = CreateProvider(accountAccessToken: "configured-account");

        using (provider.UseApplicationAccessToken("scoped-account"))
        {
            var scopedToken = await provider.GetAccessTokenAsync(AccessTokenKind.Account);

            Assert.Equal("scoped-account", scopedToken);
        }

        var restoredToken = await provider.GetAccessTokenAsync(AccessTokenKind.Account);

        Assert.Equal("configured-account", restoredToken);
    }

    [Fact]
    public async Task ScopedApplicationAccessTokenCanBeUsedWithoutConfiguredAccountToken()
    {
        var provider = CreateProvider(accountAccessToken: null);

        using (provider.UseApplicationAccessToken("scoped-account"))
        {
            var scopedToken = await provider.GetAccessTokenAsync(AccessTokenKind.Account);

            Assert.Equal("scoped-account", scopedToken);
        }
    }

    [Fact]
    public async Task NestedApplicationAccessTokenScopesRestoreOuterTokenWhenInnerScopeIsDisposed()
    {
        var provider = CreateProvider(accountAccessToken: "configured-account");

        using (provider.UseApplicationAccessToken("outer-account"))
        {
            using (provider.UseApplicationAccessToken("inner-account"))
            {
                var innerToken = await provider.GetAccessTokenAsync(AccessTokenKind.Account);

                Assert.Equal("inner-account", innerToken);
            }

            var restoredOuterToken = await provider.GetAccessTokenAsync(AccessTokenKind.Account);

            Assert.Equal("outer-account", restoredOuterToken);
        }
    }

    [Fact]
    public async Task PlatformTokenContinuesToUseConfiguredTokenInsideApplicationAccessTokenScope()
    {
        var provider = CreateProvider(
            accountAccessToken: "configured-account",
            platformAccessToken: "configured-platform");

        using (provider.UseApplicationAccessToken("scoped-account"))
        {
            var platformToken = await provider.GetAccessTokenAsync(AccessTokenKind.Platform);

            Assert.Equal("configured-platform", platformToken);
        }
    }

    [Fact]
    public async Task MissingAccountTokenOutsideApplicationAccessTokenScopeStillThrows()
    {
        var provider = CreateProvider(accountAccessToken: null);

        var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await provider.GetAccessTokenAsync(AccessTokenKind.Account));

        Assert.Equal(
            "ChatWootApiOptions.AccountAccessToken is required for Account API calls.",
            exception.Message);
    }

    [Fact]
    public void AddChatWootApplicationApiRegistersConcreteAccessTokenProviderForScopedTokenUsage()
    {
        var services = new ServiceCollection();

        services.AddChatWootApplicationApi(options =>
        {
            options.BaseAddress = "https://example.test/";
            options.AccountAccessToken = "configured-account";
        });

        using var provider = services.BuildServiceProvider(new ServiceProviderOptions
        {
            ValidateOnBuild = true,
            ValidateScopes = true,
        });

        var concreteProvider = provider.GetRequiredService<AccessTokenProvider>();
        var interfaceProvider = provider.GetRequiredService<IAccessTokenProvider>();

        Assert.Same(concreteProvider, interfaceProvider);
    }

    private static AccessTokenProvider CreateProvider(
        string? accountAccessToken = null,
        string? platformAccessToken = null)
    {
        var options = new ChatWootApiOptions
        {
            AccountAccessToken = accountAccessToken,
            PlatformAccessToken = platformAccessToken,
        };

        return new AccessTokenProvider(new TestOptionsMonitor(options));
    }

    private sealed class TestOptionsMonitor(ChatWootApiOptions currentValue) : IOptionsMonitor<ChatWootApiOptions>
    {
        public ChatWootApiOptions CurrentValue => currentValue;

        public ChatWootApiOptions Get(string? name) => currentValue;

        public IDisposable OnChange(Action<ChatWootApiOptions, string?> listener) => NoopDisposable.Instance;
    }

    private sealed class NoopDisposable : IDisposable
    {
        public static readonly NoopDisposable Instance = new();

        public void Dispose()
        {
        }
    }
}
