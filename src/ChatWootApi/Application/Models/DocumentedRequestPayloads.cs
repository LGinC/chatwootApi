using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>Chatwoot 应用模型：筛选请求载荷</summary>
public sealed record FilterPayload
{
    /// <summary>筛选条件列表</summary>
    [JsonPropertyName("payload")]
    public IReadOnlyList<FilterCondition> Payload { get; init; } = [];
}

/// <summary>Chatwoot 应用模型：筛选条件</summary>
public sealed record FilterCondition
{
    /// <summary>用于筛选的属性名称</summary>
    [JsonPropertyName("attribute_key")] public string? AttributeKey { get; init; }
    /// <summary>比较运算符</summary>
    [JsonPropertyName("filter_operator")] [JsonConverter(typeof(JsonStringEnumConverter<FilterOperator>))] public FilterOperator? FilterOperator { get; init; }
    /// <summary>待匹配的属性值</summary>
    [JsonPropertyName("values")] public IReadOnlyList<string> Values { get; init; } = [];
    /// <summary>与下一条件连接的逻辑运算符</summary>
    [JsonPropertyName("query_operator")] [JsonConverter(typeof(JsonStringEnumConverter<QueryOperator>))] public QueryOperator? QueryOperator { get; init; }
}

/// <summary>Chatwoot 应用模型：创建联系人收件箱关联的请求载荷</summary>
public sealed record ContactInboxCreatePayload
{
    /// <summary>收件箱 ID</summary>
    [JsonPropertyName("inbox_id")] public long InboxId { get; init; }
    /// <summary>联系人在该收件箱中的来源标识符</summary>
    [JsonPropertyName("source_id")] public string? SourceId { get; init; }
}

/// <summary>Chatwoot 应用模型：合并联系人的请求载荷</summary>
public sealed record ContactMergePayload
{
    /// <summary>合并后保留的联系人 ID</summary>
    [JsonPropertyName("base_contact_id")] public long BaseContactId { get; init; }
    /// <summary>将被合并并删除的联系人 ID</summary>
    [JsonPropertyName("mergee_contact_id")] public long MergeeContactId { get; init; }
}

/// <summary>Chatwoot 应用模型：标签列表请求载荷</summary>
public sealed record LabelsPayload
{
    /// <summary>要设置的标签列表</summary>
    [JsonPropertyName("labels")] public IReadOnlyList<string> Labels { get; init; } = [];
}

/// <summary>Chatwoot 应用模型：设置收件箱坐席机器人的请求载荷</summary>
public sealed record InboxAgentBotUpdatePayload
{
    /// <summary>坐席机器人 ID；为 null 时移除当前机器人</summary>
    [JsonPropertyName("agent_bot")] public long? AgentBot { get; init; }
}

/// <summary>Chatwoot 应用模型：更新会话属性的请求载荷</summary>
public sealed record ConversationUpdatePayload
{
    /// <summary>会话优先级</summary>
    [JsonPropertyName("priority")] [JsonConverter(typeof(ChatWootStringEnumConverter<ConversationPriority>))] public ConversationPriority? Priority { get; init; }
    /// <summary>SLA 策略 ID（仅企业版支持）</summary>
    [JsonPropertyName("sla_policy_id")] public long? SlaPolicyId { get; init; }
}

/// <summary>Chatwoot 应用模型：更新会话状态的请求载荷</summary>
public sealed record ConversationStatusUpdatePayload
{
    /// <summary>目标会话状态</summary>
    [JsonPropertyName("status")] [JsonConverter(typeof(ChatWootStringEnumConverter<ConversationStatus>))] public ConversationStatus Status { get; init; }
    /// <summary>状态为休眠时的恢复时间（Unix 时间戳，秒）；省略时将在联系人下次回复后恢复，且联系人回复始终会恢复会话</summary>
    [JsonPropertyName("snoozed_until")] public long? SnoozedUntil { get; init; }
}

/// <summary>Chatwoot 应用模型：更新会话优先级的请求载荷</summary>
public sealed record ConversationPriorityUpdatePayload
{
    /// <summary>目标会话优先级</summary>
    [JsonPropertyName("priority")] [JsonConverter(typeof(ChatWootStringEnumConverter<ConversationPriority>))] public ConversationPriority Priority { get; init; }
}

/// <summary>Chatwoot 应用模型：更新会话输入状态的请求载荷</summary>
public sealed record ConversationTypingStatusPayload
{
    /// <summary>目标输入状态</summary>
    [JsonPropertyName("typing_status")] [JsonConverter(typeof(ChatWootStringEnumConverter<TypingStatus>))] public TypingStatus TypingStatus { get; init; }
    /// <summary>输入状态是否针对私密备注</summary>
    [JsonPropertyName("is_private")] public bool? IsPrivate { get; init; }
}

/// <summary>Chatwoot 应用模型：更新会话自定义属性的请求载荷</summary>
public sealed record ConversationCustomAttributesUpdatePayload
{
    /// <summary>要设置的自定义属性</summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, JsonElement> CustomAttributes { get; init; } = new Dictionary<string, JsonElement>();
}

/// <summary>Chatwoot 应用模型：管理团队成员的请求载荷</summary>
public sealed record TeamMembersUpdatePayload
{
    /// <summary>要新增、替换或移除的团队成员用户 ID 列表</summary>
    [JsonPropertyName("user_ids")] public IReadOnlyList<long> UserIds { get; init; } = [];
}

/// <summary>Chatwoot 应用模型：更新个人资料的请求载荷</summary>
public sealed record ProfileUpdatePayload
{
    /// <summary>个人资料字段</summary>
    [JsonPropertyName("profile")] public ProfileUpdateProfile Profile { get; init; } = new();
}

/// <summary>Chatwoot 应用模型：可更新的个人资料字段</summary>
public sealed record ProfileUpdateProfile
{
    /// <summary>用户名称</summary>
    [JsonPropertyName("name")] public string? Name { get; init; }
    /// <summary>用户电子邮件地址</summary>
    [JsonPropertyName("email")] public string? Email { get; init; }
    /// <summary>显示名称</summary>
    [JsonPropertyName("display_name")] public string? DisplayName { get; init; }
    /// <summary>消息签名</summary>
    [JsonPropertyName("message_signature")] public string? MessageSignature { get; init; }
    /// <summary>电话号码</summary>
    [JsonPropertyName("phone_number")] public string? PhoneNumber { get; init; }
    /// <summary>当前密码</summary>
    [JsonPropertyName("current_password")] public string? CurrentPassword { get; init; }
    /// <summary>新密码</summary>
    [JsonPropertyName("password")] public string? Password { get; init; }
    /// <summary>新密码确认值</summary>
    [JsonPropertyName("password_confirmation")] public string? PasswordConfirmation { get; init; }
    /// <summary>用户界面设置</summary>
    [JsonPropertyName("ui_settings")] public IDictionary<string, JsonElement>? UiSettings { get; init; }
    /// <summary>头像文件或头像 URL；仅 multipart/form-data 请求支持二进制文件</summary>
    [JsonPropertyName("avatar")] public string? Avatar { get; init; }
}

/// <summary>筛选条件支持的比较运算符</summary>
public enum FilterOperator
{
    /// <summary>等于</summary>
    [JsonStringEnumMemberName("equal_to")] EqualTo,
    /// <summary>不等于</summary>
    [JsonStringEnumMemberName("not_equal_to")] NotEqualTo,
    /// <summary>包含</summary>
    [JsonStringEnumMemberName("contains")] Contains,
    /// <summary>不包含</summary>
    [JsonStringEnumMemberName("does_not_contain")] DoesNotContain
}
/// <summary>筛选条件之间的逻辑运算符</summary>
public enum QueryOperator
{
    /// <summary>并且</summary>
    AND,
    /// <summary>或者</summary>
    OR
}
/// <summary>会话优先级</summary>
public enum ConversationPriority
{
    /// <summary>紧急</summary>
    Urgent,
    /// <summary>高</summary>
    High,
    /// <summary>中</summary>
    Medium,
    /// <summary>低</summary>
    Low,
    /// <summary>无</summary>
    None
}
/// <summary>会话状态</summary>
public enum ConversationStatus
{
    /// <summary>打开</summary>
    Open,
    /// <summary>已解决</summary>
    Resolved,
    /// <summary>待处理</summary>
    Pending,
    /// <summary>休眠</summary>
    Snoozed
}
/// <summary>会话输入状态</summary>
public enum TypingStatus
{
    /// <summary>开启</summary>
    On,
    /// <summary>关闭</summary>
    Off
}
