using System.Text.Json;
using ChatWootApi.Application.Models;
using ClientConversation = ChatWootApi.Client.Models.Conversation;

namespace ChatWootApi.Tests;

public sealed class ConversationEnumSerializationTests
{
    [Fact]
    public void ApplicationConversationDeserializesStatusAndPriorityIgnoringCase()
    {
        var conversation = JsonSerializer.Deserialize<Conversation>("""{"status":"pEnDiNg","priority":"HIGH"}""");

        Assert.Equal(ConversationStatus.Pending, conversation!.Status);
        Assert.Equal(ConversationPriority.High, conversation.Priority);
    }

    [Fact]
    public void ConversationCreatePayloadDeserializesStatusIgnoringCase()
    {
        var created = JsonSerializer.Deserialize<ConversationCreatePayload>("""{"status":"RESOLVED"}""");

        Assert.Equal(ConversationStatus.Resolved, created!.Status);
    }

    [Fact]
    public void ConversationStatusUpdatePayloadSerializesStatusAsCamelCase()
    {
        var payload = new ConversationStatusUpdatePayload
        {
            Status = ConversationStatus.Open
        };

        var json = JsonSerializer.Serialize(payload);

        Assert.Equal("open", JsonDocument.Parse(json).RootElement.GetProperty("status").GetString());
    }

    [Fact]
    public void ConversationPriorityPayloadsSerializePriorityAsCamelCase()
    {
        var update = new ConversationUpdatePayload
        {
            Priority = ConversationPriority.High
        };
        var toggle = new ConversationPriorityUpdatePayload
        {
            Priority = ConversationPriority.High
        };

        Assert.Equal("high", JsonDocument.Parse(JsonSerializer.Serialize(update)).RootElement.GetProperty("priority").GetString());
        Assert.Equal("high", JsonDocument.Parse(JsonSerializer.Serialize(toggle)).RootElement.GetProperty("priority").GetString());
    }

    [Fact]
    public void ApplicationConversationTypingStatusPayloadSerializesStatusAsCamelCase()
    {
        var payload = new ConversationTypingStatusPayload
        {
            TypingStatus = TypingStatus.On
        };

        var json = JsonSerializer.Serialize(payload);

        Assert.Equal("on", JsonDocument.Parse(json).RootElement.GetProperty("typing_status").GetString());
    }

    [Fact]
    public void ConversationStatusUpdateResultSerializesStatusAsCamelCase()
    {
        var result = new ConversationStatusUpdateResult
        {
            CurrentStatus = ConversationStatus.Open
        };

        var json = JsonSerializer.Serialize(result);

        Assert.Equal("open", JsonDocument.Parse(json).RootElement.GetProperty("current_status").GetString());
    }

    [Fact]
    public void WebhookConversationEnumsSerializeAsCamelCase()
    {
        var request = new WebhookRequest
        {
            Status = ConversationStatus.Open,
            Conversation = new WebhookConversation
            {
                Priority = ConversationPriority.High,
                Status = ConversationStatus.Resolved
            }
        };

        using var document = JsonDocument.Parse(JsonSerializer.Serialize(request));

        Assert.Equal("open", document.RootElement.GetProperty("status").GetString());
        var conversation = document.RootElement.GetProperty("conversation");
        Assert.Equal("high", conversation.GetProperty("priority").GetString());
        Assert.Equal("resolved", conversation.GetProperty("status").GetString());
    }

    [Fact]
    public void ClientConversationDeserializesStatusIgnoringCase()
    {
        var conversation = JsonSerializer.Deserialize<ClientConversation>("""{"status":"OPEN"}""");

        Assert.Equal(ConversationStatus.Open, conversation!.Status);
    }
}
