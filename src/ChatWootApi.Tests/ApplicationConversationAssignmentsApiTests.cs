using ChatWootApi.Application;
using System.Reflection;
using System.Text.Json;
using Refit;

namespace ChatWootApi.Tests;

public sealed class ApplicationConversationAssignmentsApiTests
{
    [Fact]
    public void AssignAConversationUsesTypedSwaggerPayload()
    {
        var method = GetAssignAConversationMethod();

        var parameters = method.GetParameters();
        Assert.Equal(typeof(ConversationAssignmentPayload), parameters[2].ParameterType);
        Assert.NotNull(parameters[2].GetCustomAttribute<BodyAttribute>());
    }

    [Fact]
    public void ConversationAssignmentPayloadSerializesSwaggerFields()
    {
        var payload = new ConversationAssignmentPayload
        {
            AssigneeId = 7,
            TeamId = 11,
        };

        var json = JsonSerializer.Serialize(payload);

        using var document = JsonDocument.Parse(json);
        Assert.Equal(7, document.RootElement.GetProperty("assignee_id").GetInt64());
        Assert.Equal(11, document.RootElement.GetProperty("team_id").GetInt64());
    }

    private static MethodInfo GetAssignAConversationMethod()
    {
        var method = typeof(IApplicationConversationAssignmentsApi).GetMethod(
            nameof(IApplicationConversationAssignmentsApi.AssignAConversationAsync),
            BindingFlags.Instance | BindingFlags.Public);

        Assert.NotNull(method);
        return method;
    }
}
