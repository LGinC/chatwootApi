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
    public void ClientConversationDeserializesStatusIgnoringCase()
    {
        var conversation = JsonSerializer.Deserialize<ClientConversation>("""{"status":"OPEN"}""");

        Assert.Equal(ConversationStatus.Open, conversation!.Status);
    }
}
