using System.Text.Json;
using ChatWootApi.Application.Models;
using ChatWootApi.Serialization;

namespace ChatWootApi.Tests;

public sealed class DynamicPayloadSerializationTests
{
    [Fact]
    public void AutomationRulePayloadConvertsDictionaryListsForSourceGeneratedJson()
    {
        var payload = new AutomationRuleCreateUpdatePayload
        {
            Actions =
            [
                new Dictionary<string, object>
                {
                    ["action_name"] = "add_label",
                    ["label_id"] = 7,
                },
            ],
            Conditions =
            [
                new Dictionary<string, object>
                {
                    ["attribute_key"] = "content",
                    ["query_operator"] = "contains",
                },
            ],
        };

        var json = JsonSerializer.Serialize(
            payload,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationAutomationRuleCreateUpdatePayload);

        using var document = JsonDocument.Parse(json);
        Assert.Equal(
            "add_label",
            document.RootElement.GetProperty("actions")[0].GetProperty("action_name").GetString());
        Assert.Equal(
            "content",
            document.RootElement.GetProperty("conditions")[0].GetProperty("attribute_key").GetString());

        var roundTripped = JsonSerializer.Deserialize(
            json,
            ChatWootJsonSerializerContext.Default.ChatWootApiApplicationAutomationRuleCreateUpdatePayload);

        Assert.Equal(
            "add_label",
            ((JsonElement)roundTripped!.Actions![0]!["action_name"]).GetString());
    }
}
