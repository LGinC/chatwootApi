using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// 请求载荷的动态 JSON 扩展字段基类。
/// </summary>
public abstract record JsonExtensionDataPayload
{
    private IDictionary<string, object>? _extensionData;
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    /// <summary>
    /// 获取或设置附加 JSON 字段。
    /// </summary>
    [JsonIgnore]
    public IDictionary<string, object>? ExtensionData
    {
        get => _extensionData ??= SerializedExtensionData?.ToDictionary(
            item => item.Key,
            item => (object)item.Value);
        set
        {
            _extensionData = value;
            SerializedExtensionData = value?.ToDictionary(
                item => item.Key,
                item => JsonSerializer.SerializeToElement(
                    item.Value,
                    JsonOptions));
        }
    }

    /// <summary>
    /// 源生成 JSON 序列化使用的扩展字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? SerializedExtensionData { get; private set; }

    /// <summary>
    /// 初始化空的扩展字段载荷。
    /// </summary>
    protected JsonExtensionDataPayload()
    {
    }

    /// <summary>
    /// 初始化扩展字段载荷。
    /// </summary>
    /// <param name="extensionData">附加 JSON 字段。</param>
    protected JsonExtensionDataPayload(IDictionary<string, object>? extensionData)
    {
        ExtensionData = extensionData;
    }

    /// <summary>
    /// 将用户提供的动态对象字典列表转换为源生成 JSON 使用的形式。
    /// </summary>
    protected static IReadOnlyList<IDictionary<string, JsonElement>?>? ConvertDictionaryList(
        IReadOnlyList<IDictionary<string, object>?>? values)
    {
        return values?.Select(value => value?.ToDictionary(
            item => item.Key,
            item => JsonSerializer.SerializeToElement(item.Value, JsonOptions))).ToArray();
    }

    /// <summary>
    /// 将源生成 JSON 形式的动态字典列表转换回用户可读形式。
    /// </summary>
    protected static IReadOnlyList<IDictionary<string, object>?>? ConvertJsonElementDictionaryList(
        IReadOnlyList<IDictionary<string, JsonElement>?>? values)
    {
        return values?.Select(value => value?.ToDictionary(
            item => item.Key,
            item => (object)item.Value)).ToArray();
    }
}
