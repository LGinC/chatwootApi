using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace ChatWootApi.Application.Models;

/// <summary>
/// 将 JSON 对象反序列化为 <see cref="Dictionary{TKey,TValue}"/> 子类（键为属性名）。
/// 用于 Chatwoot 以渠道名等动态键组织的报表结构。
/// </summary>
/// <typeparam name="TDictionary">字典子类类型。</typeparam>
/// <typeparam name="TValue">字典值类型。</typeparam>
public sealed class ChatWootStringKeyedObjectConverter<TDictionary, TValue> : JsonConverter<TDictionary>
    where TDictionary : Dictionary<string, TValue>, new()
{
    /// <inheritdoc />
    public override TDictionary? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException($"Expected StartObject, got {reader.TokenType}.");
        }

        var valueTypeInfo = (JsonTypeInfo<TValue>)options.GetTypeInfo(typeof(TValue));
        var result = new TDictionary();
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return result;
            }

            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException($"Expected PropertyName, got {reader.TokenType}.");
            }

            var key = reader.GetString() ?? string.Empty;
            reader.Read();
            var value = JsonSerializer.Deserialize(ref reader, valueTypeInfo);
            if (value is not null)
            {
                result[key] = value;
            }
        }

        throw new JsonException("Unexpected end of JSON while reading a string-keyed object.");
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, TDictionary value, JsonSerializerOptions options)
    {
        var valueTypeInfo = (JsonTypeInfo<TValue>)options.GetTypeInfo(typeof(TValue));
        writer.WriteStartObject();
        foreach (var pair in value)
        {
            writer.WritePropertyName(pair.Key);
            JsonSerializer.Serialize(writer, pair.Value, valueTypeInfo);
        }

        writer.WriteEndObject();
    }
}
