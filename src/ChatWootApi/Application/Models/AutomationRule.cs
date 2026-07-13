using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：自动化规则
/// </summary>
public sealed record AutomationRule
{
    /// <summary>
    /// 包含自动化规则的响应负载
    /// </summary>
    [JsonPropertyName("payload")]
    public AutomationRulePayload? Payload { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// 自动化规则响应载荷，可表示单条规则或规则列表。
/// </summary>
[JsonConverter(typeof(AutomationRulePayloadConverter))]
public sealed record AutomationRulePayload
{
    /// <summary>
    /// 单条自动化规则；用于详情、创建和更新响应。
    /// </summary>
    public AutomationRuleItem? Item { get; init; }

    /// <summary>
    /// 自动化规则列表；用于列表响应。
    /// </summary>
    public IReadOnlyList<AutomationRuleItem>? Items { get; init; }
}

/// <summary>
/// 自动化规则响应中的单条规则。
/// </summary>
public sealed record AutomationRuleItem
{
    /// <summary>自动化规则 ID。</summary>
    [JsonPropertyName("id")] public long? Id { get; init; }

    /// <summary>账号 ID。</summary>
    [JsonPropertyName("account_id")] public long? AccountId { get; init; }

    /// <summary>规则名称。</summary>
    [JsonPropertyName("name")] public string? Name { get; init; }

    /// <summary>规则说明。</summary>
    [JsonPropertyName("description")] public string? Description { get; init; }

    /// <summary>触发规则的事件名称。</summary>
    [JsonPropertyName("event_name")] public string? EventName { get; init; }

    /// <summary>规则条件。</summary>
    [JsonPropertyName("conditions")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Conditions { get; init; }

    /// <summary>匹配条件后执行的操作。</summary>
    [JsonPropertyName("actions")]
    public IReadOnlyList<IDictionary<string, JsonElement>?>? Actions { get; init; }

    /// <summary>规则创建时间戳。</summary>
    [JsonPropertyName("created_on")] public long? CreatedOn { get; init; }

    /// <summary>规则是否启用。</summary>
    [JsonPropertyName("active")] public bool? Active { get; init; }

    /// <summary>文档未显式建模的附加 JSON 字段。</summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

internal sealed class AutomationRulePayloadConverter : JsonConverter<AutomationRulePayload>
{
    public override AutomationRulePayload? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.Null => null,
            JsonTokenType.StartObject => new AutomationRulePayload
            {
                Item = JsonSerializer.Deserialize<AutomationRuleItem>(ref reader, options),
            },
            JsonTokenType.StartArray => new AutomationRulePayload
            {
                Items = JsonSerializer.Deserialize<IReadOnlyList<AutomationRuleItem>>(ref reader, options),
            },
            _ => throw new JsonException("Automation rule payload must be an object or an array."),
        };
    }

    public override void Write(Utf8JsonWriter writer, AutomationRulePayload value, JsonSerializerOptions options)
    {
        if (value.Item is not null && value.Items is not null)
        {
            throw new JsonException("Automation rule payload cannot contain both Item and Items.");
        }

        if (value.Item is not null)
        {
            JsonSerializer.Serialize(writer, value.Item, options);
            return;
        }

        if (value.Items is not null)
        {
            JsonSerializer.Serialize(writer, value.Items, options);
            return;
        }

        writer.WriteNullValue();
    }
}
