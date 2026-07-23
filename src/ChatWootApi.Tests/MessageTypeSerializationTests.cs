using System.Text.Json;
using ChatWootApi.Application.Models;

namespace ChatWootApi.Tests;

public sealed class MessageTypeSerializationTests
{
    [Theory]
    [InlineData(0, MessageType.Incoming)]
    [InlineData(1, MessageType.Outgoing)]
    [InlineData(2, MessageType.Activity)]
    [InlineData(3, MessageType.Template)]
    public void DeserializesNumericMessageType(int value, MessageType expected)
    {
        var message = JsonSerializer.Deserialize<Message>($$"""{"message_type":{{value}}}""");

        Assert.Equal(expected, message!.MessageType);
    }

    [Theory]
    [InlineData(MessageType.Incoming, 0)]
    [InlineData(MessageType.Outgoing, 1)]
    [InlineData(MessageType.Activity, 2)]
    [InlineData(MessageType.Template, 3)]
    public void SerializesMessageTypeAsNumber(MessageType messageType, int expected)
    {
        var message = new Message
        {
            MessageType = messageType
        };

        using var document = JsonDocument.Parse(JsonSerializer.Serialize(message));

        Assert.Equal(expected, document.RootElement.GetProperty("message_type").GetInt32());
    }
}
