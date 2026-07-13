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

    [Theory]
    [InlineData(MessageSenderType.Contact, "Contact")]
    [InlineData(MessageSenderType.User, "User")]
    [InlineData(MessageSenderType.AgentBot, "AgentBot")]
    [InlineData(MessageSenderType.CaptainAssistant, "Captain::Assistant")]
    public void SerializesMessageSenderTypeUsingJsonStringEnumMemberName(
        MessageSenderType senderType,
        string expected)
    {
        var message = new Message
        {
            SenderType = senderType
        };

        var json = JsonSerializer.Serialize(message);

        using var document = JsonDocument.Parse(json);
        Assert.Equal(expected, document.RootElement.GetProperty("sender_type").GetString());
    }
}
