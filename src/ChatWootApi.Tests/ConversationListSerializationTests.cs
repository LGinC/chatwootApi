using System.Text.Json;
using ChatWootApi.Application.Models;
using ChatWootApi.Serialization;

namespace ChatWootApi.Tests;

public sealed class ConversationListSerializationTests
{
    [Fact]
    public void ConversationListDeserializesDocumentedDataShape()
    {
        const string json = """
            {
              "data": {
                "meta": {
                  "mine_count": 1,
                  "unassigned_count": 2,
                  "assigned_count": 3,
                  "all_count": 6
                },
                "payload": [
                  {
                    "id": 42,
                    "account_id": 12,
                    "uuid": "conv-uuid",
                    "inbox_id": 7,
                    "status": "open",
                    "unread_count": 4,
                    "messages": [
                      {
                        "id": 100,
                        "content": "hello",
                        "message_type": 0
                      }
                    ],
                    "meta": {
                      "sender": {
                        "id": 9,
                        "name": "Alice",
                        "email": "alice@example.com",
                        "phone_number": null,
                        "availability_status": "online",
                        "blocked": false,
                        "identifier": "contact-9",
                        "thumbnail": "https://example.test/a.png",
                        "last_activity_at": 1710000000,
                        "created_at": 1700000000
                      },
                      "channel": "Channel::WebWidget",
                      "assignee": {
                        "id": 3,
                        "name": "Agent Smith",
                        "email": "agent@example.com",
                        "role": "agent"
                      },
                      "hmac_verified": true
                    }
                  }
                ]
              }
            }
            """;

        var list = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationConversationList);

        Assert.NotNull(list);
        Assert.NotNull(list.Data);
        Assert.NotNull(list.Data.Meta);
        Assert.Equal(1, list.Data.Meta.MineCount);
        Assert.Equal(2, list.Data.Meta.UnassignedCount);
        Assert.Equal(3, list.Data.Meta.AssignedCount);
        Assert.Equal(6, list.Data.Meta.AllCount);

        Assert.NotNull(list.Data.Payload);
        var item = Assert.Single(list.Data.Payload);
        Assert.Equal(42, item.Id);
        Assert.Equal(12, item.AccountId);
        Assert.Equal("conv-uuid", item.Uuid);
        Assert.Equal(7, item.InboxId);
        Assert.Equal(ConversationStatus.Open, item.Status);
        Assert.Equal(4, item.UnreadCount);
        Assert.NotNull(item.Messages);
        Assert.Equal(100, item.Messages![0].Id);
        Assert.Equal("hello", item.Messages[0].Content);

        Assert.NotNull(item.Meta);
        Assert.Equal("Channel::WebWidget", item.Meta.Channel);
        Assert.True(item.Meta.HmacVerified);
        Assert.NotNull(item.Meta.Sender);
        Assert.Equal(9, item.Meta.Sender.Id);
        Assert.Equal("Alice", item.Meta.Sender.Name);
        Assert.Equal("alice@example.com", item.Meta.Sender.Email);
        Assert.Equal("online", item.Meta.Sender.AvailabilityStatus);
        Assert.False(item.Meta.Sender.Blocked);
        Assert.Equal("contact-9", item.Meta.Sender.Identifier);
        Assert.Equal(1710000000, item.Meta.Sender.LastActivityAt);
        Assert.NotNull(item.Meta.Assignee);
        Assert.Equal(3, item.Meta.Assignee.Id);
        Assert.Equal("Agent Smith", item.Meta.Assignee.Name);
    }
}
