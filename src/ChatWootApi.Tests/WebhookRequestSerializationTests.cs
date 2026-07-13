using ChatWootApi.Application;
using ChatWootApi.Application.Models;
using ChatWootApi.Serialization;
using System.Text.Json;

namespace ChatWootApi.Tests
{
    public sealed class WebhookRequestSerializationTests
    {
        [Fact]
        public void MessageCreatedPayloadDeserializesDocumentedMessageFieldsAndExtensionData()
        {
            const string json = """
                {
                  "event": "message_created",
                  "id": "1",
                  "content": "Hi",
                  "created_at": "2020-03-03 13:05:57 UTC",
                  "message_type": "incoming",
                  "content_type": "text",
                  "content_attributes": {
                    "submitted_values": {
                      "plan": "enterprise"
                    }
                  },
                  "source_id": "twitter-dm-123",
                  "sender": {
                    "id": "1",
                    "name": "Agent",
                    "email": "agent@example.com",
                    "type": "user"
                  },
                  "contact": {
                    "id": "2",
                    "name": "contact-name",
                    "type": "contact"
                  },
                  "conversation": {
                    "display_id": "3",
                    "additional_attributes": {
                      "browser": {
                        "device_name": "Macbook",
                        "browser_name": "Chrome",
                        "platform_name": "Macintosh",
                        "browser_version": "80.0.3987.122",
                        "platform_version": "10.15.2"
                      },
                      "referer": "https://www.chatwoot.com",
                      "initiated_at": "Tue Mar 03 2020 18:37:38 GMT-0700 (Mountain Standard Time)"
                    }
                  },
                  "account": {
                    "id": "4",
                    "name": "Chatwoot"
                  },
                  "undocumented_flag": true
                }
                """;

            var request = DeserializeWebhook(json);

            Assert.Equal("message_created", request.Event);
            Assert.Equal<decimal?>(1m, request.Id);
            Assert.Equal("Hi", request.Content);
            Assert.Equal("incoming", request.MessageType);
            Assert.Equal("text", request.ContentType);
            Assert.Equal("enterprise", request.ContentAttributes!["submitted_values"].GetProperty("plan").GetString());
            Assert.Equal<decimal?>(1m, request.Sender!.Id);
            Assert.Equal("Agent", request.Sender.Name);
            Assert.Equal("agent@example.com", request.Sender.Email);
            Assert.Equal<decimal?>(2m, request.Contact!.Id);
            Assert.Equal("contact-name", request.Contact.Name);
            Assert.Equal<decimal?>(3m, request.Conversation!.DisplayId);
            Assert.Equal("Chrome", request.Conversation.AdditionalAttributes!["browser"].GetProperty("browser_name").GetString());
            Assert.Equal("https://www.chatwoot.com", request.Conversation.AdditionalAttributes["referer"].GetString());
            Assert.Equal<decimal?>(4m, request.Account!.Id);
            Assert.Equal("Chatwoot", request.Account.Name);
            Assert.True(request.ExtensionData!["undocumented_flag"].GetBoolean());
        }

        [Fact]
        public void ConversationUpdatedPayloadDeserializesChangedAttributesAndNumericConversationFields()
        {
            const string json = """
                {
                  "event": "conversation_updated",
                  "id": 42,
                  "display_id": 1001,
                  "status": "OPEN",
                  "account_id": 5,
                  "additional_attributes": {
                    "referer": "https://example.test/pricing"
                  },
                  "changed_attributes": [
                    {
                      "status": {
                        "current_value": "open",
                        "previous_value": "pending"
                      }
                    },
                    {
                      "assignee_id": {
                        "current_value": 7,
                        "previous_value": null
                      }
                    }
                  ]
                }
                """;

            var request = DeserializeWebhook(json);

            Assert.Equal("conversation_updated", request.Event);
            Assert.Equal<decimal?>(42m, request.Id);
            Assert.Equal<decimal?>(1001m, request.DisplayId);
            Assert.Equal(ConversationStatus.Open, request.Status);
            Assert.Equal<decimal?>(5m, request.AccountId);
            Assert.Equal("https://example.test/pricing", request.AdditionalAttributes!["referer"].GetString());

            Assert.Collection(
                request.ChangedAttributes!,
                statusChange =>
                {
                    Assert.NotNull(statusChange);
                    var values = statusChange["status"];
                    Assert.Equal("open", values.CurrentValue.GetString());
                    Assert.Equal("pending", values.PreviousValue.GetString());
                },
                assigneeChange =>
                {
                    Assert.NotNull(assigneeChange);
                    var values = assigneeChange["assignee_id"];
                    Assert.Equal(7, values.CurrentValue.GetInt32());
                    Assert.Equal(JsonValueKind.Null, values.PreviousValue.ValueKind);
                });
        }

        [Fact]
        public void ConversationTypingOnPayloadDeserializesConversationUserAndPrivateFlag()
        {
            const string json = """
                {
                  "event": "conversation_typing_on",
                  "conversation": {
                    "id": "11",
                    "display_id": 12,
                    "status": "pEnDiNg",
                    "account_id": "13",
                    "additional_attributes": {
                      "browser": {
                        "browser_name": "Firefox"
                      }
                    }
                  },
                  "user": {
                    "id": "9",
                    "name": "Agent Smith",
                    "email": "smith@example.com",
                    "type": "user"
                  },
                  "is_private": true
                }
                """;

            var request = DeserializeWebhook(json);

            Assert.Equal("conversation_typing_on", request.Event);
            Assert.Equal<decimal?>(11m, request.Conversation!.Id);
            Assert.Equal<decimal?>(12m, request.Conversation.DisplayId);
            Assert.Equal(ConversationStatus.Pending, request.Conversation.Status);
            Assert.Equal<decimal?>(13m, request.Conversation.AccountId);
            Assert.Equal("Firefox", request.Conversation.AdditionalAttributes!["browser"].GetProperty("browser_name").GetString());
            Assert.Equal<decimal?>(9m, request.User!.Id);
            Assert.Equal("Agent Smith", request.User.Name);
            Assert.Equal("smith@example.com", request.User.Email);
            Assert.Equal("user", request.User.Type);
            Assert.True(request.IsPrivate);
        }

        [Fact]
        public void SourceGeneratedContextExposesWebhookRequestMetadata()
        {
            Assert.Same(typeof(WebhookRequest), ChatWootJsonSerializerContext.Default.ChatWootApiApplicationWebhookRequest.Type);
        }

        [Fact]
        public void PlatformUserDeserializesExtensionDataWithSourceGeneratedContext()
        {
            const string json = """
                {
                  "id": 7,
                  "name": "Agent Smith",
                  "undocumented_flag": true
                }
                """;

            var user = JsonSerializer.Deserialize(
                json,
                ChatWootJsonSerializerContext.Default.ChatWootApiPlatformUser)
                ?? throw new JsonException("Platform user deserialized to null.");

            Assert.Equal(7, user.Id);
            Assert.True(user.ExtensionData!["undocumented_flag"].GetBoolean());
        }

        [Fact]
        public void AccountShowResponseDeserializesAdditionalYamlProperties()
        {
            const string json = """
                {
                  "latest_chatwoot_version": "3.0.0",
                  "subscribed_features": ["audit_logs", "custom_roles"]
                }
                """;

            var response = JsonSerializer.Deserialize(
                json,
                ChatWootJsonSerializerContext.Default.ChatWootApiApplicationAccountShowResponse)
                ?? throw new JsonException("Account show response deserialized to null.");

            Assert.Equal("3.0.0", response.LatestChatwootVersion);
            Assert.Equal(["audit_logs", "custom_roles"], response.SubscribedFeatures);
        }

        private static WebhookRequest DeserializeWebhook(string json)
        {
            return JsonSerializer.Deserialize(json, ChatWootJsonSerializerContext.Default.ChatWootApiApplicationWebhookRequest)
                ?? throw new JsonException("Webhook payload deserialized to null.");
        }
    }
}
