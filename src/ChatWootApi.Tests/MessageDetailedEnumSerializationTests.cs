using System.Text.Json;
using ChatWootApi.Application.Models;

namespace ChatWootApi.Tests;

public sealed class MessageDetailedEnumSerializationTests
{
    [Fact]
    public void DeserializesMessageEnumsIgnoringCase()
    {
        var message = JsonSerializer.Deserialize<MessageDetailed>("""{"content_type":"input_text","status":"dElIvErEd"}""");

        Assert.Equal(MessageContentType.InputText, message!.ContentType);
        Assert.Equal(MessageStatus.Delivered, message.Status);
    }

    [Fact]
    public void SerializesMessageEnumsUsingChatwootValues()
    {
        var message = new MessageDetailed
        {
            ContentType = MessageContentType.VoiceCall,
            Status = MessageStatus.Failed
        };

        var json = JsonSerializer.Serialize(message);

        Assert.Contains("\"content_type\":\"voice_call\"", json);
        Assert.Contains("\"status\":\"failed\"", json);
    }
}
