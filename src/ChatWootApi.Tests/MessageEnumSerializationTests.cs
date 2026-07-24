using System.Text.Json;
using ChatWootApi.Application.Models;
using ChatWootApi.Serialization;

namespace ChatWootApi.Tests;

public sealed class MessageEnumSerializationTests
{
    [Theory]
    [InlineData("sent", MessageStatus.Sent)]
    [InlineData("dElIvErEd", MessageStatus.Delivered)]
    [InlineData("read", MessageStatus.Read)]
    [InlineData("failed", MessageStatus.Failed)]
    public void DeserializesMessageStatusIgnoringCase(string jsonValue, MessageStatus expected)
    {
        var message = JsonSerializer.Deserialize(
            $$"""{"status":"{{jsonValue}}"}""",
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationMessage);

        Assert.Equal(expected, message!.Status);
    }

    [Theory]
    [InlineData("text", MessageContentType.Text)]
    [InlineData("input_text", MessageContentType.InputText)]
    [InlineData("voice_call", MessageContentType.VoiceCall)]
    [InlineData("incoming_email", MessageContentType.IncomingEmail)]
    public void DeserializesMessageContentType(string jsonValue, MessageContentType expected)
    {
        var message = JsonSerializer.Deserialize(
            $$"""{"content_type":"{{jsonValue}}"}""",
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationMessage);

        Assert.Equal(expected, message!.ContentType);
    }

    [Fact]
    public void SerializesMessageStatusAndContentTypeUsingChatwootValues()
    {
        var message = new Message
        {
            Status = MessageStatus.Failed,
            ContentType = MessageContentType.VoiceCall,
        };

        var json = JsonSerializer.Serialize(
            message,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationMessage);

        Assert.Contains("\"status\":\"failed\"", json);
        Assert.Contains("\"content_type\":\"voice_call\"", json);
    }

    [Fact]
    public void DeserializesNullStatusAndContentType()
    {
        var message = JsonSerializer.Deserialize(
            """{"status":null,"content_type":null}""",
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationMessage);

        Assert.Null(message!.Status);
        Assert.Null(message.ContentType);
    }
}
