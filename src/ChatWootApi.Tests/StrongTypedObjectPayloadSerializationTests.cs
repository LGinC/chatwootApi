using System.Text.Json;
using ChatWootApi.Application.Models;
using ChatWootApi.Serialization;

namespace ChatWootApi.Tests;

public sealed class StrongTypedObjectPayloadSerializationTests
{
    [Fact]
    public void ConversationCreatePayloadSerializesInitialMessageAndTemplate()
    {
        var payload = new ConversationCreatePayload
        {
            InboxId = 1,
            ContactId = 2,
            Message = new ConversationCreateMessage
            {
                Content = "Hello, how can I help you?",
                TemplateParams = new WhatsAppTemplateParams
                {
                    Name = "sample_issue_resolution",
                    Category = WhatsAppTemplateCategory.Utility,
                    Language = "en_US",
                    ProcessedParams = new WhatsAppTemplateProcessedParams
                    {
                        Body = new Dictionary<string, string> { ["1"] = "Chatwoot" }
                    }
                }
            }
        };

        var json = JsonSerializer.Serialize(
            payload,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationConversationCreatePayload);

        Assert.Contains("\"content\":\"Hello, how can I help you?\"", json);
        Assert.Contains("\"name\":\"sample_issue_resolution\"", json);
        Assert.Contains("\"category\":\"UTILITY\"", json);
        Assert.Contains("\"1\":\"Chatwoot\"", json);
    }

    [Fact]
    public void ConversationCreatePayloadDeserializesInitialMessage()
    {
        const string json = """
            {
              "message": {
                "content": "Hi there",
                "template_params": {
                  "name": "welcome",
                  "category": "MARKETING",
                  "language": "en"
                }
              }
            }
            """;

        var payload = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationConversationCreatePayload);

        Assert.NotNull(payload?.Message);
        Assert.Equal("Hi there", payload.Message.Content);
        Assert.Equal("welcome", payload.Message.TemplateParams!.Name);
        Assert.Equal(WhatsAppTemplateCategory.Marketing, payload.Message.TemplateParams.Category);
        Assert.Equal("en", payload.Message.TemplateParams.Language);
    }

    [Fact]
    public void AccountDetailDeserializesSettings()
    {
        const string json = """
            {
              "id": 12,
              "name": "Acme",
              "settings": {
                "auto_resolve_after": 1440,
                "auto_resolve_message": "Closing now",
                "auto_resolve_ignore_waiting": true
              }
            }
            """;

        var detail = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationAccountDetail);

        Assert.Equal(12, detail!.Id);
        Assert.NotNull(detail.Settings);
        Assert.Equal(1440, detail.Settings.AutoResolveAfter);
        Assert.Equal("Closing now", detail.Settings.AutoResolveMessage);
        Assert.True(detail.Settings.AutoResolveIgnoreWaiting);
    }

    [Fact]
    public void WhatsAppChannelPayloadSerializesProviderConfig()
    {
        var channel = new InboxCreateWhatsappChannelPayload
        {
            Type = "whatsapp",
            PhoneNumber = "+15551234567",
            Provider = WhatsAppProvider.WhatsappCloud,
            ProviderConfig = new WhatsAppProviderConfig
            {
                ApiKey = "your-api-key",
                PhoneNumberId = "phone-id",
                BusinessAccountId = "biz-id"
            }
        };

        var payload = new InboxCreatePayload
        {
            Name = "WA",
            Channel = channel
        };

        var json = JsonSerializer.Serialize(
            payload,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationInboxCreatePayload);

        using var document = JsonDocument.Parse(json);
        Assert.True(document.RootElement.TryGetProperty("channel", out var channelElement), json);
        Assert.Equal(JsonValueKind.Object, channelElement.ValueKind);
        Assert.Equal("+15551234567", channelElement.GetProperty("phone_number").GetString());
        Assert.Equal("whatsapp_cloud", channelElement.GetProperty("provider").GetString());
        Assert.Equal("your-api-key", channelElement.GetProperty("provider_config").GetProperty("api_key").GetString());
        Assert.Equal("phone-id", channelElement.GetProperty("provider_config").GetProperty("phone_number_id").GetString());
        Assert.Equal("biz-id", channelElement.GetProperty("provider_config").GetProperty("business_account_id").GetString());
    }
}
