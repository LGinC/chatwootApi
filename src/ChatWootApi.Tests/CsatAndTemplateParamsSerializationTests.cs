using System.Text.Json;
using ChatWootApi.Application.Models;
using ChatWootApi.Serialization;

namespace ChatWootApi.Tests;

public sealed class CsatAndTemplateParamsSerializationTests
{
    [Fact]
    public void InboxCreatePayloadSerializesCsatConfigEnumsAndNestedRules()
    {
        var payload = new InboxCreatePayload
        {
            Name = "Support",
            CsatConfig = new CsatConfig
            {
                DisplayType = CsatDisplayType.Emoji,
                Message = "Please rate your conversation",
                ButtonText = "Please rate us",
                Language = "en",
                SurveyRules = new CsatSurveyRules
                {
                    Operator = "contains",
                    Values = ["billing"]
                }
            }
        };

        var json = JsonSerializer.Serialize(
            payload,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationInboxCreatePayload);

        Assert.Contains("\"display_type\":\"emoji\"", json);
        Assert.Contains("\"message\":\"Please rate your conversation\"", json);
        Assert.Contains("\"button_text\":\"Please rate us\"", json);
        Assert.Contains("\"language\":\"en\"", json);
        Assert.Contains("\"operator\":\"contains\"", json);
        Assert.Contains("\"billing\"", json);
    }

    [Fact]
    public void InboxUpdatePayloadDeserializesCsatDisplayTypeIgnoringCase()
    {
        const string json = """
            {
              "csat_config": {
                "display_type": "sTaR",
                "message": "Rate us"
              }
            }
            """;

        var payload = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationInboxUpdatePayload);

        Assert.NotNull(payload?.CsatConfig);
        Assert.Equal(CsatDisplayType.Star, payload.CsatConfig.DisplayType);
        Assert.Equal("Rate us", payload.CsatConfig.Message);
    }

    [Fact]
    public void ConversationMessageCreatePayloadSerializesWhatsAppTemplateParams()
    {
        var payload = new ConversationMessageCreatePayload
        {
            Content = "Hi your order is confirmed",
            MessageType = MessageType.Outgoing,
            ContentType = MessageContentType.Text,
            TemplateParams = new WhatsAppTemplateParams
            {
                Name = "order_confirmation",
                Category = WhatsAppTemplateCategory.Marketing,
                Language = "en_US",
                ProcessedParams = new WhatsAppTemplateProcessedParams
                {
                    Body = new Dictionary<string, string>
                    {
                        ["1"] = "121212"
                    },
                    Header = new WhatsAppTemplateHeaderParams
                    {
                        MediaUrl = "https://example.test/receipt.pdf",
                        MediaType = WhatsAppTemplateMediaType.Document
                    },
                    Buttons =
                    [
                        new WhatsAppTemplateButtonParam
                        {
                            Type = WhatsAppTemplateButtonType.CopyCode,
                            Parameter = "SAVE30"
                        }
                    ]
                }
            }
        };

        var json = JsonSerializer.Serialize(
            payload,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationConversationMessageCreatePayload);

        Assert.Contains("\"name\":\"order_confirmation\"", json);
        Assert.Contains("\"category\":\"MARKETING\"", json);
        Assert.Contains("\"language\":\"en_US\"", json);
        Assert.Contains("\"media_type\":\"document\"", json);
        Assert.Contains("\"media_url\":\"https://example.test/receipt.pdf\"", json);
        Assert.Contains("\"type\":\"copy_code\"", json);
        Assert.Contains("\"parameter\":\"SAVE30\"", json);
        Assert.Contains("\"1\":\"121212\"", json);
    }

    [Theory]
    [InlineData("UTILITY", WhatsAppTemplateCategory.Utility)]
    [InlineData("SHIPPING_UPDATE", WhatsAppTemplateCategory.ShippingUpdate)]
    [InlineData("TICKET_UPDATE", WhatsAppTemplateCategory.TicketUpdate)]
    [InlineData("ISSUE_RESOLUTION", WhatsAppTemplateCategory.IssueResolution)]
    public void DeserializesWhatsAppTemplateCategory(string jsonValue, WhatsAppTemplateCategory expected)
    {
        var json = "{\"template_params\":{\"category\":\"" + jsonValue + "\"}}";

        var payload = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationConversationMessageCreatePayload);

        Assert.Equal(expected, payload!.TemplateParams!.Category);
    }
}
