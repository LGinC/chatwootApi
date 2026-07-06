using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 发送到 webhook 端点的请求载荷。
/// </summary>
public sealed class WebhookRequest
{
    /// <summary>
    /// 触发 webhook 的事件名称，例如 <c>message_created</c>。
    /// </summary>
    [JsonPropertyName("event")]
    public string? Event { get; init; }

    /// <summary>
    /// 当前事件主体的标识符。
    /// </summary>
    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? Id { get; init; }

    /// <summary>
    /// 会话在 Chatwoot 控制台中显示的编号。
    /// </summary>
    [JsonPropertyName("display_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? DisplayId { get; init; }

    /// <summary>
    /// 消息正文内容。
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    /// <summary>
    /// 消息或对象创建时间，保留 Chatwoot 原始字符串或数字格式。
    /// </summary>
    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(WebhookStringOrNumberConverter))]
    public string? CreatedAt { get; init; }

    /// <summary>
    /// 消息类型，例如 <c>incoming</c>、<c>outgoing</c> 或数字枚举值。
    /// </summary>
    [JsonPropertyName("message_type")]
    [JsonConverter(typeof(WebhookStringOrNumberConverter))]
    public string? MessageType { get; init; }

    /// <summary>
    /// 消息内容类型，例如 <c>text</c>、<c>input_select</c>、<c>cards</c> 或 <c>form</c>。
    /// </summary>
    [JsonPropertyName("content_type")]
    public string? ContentType { get; init; }

    /// <summary>
    /// 特定内容类型携带的附加属性。
    /// </summary>
    [JsonPropertyName("content_attributes")]
    public IDictionary<string, JsonElement>? ContentAttributes { get; init; }

    /// <summary>
    /// 外部渠道来源标识，例如 Twitter 或 Facebook 集成中的外部 ID。
    /// </summary>
    [JsonPropertyName("source_id")]
    public string? SourceId { get; init; }

    /// <summary>
    /// 指示消息是否为私有备注。
    /// </summary>
    [JsonPropertyName("private")]
    public bool? Private { get; init; }

    /// <summary>
    /// 发送消息的用户、联系人或自动化主体。
    /// </summary>
    [JsonPropertyName("sender")]
    public WebhookActor? Sender { get; init; }

    /// <summary>
    /// 与事件相关的联系人。
    /// </summary>
    [JsonPropertyName("contact")]
    public WebhookActor? Contact { get; init; }

    /// <summary>
    /// 与事件相关的 Chatwoot 账号。
    /// </summary>
    [JsonPropertyName("account")]
    public WebhookAccount? Account { get; init; }

    /// <summary>
    /// 与事件相关的收件箱。
    /// </summary>
    [JsonPropertyName("inbox")]
    public WebhookInbox? Inbox { get; init; }

    /// <summary>
    /// 与事件相关的会话。
    /// </summary>
    [JsonPropertyName("conversation")]
    public WebhookConversation? Conversation { get; init; }

    /// <summary>
    /// <c>webwidget_triggered</c> 事件中的当前会话。
    /// </summary>
    [JsonPropertyName("current_conversation")]
    public WebhookConversation? CurrentConversation { get; init; }

    /// <summary>
    /// 触发输入状态事件的用户或自动化主体。
    /// </summary>
    [JsonPropertyName("user")]
    public WebhookActor? User { get; init; }

    /// <summary>
    /// 输入状态事件是否对应私有备注。
    /// </summary>
    [JsonPropertyName("is_private")]
    public bool? IsPrivate { get; init; }

    /// <summary>
    /// 会话状态，例如 <c>open</c>、<c>pending</c> 或 <c>resolved</c>。
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// 会话来源渠道。
    /// </summary>
    [JsonPropertyName("channel")]
    public string? Channel { get; init; }

    /// <summary>
    /// 指示当前会话是否可回复。
    /// </summary>
    [JsonPropertyName("can_reply")]
    public bool? CanReply { get; init; }

    /// <summary>
    /// 会话未读消息数。
    /// </summary>
    [JsonPropertyName("unread_count")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? UnreadCount { get; init; }

    /// <summary>
    /// 账号标识符。
    /// </summary>
    [JsonPropertyName("account_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? AccountId { get; init; }

    /// <summary>
    /// 收件箱标识符。
    /// </summary>
    [JsonPropertyName("inbox_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? InboxId { get; init; }

    /// <summary>
    /// 客服最后查看会话的 Unix 时间戳。
    /// </summary>
    [JsonPropertyName("agent_last_seen_at")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? AgentLastSeenAt { get; init; }

    /// <summary>
    /// 联系人最后查看会话的 Unix 时间戳。
    /// </summary>
    [JsonPropertyName("contact_last_seen_at")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? ContactLastSeenAt { get; init; }

    /// <summary>
    /// 事件或会话时间戳。
    /// </summary>
    [JsonPropertyName("timestamp")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? Timestamp { get; init; }

    /// <summary>
    /// 会话附加属性，例如浏览器、来源页面和初始化时间。
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    /// <summary>
    /// <c>conversation_updated</c> 事件中变更字段的新旧值集合。
    /// </summary>
    [JsonPropertyName("changed_attributes")]
    public IReadOnlyList<IDictionary<string, WebhookChangedAttributeValue>?>? ChangedAttributes { get; init; }

    /// <summary>
    /// <c>webwidget_triggered</c> 事件的上下文信息。
    /// </summary>
    [JsonPropertyName("event_info")]
    public WebhookEventInfo? EventInfo { get; init; }

    /// <summary>
    /// 文档未声明或未来新增的顶层字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Chatwoot webhook 中的账号对象。
/// </summary>
public sealed class WebhookAccount
{
    /// <summary>
    /// 账号标识符。
    /// </summary>
    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? Id { get; init; }

    /// <summary>
    /// 账号名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 账号对象中未建模的附加字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Chatwoot webhook 中的收件箱对象。
/// </summary>
public sealed class WebhookInbox
{
    /// <summary>
    /// 收件箱标识符。
    /// </summary>
    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? Id { get; init; }

    /// <summary>
    /// 收件箱名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 收件箱对象中未建模的附加字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Chatwoot webhook 中的参与者对象，可表示联系人、客服、机器人或 Captain。
/// </summary>
public sealed class WebhookActor
{
    /// <summary>
    /// 参与者标识符。
    /// </summary>
    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? Id { get; init; }

    /// <summary>
    /// 参与者显示名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 参与者电子邮箱。
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// 联系人头像 URL。
    /// </summary>
    [JsonPropertyName("avatar")]
    public string? Avatar { get; init; }

    /// <summary>
    /// 参与者类型，例如 <c>contact</c> 或 <c>user</c>。
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// 联系人归属的账号。
    /// </summary>
    [JsonPropertyName("account")]
    public WebhookAccount? Account { get; init; }

    /// <summary>
    /// 参与者对象中未建模的附加字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Chatwoot webhook 中的会话对象。
/// </summary>
public sealed class WebhookConversation
{
    /// <summary>
    /// 会话标识符。
    /// </summary>
    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? Id { get; init; }

    /// <summary>
    /// 控制台中显示的会话编号。
    /// </summary>
    [JsonPropertyName("display_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? DisplayId { get; init; }

    /// <summary>
    /// 会话所属账号标识符。
    /// </summary>
    [JsonPropertyName("account_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? AccountId { get; init; }

    /// <summary>
    /// 会话所属收件箱标识符。
    /// </summary>
    [JsonPropertyName("inbox_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? InboxId { get; init; }

    /// <summary>
    /// 会话附加属性。
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    /// <summary>
    /// 指示会话是否可回复。
    /// </summary>
    [JsonPropertyName("can_reply")]
    public bool? CanReply { get; init; }

    /// <summary>
    /// 会话渠道。
    /// </summary>
    [JsonPropertyName("channel")]
    public string? Channel { get; init; }

    /// <summary>
    /// 联系人与收件箱的关联信息。
    /// </summary>
    [JsonPropertyName("contact_inbox")]
    public WebhookContactInbox? ContactInbox { get; init; }

    /// <summary>
    /// 会话中的消息集合。
    /// </summary>
    [JsonPropertyName("messages")]
    public IReadOnlyList<WebhookRequest?>? Messages { get; init; }

    /// <summary>
    /// 会话元数据，例如发送者和负责人。
    /// </summary>
    [JsonPropertyName("meta")]
    public WebhookConversationMeta? Meta { get; init; }

    /// <summary>
    /// 会话状态。
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// 会话未读消息数。
    /// </summary>
    [JsonPropertyName("unread_count")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? UnreadCount { get; init; }

    /// <summary>
    /// 客服最后查看会话的 Unix 时间戳。
    /// </summary>
    [JsonPropertyName("agent_last_seen_at")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? AgentLastSeenAt { get; init; }

    /// <summary>
    /// 联系人最后查看会话的 Unix 时间戳。
    /// </summary>
    [JsonPropertyName("contact_last_seen_at")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? ContactLastSeenAt { get; init; }

    /// <summary>
    /// 会话时间戳。
    /// </summary>
    [JsonPropertyName("timestamp")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? Timestamp { get; init; }

    /// <summary>
    /// 会话对象中未建模的附加字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// 联系人与收件箱的关联对象。
/// </summary>
public sealed class WebhookContactInbox
{
    /// <summary>
    /// 关联记录标识符。
    /// </summary>
    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? Id { get; init; }

    /// <summary>
    /// 联系人标识符。
    /// </summary>
    [JsonPropertyName("contact_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? ContactId { get; init; }

    /// <summary>
    /// 收件箱标识符。
    /// </summary>
    [JsonPropertyName("inbox_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? InboxId { get; init; }

    /// <summary>
    /// 外部来源标识。
    /// </summary>
    [JsonPropertyName("source_id")]
    public string? SourceId { get; init; }

    /// <summary>
    /// 关联记录创建时间，保留 Chatwoot 原始字符串或数字格式。
    /// </summary>
    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(WebhookStringOrNumberConverter))]
    public string? CreatedAt { get; init; }

    /// <summary>
    /// 关联记录更新时间，保留 Chatwoot 原始字符串或数字格式。
    /// </summary>
    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(WebhookStringOrNumberConverter))]
    public string? UpdatedAt { get; init; }

    /// <summary>
    /// 指示 HMAC 校验是否通过。
    /// </summary>
    [JsonPropertyName("hmac_verified")]
    public bool? HmacVerified { get; init; }

    /// <summary>
    /// 关联对象中未建模的附加字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Chatwoot 会话元数据。
/// </summary>
public sealed class WebhookConversationMeta
{
    /// <summary>
    /// 会话发送者。
    /// </summary>
    [JsonPropertyName("sender")]
    public WebhookActor? Sender { get; init; }

    /// <summary>
    /// 会话负责人。
    /// </summary>
    [JsonPropertyName("assignee")]
    public WebhookActor? Assignee { get; init; }

    /// <summary>
    /// 元数据对象中未建模的附加字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// 会话变更字段的新旧值。
/// </summary>
public sealed class WebhookChangedAttributeValue
{
    /// <summary>
    /// 字段当前值。
    /// </summary>
    [JsonPropertyName("current_value")]
    public JsonElement CurrentValue { get; init; }

    /// <summary>
    /// 字段先前值。
    /// </summary>
    [JsonPropertyName("previous_value")]
    public JsonElement PreviousValue { get; init; }

    /// <summary>
    /// 变更值对象中未建模的附加字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// <c>webwidget_triggered</c> webhook 的事件上下文。
/// </summary>
public sealed class WebhookEventInfo
{
    /// <summary>
    /// 事件初始化时间，可为文档中的对象或字符串格式。
    /// </summary>
    [JsonPropertyName("initiated_at")]
    public JsonElement? InitiatedAt { get; init; }

    /// <summary>
    /// 触发 widget 的来源页面。
    /// </summary>
    [JsonPropertyName("referer")]
    public string? Referer { get; init; }

    /// <summary>
    /// Widget 配置语言。
    /// </summary>
    [JsonPropertyName("widget_language")]
    public string? WidgetLanguage { get; init; }

    /// <summary>
    /// 浏览器语言。
    /// </summary>
    [JsonPropertyName("browser_language")]
    public string? BrowserLanguage { get; init; }

    /// <summary>
    /// 浏览器信息，例如浏览器名称、版本、设备和平台。
    /// </summary>
    [JsonPropertyName("browser")]
    public IDictionary<string, JsonElement>? Browser { get; init; }

    /// <summary>
    /// 事件上下文中未建模的附加字段。
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

internal sealed class WebhookStringOrNumberConverter : JsonConverter<string?>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.String => reader.GetString(),
            JsonTokenType.Number => reader.TryGetInt64(out var integer) ? integer.ToString(System.Globalization.CultureInfo.InvariantCulture) : reader.GetDecimal().ToString(System.Globalization.CultureInfo.InvariantCulture),
            JsonTokenType.Null => null,
            _ => throw new JsonException($"Cannot convert {reader.TokenType} to string.")
        };
    }

    public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteStringValue(value);
    }
}
