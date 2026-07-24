using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：会话列表
/// </summary>
public sealed record ConversationList
{
    /// <summary>
    /// 会话列表数据（计数元数据 + 会话数组）
    /// </summary>
    [JsonPropertyName("data")]
    public ConversationListData? Data { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Chatwoot 应用模型：会话列表 data 节点
/// </summary>
public sealed record ConversationListData
{
    /// <summary>
    /// 会话计数元数据
    /// </summary>
    [JsonPropertyName("meta")]
    public ConversationListMeta? Meta { get; init; }

    /// <summary>
    /// 会话列表
    /// </summary>
    [JsonPropertyName("payload")]
    public IReadOnlyList<ConversationListItem>? Payload { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Chatwoot 应用模型：会话列表项（会话 + 列表项 meta）
/// </summary>
public sealed record ConversationListItem : Conversation
{
    /// <summary>
    /// 列表项元数据（发送者、渠道、负责人等）
    /// </summary>
    [JsonPropertyName("meta")]
    public ConversationListItemMeta? Meta { get; init; }
}

/// <summary>
/// Chatwoot 应用模型：会话列表项 / 详情中的 meta
/// </summary>
public sealed record ConversationListItemMeta
{
    /// <summary>
    /// 会话发送者（联系人）
    /// </summary>
    [JsonPropertyName("sender")]
    public ConversationListSender? Sender { get; init; }

    /// <summary>
    /// 渠道类型
    /// </summary>
    [JsonPropertyName("channel")]
    public string? Channel { get; init; }

    /// <summary>
    /// 会话负责人
    /// </summary>
    [JsonPropertyName("assignee")]
    public User? Assignee { get; init; }

    /// <summary>
    /// HMAC 是否已校验
    /// </summary>
    [JsonPropertyName("hmac_verified")]
    public bool? HmacVerified { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Chatwoot 应用模型：会话列表项中的发送者
/// </summary>
public sealed record ConversationListSender
{
    /// <summary>
    /// 发送者附加属性
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public ContactAdditionalAttributes? AdditionalAttributes { get; init; }

    /// <summary>
    /// 发送者可用性状态
    /// </summary>
    [JsonPropertyName("availability_status")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<AgentAvailability>))]
    public AgentAvailability? AvailabilityStatus { get; init; }

    /// <summary>
    /// 发送者邮箱
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// 发送者 ID
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; init; }

    /// <summary>
    /// 发送者姓名
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// 发送者电话号码
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; init; }

    /// <summary>
    /// 发送者是否被屏蔽
    /// </summary>
    [JsonPropertyName("blocked")]
    public bool? Blocked { get; init; }

    /// <summary>
    /// 发送者标识符
    /// </summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }

    /// <summary>
    /// 发送者头像 URL
    /// </summary>
    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; init; }

    /// <summary>
    /// 发送者自定义属性
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement>? CustomAttributes { get; init; }

    /// <summary>
    /// 发送者最后活动时间（Unix 时间戳）
    /// </summary>
    [JsonPropertyName("last_activity_at")]
    public long? LastActivityAt { get; init; }

    /// <summary>
    /// 发送者创建时间（Unix 时间戳）
    /// </summary>
    [JsonPropertyName("created_at")]
    public long? CreatedAt { get; init; }

    /// <summary>
    /// Swagger 未显式建模的附加 JSON 字段
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
