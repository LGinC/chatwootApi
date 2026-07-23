using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// 读取 Chatwoot 中可能以 number 或 string 出现的 long 值（如 Unix 时间戳）。
/// 数字小数字符串会截断到秒；空字符串按 null 处理。
/// </summary>
public sealed class ChatWootFlexibleLongConverter : JsonConverter<long?>
{
    /// <inheritdoc />
    public override long? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.Null => null,
            JsonTokenType.Number => ReadNumber(ref reader),
            JsonTokenType.String => ReadString(reader.GetString()),
            _ => throw new JsonException($"Cannot convert {reader.TokenType} to Int64."),
        };
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, long? value, JsonSerializerOptions options)
    {
        if (value is long number)
        {
            writer.WriteNumberValue(number);
            return;
        }

        writer.WriteNullValue();
    }

    private static long? ReadNumber(ref Utf8JsonReader reader)
    {
        if (reader.TryGetInt64(out var integer))
        {
            return integer;
        }

        if (reader.TryGetDecimal(out var decimalValue))
        {
            return ToInt64(decimalValue);
        }

        throw new JsonException("Cannot convert the JSON number to Int64.");
    }

    private static long? ReadString(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        if (long.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var integer))
        {
            return integer;
        }

        if (decimal.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var decimalValue))
        {
            return ToInt64(decimalValue);
        }

        if (DateTimeOffset.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var dateTimeOffset))
        {
            return dateTimeOffset.ToUnixTimeSeconds();
        }

        throw new JsonException($"Cannot convert string '{value}' to Int64.");
    }

    private static long ToInt64(decimal value)
    {
        try
        {
            return checked((long)decimal.Truncate(value));
        }
        catch (OverflowException exception)
        {
            throw new JsonException("The numeric value is outside the Int64 range.", exception);
        }
    }
}
