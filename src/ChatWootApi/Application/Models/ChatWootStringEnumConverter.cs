using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// 使用 Chatwoot 的 camelCase 枚举值进行 JSON 序列化，并在反序列化时忽略大小写。
/// </summary>
/// <typeparam name="TEnum">枚举类型。</typeparam>
public sealed class ChatWootStringEnumConverter<TEnum> : JsonStringEnumConverter<TEnum>
    where TEnum : struct, Enum
{
    /// <summary>
    /// 初始化转换器。
    /// </summary>
    public ChatWootStringEnumConverter()
        : base(JsonNamingPolicy.CamelCase)
    {
    }
}
