using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 发送到 webhook 端点的请求载荷
/// </summary>
public sealed class WebhookRequest
{
    /// <summary>
    /// 触发 webhook 的事件名称，例如 <c>message_created</c>
    /// </summary>
    [JsonPropertyName("event")]
    public string? Event { get; init; }

    /// <summary>
    /// 当前事件主体的标识符
    /// </summary>
    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? Id { get; init; }

    /// <summary>
    /// 会话在 Chatwoot 控制台中显示的编号
    /// </summary>
    [JsonPropertyName("display_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? DisplayId { get; init; }

    /// <summary>
    /// 消息正文内容
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    /// <summary>
    /// 消息或对象创建时间；ISO 字符串会转换为 UTC 时间
    /// </summary>
    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(WebhookDateTimeOffsetConverter))]
    public DateTimeOffset? CreatedAt { get; init; }

    /// <summary>
    /// 消息类型，例如 <c>incoming</c>、<c>outgoing</c> 或数字枚举值
    /// </summary>
    [JsonPropertyName("message_type")]
    [JsonConverter(typeof(WebhookStringOrNumberConverter))]
    public string? MessageType { get; init; }

    /// <summary>
    /// 消息内容类型，例如 <c>text</c>、<c>input_select</c>、<c>cards</c> 或 <c>form</c>
    /// </summary>
    [JsonPropertyName("content_type")]
    public string? ContentType { get; init; }

    /// <summary>
    /// 特定内容类型携带的附加属性
    /// </summary>
    [JsonPropertyName("content_attributes")]
    public IDictionary<string, JsonElement>? ContentAttributes { get; init; }

    /// <summary>
    /// 外部渠道来源标识，例如 Twitter 或 Facebook 集成中的外部 ID
    /// </summary>
    [JsonPropertyName("source_id")]
    public string? SourceId { get; init; }

    /// <summary>
    /// 指示消息是否为私有备注
    /// </summary>
    [JsonPropertyName("private")]
    public bool? Private { get; init; }

    /// <summary>
    /// 发送消息的用户、联系人或自动化主体
    /// </summary>
    [JsonPropertyName("sender")]
    public WebhookActor? Sender { get; init; }

    /// <summary>
    /// 与事件相关的联系人
    /// </summary>
    [JsonPropertyName("contact")]
    public WebhookActor? Contact { get; init; }

    /// <summary>
    /// 与事件相关的 Chatwoot 账号
    /// </summary>
    [JsonPropertyName("account")]
    public WebhookAccount? Account { get; init; }

    /// <summary>
    /// 与事件相关的收件箱
    /// </summary>
    [JsonPropertyName("inbox")]
    public WebhookInbox? Inbox { get; init; }

    /// <summary>
    /// 与事件相关的会话
    /// </summary>
    [JsonPropertyName("conversation")]
    public WebhookConversation? Conversation { get; init; }

    /// <summary>
    /// <c>webwidget_triggered</c> 事件中的当前会话
    /// </summary>
    [JsonPropertyName("current_conversation")]
    public WebhookConversation? CurrentConversation { get; init; }

    /// <summary>
    /// 触发输入状态事件的用户或自动化主体
    /// </summary>
    [JsonPropertyName("user")]
    public WebhookActor? User { get; init; }

    /// <summary>
    /// 输入状态事件是否对应私有备注
    /// </summary>
    [JsonPropertyName("is_private")]
    public bool? IsPrivate { get; init; }

    /// <summary>
    /// 会话状态，例如 <c>open</c>、<c>pending</c> 或 <c>resolved</c>
    /// </summary>
    [JsonPropertyName("status")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<ConversationStatus>))]
    public ConversationStatus? Status { get; init; }

    /// <summary>
    /// 会话来源渠道
    /// </summary>
    [JsonPropertyName("channel")]
    public string? Channel { get; init; }

    /// <summary>
    /// 指示当前会话是否可回复
    /// </summary>
    [JsonPropertyName("can_reply")]
    public bool? CanReply { get; init; }

    /// <summary>
    /// 会话未读消息数
    /// </summary>
    [JsonPropertyName("unread_count")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? UnreadCount { get; init; }

    /// <summary>
    /// 账号标识符
    /// </summary>
    [JsonPropertyName("account_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? AccountId { get; init; }

    /// <summary>
    /// 收件箱标识符
    /// </summary>
    [JsonPropertyName("inbox_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? InboxId { get; init; }

    /// <summary>
    /// 客服最后查看会话的 Unix 时间戳
    /// </summary>
    [JsonPropertyName("agent_last_seen_at")]
    [JsonConverter(typeof(WebhookUnixTimestampConverter))]
    public long? AgentLastSeenAt { get; init; }

    /// <summary>
    /// 联系人最后查看会话的 Unix 时间戳
    /// </summary>
    [JsonPropertyName("contact_last_seen_at")]
    [JsonConverter(typeof(WebhookUnixTimestampConverter))]
    public long? ContactLastSeenAt { get; init; }

    /// <summary>
    /// 事件或会话时间戳
    /// </summary>
    [JsonPropertyName("timestamp")]
    [JsonConverter(typeof(WebhookUnixTimestampConverter))]
    public long? Timestamp { get; init; }

    /// <summary>
    /// 会话附加属性，例如浏览器、来源页面和初始化时间
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    /// <summary>
    /// <c>conversation_updated</c> 事件中变更字段的新旧值集合
    /// </summary>
    [JsonPropertyName("changed_attributes")]
    public IReadOnlyList<IDictionary<string, WebhookChangedAttributeValue>?>? ChangedAttributes { get; init; }

    /// <summary>
    /// <c>webwidget_triggered</c> 事件的上下文信息
    /// </summary>
    [JsonPropertyName("event_info")]
    public WebhookEventInfo? EventInfo { get; init; }

    /// <summary>
    /// 文档未声明或未来新增的顶层字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Chatwoot webhook 中的账号对象
/// </summary>
public sealed class WebhookAccount
{
    /// <summary>
    /// 账号标识符
    /// </summary>
    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? Id { get; init; }

    /// <summary>
    /// 账号名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 账号对象中未建模的附加字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Chatwoot webhook 中的收件箱对象
/// </summary>
public sealed class WebhookInbox
{
    /// <summary>
    /// 收件箱标识符
    /// </summary>
    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? Id { get; init; }

    /// <summary>
    /// 收件箱名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 收件箱对象中未建模的附加字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Chatwoot webhook 中的参与者对象，可表示联系人、客服、机器人或 Captain
/// </summary>
public sealed class WebhookActor
{
    /// <summary>
    /// 参与者标识符
    /// </summary>
    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? Id { get; init; }

    /// <summary>
    /// 参与者显示名称
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 参与者电子邮箱
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// 联系人头像 URL
    /// </summary>
    [JsonPropertyName("avatar")]
    public string? Avatar { get; init; }

    /// <summary>
    /// 参与者类型，例如 <c>contact</c> 或 <c>user</c>
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>参与者的可用显示名称</summary>
    [JsonPropertyName("available_name")]
    public string? AvailableName { get; init; }

    /// <summary>参与者头像 URL</summary>
    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; init; }

    /// <summary>参与者可用性状态</summary>
    [JsonPropertyName("availability_status")]
    public string? AvailabilityStatus { get; init; }

    /// <summary>联系人外部标识符</summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }

    /// <summary>参与者电话号码</summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; init; }

    /// <summary>参与者缩略图 URL</summary>
    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; init; }

    /// <summary>指示联系人是否被阻止</summary>
    [JsonPropertyName("blocked")]
    public bool? Blocked { get; init; }

    /// <summary>参与者附加属性</summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    /// <summary>参与者自定义属性</summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }

    /// <summary>
    /// 联系人归属的账号
    /// </summary>
    [JsonPropertyName("account")]
    public WebhookAccount? Account { get; init; }

    /// <summary>
    /// 参与者对象中未建模的附加字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Chatwoot webhook 中的会话对象
/// </summary>
public sealed class WebhookConversation
{
    /// <summary>
    /// 会话标识符
    /// </summary>
    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? Id { get; init; }

    /// <summary>
    /// 控制台中显示的会话编号
    /// </summary>
    [JsonPropertyName("display_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? DisplayId { get; init; }

    /// <summary>
    /// 会话所属账号标识符
    /// </summary>
    [JsonPropertyName("account_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? AccountId { get; init; }

    /// <summary>
    /// 会话所属收件箱标识符
    /// </summary>
    [JsonPropertyName("inbox_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? InboxId { get; init; }

    /// <summary>会话负责人标识符</summary>
    [JsonPropertyName("assignee_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? AssigneeId { get; init; }

    /// <summary>
    /// 会话附加属性
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    /// <summary>
    /// 指示会话是否可回复
    /// </summary>
    [JsonPropertyName("can_reply")]
    public bool? CanReply { get; init; }

    /// <summary>
    /// 会话渠道
    /// </summary>
    [JsonPropertyName("channel")]
    public string? Channel { get; init; }

    /// <summary>
    /// 联系人与收件箱的关联信息
    /// </summary>
    [JsonPropertyName("contact_inbox")]
    public WebhookContactInbox? ContactInbox { get; init; }

    /// <summary>
    /// 会话中的消息集合
    /// </summary>
    [JsonPropertyName("messages")]
    public IReadOnlyList<WebhookMessage?>? Messages { get; init; }

    /// <summary>
    /// 会话元数据，例如发送者和负责人
    /// </summary>
    [JsonPropertyName("meta")]
    public WebhookConversationMeta? Meta { get; init; }

    /// <summary>会话标签</summary>
    [JsonPropertyName("labels")]
    public IReadOnlyList<string?>? Labels { get; init; }

    /// <summary>会话自定义属性</summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }

    /// <summary>会话休眠恢复时间</summary>
    [JsonPropertyName("snoozed_until")]
    [JsonConverter(typeof(WebhookUnixTimestampConverter))]
    public long? SnoozedUntil { get; init; }

    /// <summary>首次回复时间</summary>
    [JsonPropertyName("first_reply_created_at")]
    [JsonConverter(typeof(WebhookDateTimeOffsetConverter))]
    public DateTimeOffset? FirstReplyCreatedAt { get; init; }

    /// <summary>会话优先级</summary>
    [JsonPropertyName("priority")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<ConversationPriority>))]
    public ConversationPriority? Priority { get; init; }

    /// <summary>会话等待时间</summary>
    [JsonPropertyName("waiting_since")]
    [JsonConverter(typeof(WebhookUnixTimestampConverter))]
    public long? WaitingSince { get; init; }

    /// <summary>最后活动时间</summary>
    [JsonPropertyName("last_activity_at")]
    [JsonConverter(typeof(WebhookUnixTimestampConverter))]
    public long? LastActivityAt { get; init; }

    /// <summary>会话创建时间</summary>
    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(WebhookUnixTimestampConverter))]
    public long? CreatedAt { get; init; }

    /// <summary>会话更新时间</summary>
    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(WebhookUnixTimestampConverter))]
    public long? UpdatedAt { get; init; }

    /// <summary>会话所属账号</summary>
    [JsonPropertyName("account")]
    public WebhookAccount? Account { get; init; }

    /// <summary>
    /// 会话状态
    /// </summary>
    [JsonPropertyName("status")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<ConversationStatus>))]
    public ConversationStatus? Status { get; init; }

    /// <summary>
    /// 会话未读消息数
    /// </summary>
    [JsonPropertyName("unread_count")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? UnreadCount { get; init; }

    /// <summary>
    /// 客服最后查看会话的 Unix 时间戳
    /// </summary>
    [JsonPropertyName("agent_last_seen_at")]
    [JsonConverter(typeof(WebhookUnixTimestampConverter))]
    public long? AgentLastSeenAt { get; init; }

    /// <summary>
    /// 联系人最后查看会话的 Unix 时间戳
    /// </summary>
    [JsonPropertyName("contact_last_seen_at")]
    [JsonConverter(typeof(WebhookUnixTimestampConverter))]
    public long? ContactLastSeenAt { get; init; }

    /// <summary>
    /// 会话时间戳
    /// </summary>
    [JsonPropertyName("timestamp")]
    [JsonConverter(typeof(WebhookUnixTimestampConverter))]
    public long? Timestamp { get; init; }

    /// <summary>
    /// 会话对象中未建模的附加字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Chatwoot webhook 会话中嵌套的消息对象
/// </summary>
public sealed class WebhookMessage
{
    /// <summary>消息标识符</summary>
    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? Id { get; init; }

    /// <summary>消息正文</summary>
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    /// <summary>账号标识符</summary>
    [JsonPropertyName("account_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? AccountId { get; init; }

    /// <summary>收件箱标识符</summary>
    [JsonPropertyName("inbox_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? InboxId { get; init; }

    /// <summary>会话标识符</summary>
    [JsonPropertyName("conversation_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? ConversationId { get; init; }

    /// <summary>消息状态，例如 <c>sent</c>、<c>delivered</c> 或 <c>read</c></summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>消息类型；Chatwoot 可能返回字符串或数字</summary>
    [JsonPropertyName("message_type")]
    [JsonConverter(typeof(WebhookStringOrNumberConverter))]
    public string? MessageType { get; init; }

    /// <summary>消息内容类型</summary>
    [JsonPropertyName("content_type")]
    public string? ContentType { get; init; }

    /// <summary>消息创建时间（Unix 时间戳）</summary>
    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(WebhookUnixTimestampConverter))]
    public long? CreatedAt { get; init; }

    /// <summary>消息更新时间</summary>
    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(WebhookDateTimeOffsetConverter))]
    public DateTimeOffset? UpdatedAt { get; init; }

    /// <summary>指示消息是否为私有备注</summary>
    [JsonPropertyName("private")]
    public bool? Private { get; init; }

    /// <summary>发送者类型</summary>
    [JsonPropertyName("sender_type")]
    public string? SenderType { get; init; }

    /// <summary>发送者标识符</summary>
    [JsonPropertyName("sender_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? SenderId { get; init; }

    /// <summary>外部渠道中的消息来源标识</summary>
    [JsonPropertyName("source_id")]
    public string? SourceId { get; init; }

    /// <summary>消息发送者</summary>
    [JsonPropertyName("sender")]
    public WebhookActor? Sender { get; init; }

    /// <summary>消息所属账号</summary>
    [JsonPropertyName("account")]
    public WebhookAccount? Account { get; init; }

    /// <summary>消息所属会话</summary>
    [JsonPropertyName("conversation")]
    public WebhookConversation? Conversation { get; init; }

    /// <summary>消息所属收件箱</summary>
    [JsonPropertyName("inbox")]
    public WebhookInbox? Inbox { get; init; }

    /// <summary>消息内容的附加属性</summary>
    [JsonPropertyName("content_attributes")]
    public IDictionary<string, JsonElement>? ContentAttributes { get; init; }

    /// <summary>外部系统中的消息标识符集合</summary>
    [JsonPropertyName("external_source_ids")]
    public IDictionary<string, JsonElement>? ExternalSourceIds { get; init; }

    /// <summary>消息附加属性</summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, JsonElement>? AdditionalAttributes { get; init; }

    /// <summary>处理后的消息正文</summary>
    [JsonPropertyName("processed_message_content")]
    public string? ProcessedMessageContent { get; init; }

    /// <summary>消息情感分析结果</summary>
    [JsonPropertyName("sentiment")]
    public IDictionary<string, JsonElement>? Sentiment { get; init; }

    /// <summary>未建模的消息字段</summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// 联系人与收件箱的关联对象
/// </summary>
public sealed class WebhookContactInbox
{
    /// <summary>
    /// 关联记录标识符
    /// </summary>
    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? Id { get; init; }

    /// <summary>
    /// 联系人标识符
    /// </summary>
    [JsonPropertyName("contact_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? ContactId { get; init; }

    /// <summary>
    /// 收件箱标识符
    /// </summary>
    [JsonPropertyName("inbox_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long? InboxId { get; init; }

    /// <summary>
    /// 外部来源标识
    /// </summary>
    [JsonPropertyName("source_id")]
    public string? SourceId { get; init; }

    /// <summary>
    /// 关联记录创建时间
    /// </summary>
    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(WebhookDateTimeOffsetConverter))]
    public DateTimeOffset? CreatedAt { get; init; }

    /// <summary>
    /// 关联记录更新时间
    /// </summary>
    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(WebhookDateTimeOffsetConverter))]
    public DateTimeOffset? UpdatedAt { get; init; }

    /// <summary>
    /// 指示 HMAC 校验是否通过
    /// </summary>
    [JsonPropertyName("hmac_verified")]
    public bool? HmacVerified { get; init; }

    /// <summary>用于客户端发布订阅的令牌</summary>
    [JsonPropertyName("pubsub_token")]
    public string? PubsubToken { get; init; }

    /// <summary>
    /// 关联对象中未建模的附加字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Chatwoot 会话元数据
/// </summary>
public sealed class WebhookConversationMeta
{
    /// <summary>
    /// 会话发送者
    /// </summary>
    [JsonPropertyName("sender")]
    public WebhookActor? Sender { get; init; }

    /// <summary>
    /// 会话负责人
    /// </summary>
    [JsonPropertyName("assignee")]
    public WebhookActor? Assignee { get; init; }

    /// <summary>负责人类型</summary>
    [JsonPropertyName("assignee_type")]
    public string? AssigneeType { get; init; }

    /// <summary>会话所属团队</summary>
    [JsonPropertyName("team")]
    public JsonElement? Team { get; init; }

    /// <summary>HMAC 校验是否通过</summary>
    [JsonPropertyName("hmac_verified")]
    public bool? HmacVerified { get; init; }

    /// <summary>
    /// 元数据对象中未建模的附加字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// 会话变更字段的新旧值
/// </summary>
public sealed class WebhookChangedAttributeValue
{
    /// <summary>
    /// 字段当前值
    /// </summary>
    [JsonPropertyName("current_value")]
    public JsonElement CurrentValue { get; init; }

    /// <summary>
    /// 字段先前值
    /// </summary>
    [JsonPropertyName("previous_value")]
    public JsonElement PreviousValue { get; init; }

    /// <summary>
    /// 变更值对象中未建模的附加字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// <c>webwidget_triggered</c> webhook 的事件上下文
/// </summary>
public sealed class WebhookEventInfo
{
    /// <summary>
    /// 事件初始化时间，可为文档中的对象或字符串格式
    /// </summary>
    [JsonPropertyName("initiated_at")]
    public JsonElement? InitiatedAt { get; init; }

    /// <summary>
    /// 触发 widget 的来源页面
    /// </summary>
    [JsonPropertyName("referer")]
    public string? Referer { get; init; }

    /// <summary>
    /// Widget 配置语言
    /// </summary>
    [JsonPropertyName("widget_language")]
    public string? WidgetLanguage { get; init; }

    /// <summary>
    /// 浏览器语言
    /// </summary>
    [JsonPropertyName("browser_language")]
    public string? BrowserLanguage { get; init; }

    /// <summary>
    /// 浏览器信息，例如浏览器名称、版本、设备和平台
    /// </summary>
    [JsonPropertyName("browser")]
    public IDictionary<string, JsonElement>? Browser { get; init; }

    /// <summary>
    /// 事件上下文中未建模的附加字段
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

/// <summary>
/// 读取 Chatwoot 的 Unix 时间戳。数字小数和数字字符串会截断到秒。
/// </summary>
internal sealed class WebhookUnixTimestampConverter : JsonConverter<long?>
{
    public override long? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        if (reader.TokenType == JsonTokenType.Number)
        {
            if (reader.TryGetInt64(out var integer))
            {
                return integer;
            }

            if (reader.TryGetDecimal(out var decimalValue))
            {
                return ToUnixSeconds(decimalValue);
            }
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            var value = reader.GetString();
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            if (long.TryParse(value, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out var integer))
            {
                return integer;
            }

            if (decimal.TryParse(value, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var decimalValue))
            {
                return ToUnixSeconds(decimalValue);
            }
        }

        throw new JsonException($"Cannot convert {reader.TokenType} to a Unix timestamp.");
    }

    public override void Write(Utf8JsonWriter writer, long? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteNumberValue(value.Value);
        }
        else
        {
            writer.WriteNullValue();
        }
    }

    private static long ToUnixSeconds(decimal value)
    {
        try
        {
            return checked((long)decimal.Truncate(value));
        }
        catch (OverflowException exception)
        {
            throw new JsonException("The Unix timestamp is outside the Int64 range.", exception);
        }
    }
}

/// <summary>
/// 读取 ISO 8601 时间字符串；同时兼容 Chatwoot 偶尔返回的 Unix 秒数字。
/// </summary>
internal sealed class WebhookDateTimeOffsetConverter : JsonConverter<DateTimeOffset?>
{
    public override DateTimeOffset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            var value = reader.GetString();
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            // Older webhook examples use a trailing " UTC" instead of an ISO "Z".
            if (value.EndsWith(" UTC", StringComparison.OrdinalIgnoreCase))
            {
                value = string.Concat(value.AsSpan(0, value.Length - 4), "Z");
            }

            if (DateTimeOffset.TryParse(
                    value,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.AllowWhiteSpaces | System.Globalization.DateTimeStyles.AssumeUniversal,
                    out var dateTime))
            {
                return dateTime;
            }
        }

        if (reader.TokenType == JsonTokenType.Number && reader.TryGetDecimal(out var unixSeconds))
        {
            try
            {
                return DateTimeOffset.UnixEpoch.AddSeconds((double)unixSeconds);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                throw new JsonException("The Unix timestamp is outside the DateTimeOffset range.", exception);
            }
        }

        throw new JsonException($"Cannot convert {reader.TokenType} to DateTimeOffset.");
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteStringValue(value.Value);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
