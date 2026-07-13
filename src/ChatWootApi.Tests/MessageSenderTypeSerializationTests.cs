using System.Text.Json;
using ChatWootApi.Application.Models;

namespace ChatWootApi.Tests;

public sealed class MessageSenderTypeSerializationTests
{
    [Fact]
    public void DeserializesMessageSenderType()
    {
        var message = JsonSerializer.Deserialize<Message>("""{"sender_type":"Captain::Assistant"}""");

        Assert.Equal(MessageSenderType.CaptainAssistant, message!.SenderType);
    }

    [Fact]
    public void SerializesMessageSenderTypeUsingChatwootValue()
    {
        var message = new Message
        {
            SenderType = MessageSenderType.AgentBot
        };

        var json = JsonSerializer.Serialize(message);

        Assert.Contains("\"sender_type\":\"AgentBot\"", json);
    }
}
