using System.Text.Json;
using ChatWootApi.Application.Models;
using ChatWootApi.Serialization;

namespace ChatWootApi.Tests;

public sealed class MessageUpdatedAtSerializationTests
{
    [Theory]
    [InlineData("""{"updated_at":1710000000}""", 1710000000L)]
    [InlineData("""{"updated_at":"1710000000"}""", 1710000000L)]
    [InlineData("""{"updated_at":"1710000000.9"}""", 1710000000L)]
    [InlineData("""{"updated_at":null}""", null)]
    [InlineData("""{"updated_at":""}""", null)]
    public void DeserializesUpdatedAtFromNumberOrString(string json, long? expected)
    {
        var message = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationMessage);

        Assert.Equal(expected, message!.UpdatedAt);
    }

    [Fact]
    public void DeserializesUpdatedAtInsideConversationListMessages()
    {
        const string json = """
            {
              "data": {
                "meta": { "all_count": 1 },
                "payload": [
                  {
                    "id": 42,
                    "messages": [
                      {
                        "id": 100,
                        "content": "hello",
                        "updated_at": "1710000000"
                      }
                    ]
                  }
                ]
              }
            }
            """;

        var list = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationConversationList);

        var message = Assert.Single(list!.Data!.Payload![0].Messages!);
        Assert.Equal(1710000000, message.UpdatedAt);
    }

    [Fact]
    public void SerializesUpdatedAtAsNumber()
    {
        var message = new Message { UpdatedAt = 1710000000 };

        var json = JsonSerializer.Serialize(
            message,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationMessage);

        using var document = JsonDocument.Parse(json);
        Assert.Equal(JsonValueKind.Number, document.RootElement.GetProperty("updated_at").ValueKind);
        Assert.Equal(1710000000, document.RootElement.GetProperty("updated_at").GetInt64());
    }
}
