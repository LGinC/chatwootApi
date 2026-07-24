using System.Text.Json;
using ChatWootApi.Application.Models;
using ChatWootApi.Serialization;

namespace ChatWootApi.Tests;

public sealed class StrongTypedResponseModelsSerializationTests
{
    [Fact]
    public void ConversationShowDeserializesConversationAndMeta()
    {
        const string json = """
            {
              "id": 42,
              "account_id": 12,
              "status": "open",
              "meta": {
                "sender": { "id": 9, "name": "Alice" },
                "channel": "Channel::WebWidget",
                "hmac_verified": true
              }
            }
            """;

        var show = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationConversationShow);

        Assert.Equal(42, show!.Id);
        Assert.Equal(ConversationStatus.Open, show.Status);
        Assert.Equal("Alice", show.Meta!.Sender!.Name);
        Assert.Equal("Channel::WebWidget", show.Meta.Channel);
        Assert.True(show.Meta.HmacVerified);
    }

    [Fact]
    public void ContactBaseDeserializesSwaggerShape()
    {
        const string json = """
            {
              "id": 7,
              "payload": [
                {
                  "id": 7,
                  "name": "Bob",
                  "email": "bob@example.com",
                  "blocked": false
                }
              ]
            }
            """;

        var contact = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationContactBase);

        Assert.Equal(7, contact!.Id);
        var item = Assert.Single(contact.Payload!);
        Assert.Equal(7, item.Id);
        Assert.Equal("Bob", item.Name);
        Assert.Equal("bob@example.com", item.Email);
        Assert.False(item.Blocked);
    }

    [Fact]
    public void ExtendedContactDeserializesSwaggerShape()
    {
        const string json = """
            {
              "id": 9,
              "availability_status": "online",
              "payload": [
                {
                  "id": 9,
                  "name": "Alice",
                  "email": "alice@example.com"
                }
              ]
            }
            """;

        var contact = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationExtendedContact);

        Assert.Equal(9, contact!.Id);
        Assert.Equal(AgentAvailability.Online, contact.AvailabilityStatus);
        var item = Assert.Single(contact.Payload!);
        Assert.Equal("Alice", item.Name);
        Assert.Equal("alice@example.com", item.Email);
    }

    [Fact]
    public void ContactDeserializesPayloadArray()
    {
        const string json = """
            {
              "payload": [
                { "id": 1, "name": "One" },
                { "id": 2, "name": "Two" }
              ]
            }
            """;

        var contact = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationContact);

        Assert.Equal(2, contact!.Payload!.Count);
        Assert.Equal("One", contact.Payload[0].Name);
        Assert.Equal("Two", contact.Payload[1].Name);
    }

    [Fact]
    public void AgentSummaryListDeserializesDocumentedItems()
    {
        const string json = """
            [
              {
                "id": 1,
                "conversations_count": 150,
                "resolved_conversations_count": 120,
                "avg_resolution_time": 3600,
                "avg_first_response_time": 300,
                "avg_reply_time": 600
              }
            ]
            """;

        var list = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.IReadOnlyListChatWootApiApplicationAgentSummary);

        var item = Assert.Single(list!);
        Assert.Equal(1, item.Id);
        Assert.Equal(150, item.ConversationsCount);
        Assert.Equal(120, item.ResolvedConversationsCount);
        Assert.Equal(3600, item.AvgResolutionTime);
    }

    [Fact]
    public void AccountSummaryDeserializesPreviousMetrics()
    {
        const string json = """
            {
              "avg_first_response_time": "10",
              "conversations_count": 5,
              "previous": {
                "avg_first_response_time": "20",
                "conversations_count": 3
              }
            }
            """;

        var summary = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationAccountSummary);

        Assert.Equal("10", summary!.AvgFirstResponseTime);
        Assert.Equal(5, summary.ConversationsCount);
        Assert.Equal("20", summary.Previous!.AvgFirstResponseTime);
        Assert.Equal(3, summary.Previous.ConversationsCount);
    }

    [Fact]
    public void AgentConversationMetricsDeserializesMetricCounts()
    {
        const string json = """
            {
              "id": 3,
              "name": "Ada",
              "metric": { "open": 4, "unattended": 1 }
            }
            """;

        var metrics = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationAgentConversationMetrics);

        Assert.Equal(3, metrics!.Id);
        Assert.Equal(4, metrics.Metric!.Open);
        Assert.Equal(1, metrics.Metric.Unattended);
    }

    [Fact]
    public void ChannelSummaryDeserializesDynamicChannelKeys()
    {
        const string json = """
            {
              "Channel::WebWidget": { "open": 10, "resolved": 20, "pending": 5, "snoozed": 2, "total": 37 },
              "Channel::Api": { "open": 5, "resolved": 15, "pending": 3, "snoozed": 1, "total": 24 }
            }
            """;

        var summary = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationChannelSummary);

        Assert.Equal(10, summary!["Channel::WebWidget"].Open);
        Assert.Equal(37, summary["Channel::WebWidget"].Total);
        Assert.Equal(24, summary["Channel::Api"].Total);
    }

    [Fact]
    public void FirstResponseTimeDistributionDeserializesBuckets()
    {
        const string json = """
            {
              "Channel::WebWidget": {
                "0-1h": 150,
                "1-4h": 80,
                "4-8h": 45,
                "8-24h": 30,
                "24h+": 15
              }
            }
            """;

        var distribution = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationFirstResponseTimeDistribution);

        var buckets = distribution!["Channel::WebWidget"];
        Assert.Equal(150, buckets.ZeroToOneHour);
        Assert.Equal(80, buckets.OneToFourHours);
        Assert.Equal(15, buckets.OverTwentyFourHours);
    }

    [Fact]
    public void OutgoingMessagesCountListDeserializesItems()
    {
        const string json = """
            [
              { "id": 1, "name": "Agent One", "outgoing_messages_count": 42 },
              { "id": 2, "name": "Agent Two", "outgoing_messages_count": 18 }
            ]
            """;

        var list = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.IReadOnlyListChatWootApiApplicationOutgoingMessagesCount);

        Assert.Equal(2, list!.Count);
        Assert.Equal("Agent One", list[0].Name);
        Assert.Equal(42, list[0].Count);
    }
}
