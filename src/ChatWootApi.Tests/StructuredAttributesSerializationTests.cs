using System.Text.Json;
using ChatWootApi.Application.Models;
using ChatWootApi.Serialization;
using ClientMessage = ChatWootApi.Client.Models.Message;
using ClientMessageSender = ChatWootApi.Client.Models.MessageSender;

namespace ChatWootApi.Tests;

public sealed class StructuredAttributesSerializationTests
{
    [Fact]
    public void ContactListItemDeserializesAdditionalAttributes()
    {
        const string json = """
            {
              "id": 9,
              "name": "Alice",
              "additional_attributes": {
                "city": "Berlin",
                "country": "Germany",
                "country_code": "DE",
                "created_at_ip": "203.0.113.10"
              }
            }
            """;

        var item = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationContactListItem);

        Assert.NotNull(item?.AdditionalAttributes);
        Assert.Equal("Berlin", item.AdditionalAttributes.City);
        Assert.Equal("Germany", item.AdditionalAttributes.Country);
        Assert.Equal("DE", item.AdditionalAttributes.CountryCode);
        Assert.Equal("203.0.113.10", item.AdditionalAttributes.CreatedAtIp);
    }

    [Fact]
    public void ConversationMetaDeserializesBrowserAdditionalAttributes()
    {
        const string json = """
            {
              "labels": ["vip"],
              "additional_attributes": {
                "browser": {
                  "browser_name": "Chrome",
                  "browser_version": "120.0",
                  "platform_name": "Windows",
                  "platform_version": "11",
                  "device_name": "Desktop"
                },
                "referer": "https://example.test",
                "initiated_at": {
                  "timestamp": "2026-01-01T00:00:00Z"
                },
                "browser_language": "en-US",
                "conversation_language": "en"
              }
            }
            """;

        var meta = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationConversationMeta);

        Assert.NotNull(meta?.AdditionalAttributes);
        Assert.Equal("https://example.test", meta.AdditionalAttributes.Referer);
        Assert.Equal("en-US", meta.AdditionalAttributes.BrowserLanguage);
        Assert.Equal("en", meta.AdditionalAttributes.ConversationLanguage);
        Assert.Equal("Chrome", meta.AdditionalAttributes.Browser!.BrowserName);
        Assert.Equal("120.0", meta.AdditionalAttributes.Browser.BrowserVersion);
        Assert.Equal("Windows", meta.AdditionalAttributes.Browser.PlatformName);
        Assert.Equal("11", meta.AdditionalAttributes.Browser.PlatformVersion);
        Assert.Equal("Desktop", meta.AdditionalAttributes.Browser.DeviceName);
        Assert.Equal("2026-01-01T00:00:00Z", meta.AdditionalAttributes.InitiatedAt!.Timestamp);
    }

    [Fact]
    public void AccountDetailDeserializesCustomAttributes()
    {
        const string json = """
            {
              "id": 1,
              "name": "Acme",
              "custom_attributes": {
                "plan_name": "Enterprise",
                "subscribed_quantity": 42,
                "subscription_status": "active",
                "industry": "SaaS",
                "company_size": "51-200",
                "timezone": "UTC"
              }
            }
            """;

        var detail = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationAccountDetail);

        Assert.NotNull(detail?.CustomAttributes);
        Assert.Equal("Enterprise", detail.CustomAttributes.PlanName);
        Assert.Equal(42, detail.CustomAttributes.SubscribedQuantity);
        Assert.Equal("active", detail.CustomAttributes.SubscriptionStatus);
        Assert.Equal("SaaS", detail.CustomAttributes.Industry);
        Assert.Equal("51-200", detail.CustomAttributes.CompanySize);
        Assert.Equal("UTC", detail.CustomAttributes.Timezone);
    }

    [Fact]
    public void ClientMessageDeserializesContentTypeAndSenderEnums()
    {
        const string json = """
            {
              "id": 3,
              "message_type": 1,
              "content_type": "text",
              "sender": {
                "id": 8,
                "type": "user",
                "availability_status": "online"
              }
            }
            """;

        var message = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiClientMessage);

        Assert.Equal(MessageType.Outgoing, message!.MessageType);
        Assert.Equal(MessageContentType.Text, message.ContentType);
        Assert.Equal(PublicMessageSenderType.User, message.Sender!.Type);
        Assert.Equal(AgentAvailability.Online, message.Sender.AvailabilityStatus);
    }

    [Fact]
    public void PublicMessageSenderDeserializesAvailabilityStatus()
    {
        const string json = """
            {
              "id": 5,
              "type": "contact",
              "availability_status": "offline"
            }
            """;

        var sender = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationPublicMessageSender);

        Assert.Equal(PublicMessageSenderType.Contact, sender!.Type);
        Assert.Equal(AgentAvailability.Offline, sender.AvailabilityStatus);
    }

    [Fact]
    public void MessageDetailedDeserializesContentAttributesInReplyTo()
    {
        const string json = """
            {
              "id": 10,
              "content_attributes": {
                "in_reply_to": "99",
                "submitted_values": { "plan": "pro" }
              }
            }
            """;

        var message = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationMessageDetailed);

        Assert.NotNull(message?.ContentAttributes);
        Assert.Equal("99", message.ContentAttributes.InReplyTo);
        Assert.Equal(
            "pro",
            message.ContentAttributes.ExtensionData!["submitted_values"].GetProperty("plan").GetString());
    }

    [Fact]
    public void ConversationDeserializesAdditionalAttributesBrowser()
    {
        const string json = """
            {
              "id": 7,
              "additional_attributes": {
                "browser": {
                  "browser_name": "Safari"
                },
                "referer": "https://docs.example"
              }
            }
            """;

        var conversation = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationConversation);

        Assert.NotNull(conversation?.AdditionalAttributes);
        Assert.Equal("Safari", conversation.AdditionalAttributes.Browser!.BrowserName);
        Assert.Equal("https://docs.example", conversation.AdditionalAttributes.Referer);
    }

    [Fact]
    public void PortalConfigDeserializesAllowedLocaleObjects()
    {
        const string json = """
            {
              "allowed_locales": [
                { "code": "en", "articles_count": 12, "categories_count": 3 },
                { "code": "zh", "articles_count": 4, "categories_count": 1 }
              ]
            }
            """;

        var config = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationPortalConfig);

        Assert.NotNull(config?.AllowedLocales);
        Assert.Equal(2, config.AllowedLocales.Count);
        Assert.Equal("en", config.AllowedLocales[0]!.Code);
        Assert.Equal(12, config.AllowedLocales[0].ArticlesCount);
        Assert.Equal(3, config.AllowedLocales[0].CategoriesCount);
        Assert.Equal("zh", config.AllowedLocales[1]!.Code);
    }

    [Fact]
    public void PortalCreateUpdatePayloadSerializesConfig()
    {
        var payload = new PortalCreateUpdatePayload
        {
            Name = "Help",
            Config = new PortalCreateUpdateConfig
            {
                AllowedLocales = ["en", "es"],
                DefaultLocale = "en"
            }
        };

        var json = JsonSerializer.Serialize(
            payload,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationPortalCreateUpdatePayload);

        Assert.Contains("\"allowed_locales\":[\"en\",\"es\"]", json);
        Assert.Contains("\"default_locale\":\"en\"", json);
    }
}
