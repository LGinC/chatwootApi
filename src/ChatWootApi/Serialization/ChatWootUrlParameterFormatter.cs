using System.Globalization;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Refit;

namespace ChatWootApi.Serialization;

/// <summary>
/// Formats Refit query/path values using camelCase enum names and
/// <see cref="JsonStringEnumMemberNameAttribute"/> when present.
/// </summary>
public sealed class ChatWootUrlParameterFormatter : DefaultUrlParameterFormatter
{
    /// <inheritdoc />
    public override string? Format(object? parameterValue, ICustomAttributeProvider attributeProvider, Type type)
    {
        if (parameterValue is null)
        {
            return null;
        }

        if (parameterValue is Enum enumValue)
        {
            return FormatEnum(enumValue);
        }

        return base.Format(parameterValue, attributeProvider, type);
    }

    private static string FormatEnum(Enum value)
    {
        var enumType = value.GetType();
        var name = Enum.GetName(enumType, value);
        if (name is null)
        {
            return Convert.ToString(value, CultureInfo.InvariantCulture) ?? string.Empty;
        }

        var member = enumType.GetField(name, BindingFlags.Public | BindingFlags.Static);
        var memberName = member?.GetCustomAttribute<JsonStringEnumMemberNameAttribute>()?.Name;
        if (!string.IsNullOrEmpty(memberName))
        {
            return memberName;
        }

        return JsonNamingPolicy.CamelCase.ConvertName(name);
    }
}
