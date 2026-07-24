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
    /// <summary>全部</summary>
    All,
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

/// <summary>会话负责人筛选类型</summary>
public enum ConversationAssigneeType
{
    /// <summary>当前用户负责</summary>
    Me,
    /// <summary>未分配</summary>
    Unassigned,
    /// <summary>全部</summary>
    All,
    /// <summary>已分配</summary>
    Assigned
}

/// <summary>联系人列表排序字段</summary>
public enum ContactSort
{
    /// <summary>按名称升序</summary>
    Name,
    /// <summary>按邮箱升序</summary>
    Email,
    /// <summary>按电话号码升序</summary>
    [JsonStringEnumMemberName("phone_number")]
    PhoneNumber,
    /// <summary>按最后活动时间升序</summary>
    [JsonStringEnumMemberName("last_activity_at")]
    LastActivityAt,
    /// <summary>按名称降序</summary>
    [JsonStringEnumMemberName("-name")]
    NameDesc,
    /// <summary>按邮箱降序</summary>
    [JsonStringEnumMemberName("-email")]
    EmailDesc,
    /// <summary>按电话号码降序</summary>
    [JsonStringEnumMemberName("-phone_number")]
    PhoneNumberDesc,
    /// <summary>按最后活动时间降序</summary>
    [JsonStringEnumMemberName("-last_activity_at")]
    LastActivityAtDesc
}

/// <summary>自定义属性模型类型</summary>
public enum CustomAttributeModel
{
    /// <summary>会话属性</summary>
    [JsonStringEnumMemberName("0")]
    ConversationAttribute = 0,
    /// <summary>联系人属性</summary>
    [JsonStringEnumMemberName("1")]
    ContactAttribute = 1
}

/// <summary>自定义筛选器类型</summary>
public enum CustomFilterType
{
    /// <summary>会话筛选器</summary>
    Conversation,
    /// <summary>联系人筛选器</summary>
    Contact,
    /// <summary>报表筛选器</summary>
    Report
}

/// <summary>报表指标类型</summary>
public enum ReportMetric
{
    /// <summary>会话数量</summary>
    [JsonStringEnumMemberName("conversations_count")]
    ConversationsCount,
    /// <summary>入站消息数量</summary>
    [JsonStringEnumMemberName("incoming_messages_count")]
    IncomingMessagesCount,
    /// <summary>出站消息数量</summary>
    [JsonStringEnumMemberName("outgoing_messages_count")]
    OutgoingMessagesCount,
    /// <summary>平均首次响应时间</summary>
    [JsonStringEnumMemberName("avg_first_response_time")]
    AvgFirstResponseTime,
    /// <summary>平均解决时间</summary>
    [JsonStringEnumMemberName("avg_resolution_time")]
    AvgResolutionTime,
    /// <summary>解决数量</summary>
    [JsonStringEnumMemberName("resolutions_count")]
    ResolutionsCount
}

/// <summary>报表对象类型</summary>
public enum ReportType
{
    /// <summary>账号</summary>
    Account,
    /// <summary>坐席</summary>
    Agent,
    /// <summary>收件箱</summary>
    Inbox,
    /// <summary>标签</summary>
    Label,
    /// <summary>团队</summary>
    Team
}

/// <summary>出站消息统计分组维度</summary>
public enum OutgoingMessagesGroupBy
{
    /// <summary>按坐席</summary>
    Agent,
    /// <summary>按团队</summary>
    Team,
    /// <summary>按收件箱</summary>
    Inbox,
    /// <summary>按标签</summary>
    Label
}

/// <summary>账号用户 / 坐席角色</summary>
public enum AccountUserRole
{
    /// <summary>普通坐席</summary>
    Agent,
    /// <summary>管理员</summary>
    Administrator
}

/// <summary>坐席或联系人可用性状态</summary>
public enum AgentAvailability
{
    /// <summary>在线</summary>
    Online,
    /// <summary>忙碌（仅坐席）</summary>
    Busy,
    /// <summary>离线</summary>
    Offline
}

/// <summary>账号状态</summary>
public enum AccountStatus
{
    /// <summary>活跃</summary>
    Active,
    /// <summary>已暂停</summary>
    Suspended
}

/// <summary>Webhook 可订阅事件</summary>
public enum WebhookSubscriptionEvent
{
    /// <summary>会话已创建</summary>
    [JsonStringEnumMemberName("conversation_created")]
    ConversationCreated,
    /// <summary>会话状态已变更</summary>
    [JsonStringEnumMemberName("conversation_status_changed")]
    ConversationStatusChanged,
    /// <summary>会话已更新</summary>
    [JsonStringEnumMemberName("conversation_updated")]
    ConversationUpdated,
    /// <summary>联系人已创建</summary>
    [JsonStringEnumMemberName("contact_created")]
    ContactCreated,
    /// <summary>联系人已更新</summary>
    [JsonStringEnumMemberName("contact_updated")]
    ContactUpdated,
    /// <summary>消息已创建</summary>
    [JsonStringEnumMemberName("message_created")]
    MessageCreated,
    /// <summary>消息已更新</summary>
    [JsonStringEnumMemberName("message_updated")]
    MessageUpdated,
    /// <summary>网页小部件被触发</summary>
    [JsonStringEnumMemberName("webwidget_triggered")]
    WebwidgetTriggered,
    /// <summary>会话开始输入</summary>
    [JsonStringEnumMemberName("conversation_typing_on")]
    ConversationTypingOn,
    /// <summary>会话停止输入</summary>
    [JsonStringEnumMemberName("conversation_typing_off")]
    ConversationTypingOff
}

/// <summary>自动化规则触发事件</summary>
public enum AutomationRuleEvent
{
    /// <summary>会话已创建</summary>
    [JsonStringEnumMemberName("conversation_created")]
    ConversationCreated,
    /// <summary>会话已更新</summary>
    [JsonStringEnumMemberName("conversation_updated")]
    ConversationUpdated,
    /// <summary>会话已解决</summary>
    [JsonStringEnumMemberName("conversation_resolved")]
    ConversationResolved,
    /// <summary>消息已创建</summary>
    [JsonStringEnumMemberName("message_created")]
    MessageCreated
}

/// <summary>审计日志操作</summary>
public enum AuditLogAction
{
    /// <summary>创建</summary>
    Create,
    /// <summary>更新</summary>
    Update,
    /// <summary>删除</summary>
    Destroy
}

/// <summary>出站邮件发件人姓名类型</summary>
public enum SenderNameType
{
    /// <summary>友好名称</summary>
    Friendly,
    /// <summary>专业名称</summary>
    Professional
}

/// <summary>网页小部件预计回复时间</summary>
public enum WidgetReplyTime
{
    /// <summary>几分钟内</summary>
    [JsonStringEnumMemberName("in_a_few_minutes")]
    InAFewMinutes,
    /// <summary>几小时内</summary>
    [JsonStringEnumMemberName("in_a_few_hours")]
    InAFewHours,
    /// <summary>一天内</summary>
    [JsonStringEnumMemberName("in_a_day")]
    InADay
}

/// <summary>CSAT 展示样式</summary>
public enum CsatDisplayType
{
    /// <summary>表情</summary>
    Emoji,
    /// <summary>星级</summary>
    Star
}

/// <summary>网页小部件功能开关</summary>
public enum WebWidgetFeatureFlag
{
    /// <summary>附件</summary>
    Attachments,
    /// <summary>表情选择器</summary>
    [JsonStringEnumMemberName("emoji_picker")]
    EmojiPicker,
    /// <summary>结束会话</summary>
    [JsonStringEnumMemberName("end_conversation")]
    EndConversation,
    /// <summary>机器人使用收件箱头像</summary>
    [JsonStringEnumMemberName("use_inbox_avatar_for_bot")]
    UseInboxAvatarForBot,
    /// <summary>允许移动端 WebView</summary>
    [JsonStringEnumMemberName("allow_mobile_webview")]
    AllowMobileWebview
}

/// <summary>WhatsApp 渠道提供商</summary>
public enum WhatsAppProvider
{
    /// <summary>WhatsApp Cloud API</summary>
    [JsonStringEnumMemberName("whatsapp_cloud")]
    WhatsappCloud,
    /// <summary>旧版 360dialog（仅存量）</summary>
    Default
}

/// <summary>消息附件文件类型</summary>
public enum AttachmentFileType
{
    /// <summary>图片</summary>
    Image,
    /// <summary>音频</summary>
    Audio,
    /// <summary>视频</summary>
    Video,
    /// <summary>文件</summary>
    File,
    /// <summary>位置</summary>
    Location,
    /// <summary>回退</summary>
    Fallback,
    /// <summary>分享</summary>
    Share,
    /// <summary>动态提及</summary>
    [JsonStringEnumMemberName("story_mention")]
    StoryMention,
    /// <summary>联系人</summary>
    Contact,
    /// <summary>Instagram Reel</summary>
    [JsonStringEnumMemberName("ig_reel")]
    IgReel,
    /// <summary>Instagram 帖子</summary>
    [JsonStringEnumMemberName("ig_post")]
    IgPost,
    /// <summary>Instagram 快拍</summary>
    [JsonStringEnumMemberName("ig_story")]
    IgStory,
    /// <summary>嵌入内容</summary>
    Embed
}

/// <summary>公开消息发送者类型</summary>
public enum PublicMessageSenderType
{
    /// <summary>联系人</summary>
    Contact,
    /// <summary>用户</summary>
    User,
    /// <summary>坐席机器人</summary>
    [JsonStringEnumMemberName("agent_bot")]
    AgentBot,
    /// <summary>Captain 助手</summary>
    [JsonStringEnumMemberName("captain_assistant")]
    CaptainAssistant
}

/// <summary>CSAT 调查配置</summary>
public sealed record CsatConfig
{
    /// <summary>CSAT 展示样式</summary>
    [JsonPropertyName("display_type")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<CsatDisplayType>))]
    public CsatDisplayType? DisplayType { get; set; }

    /// <summary>随 CSAT 调查显示的消息</summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>CSAT 调查按钮文案</summary>
    [JsonPropertyName("button_text")]
    public string? ButtonText { get; set; }

    /// <summary>CSAT 调查语言代码</summary>
    [JsonPropertyName("language")]
    public string? Language { get; set; }

    /// <summary>决定何时展示 CSAT 调查的规则</summary>
    [JsonPropertyName("survey_rules")]
    public CsatSurveyRules? SurveyRules { get; set; }
}

/// <summary>CSAT 展示规则</summary>
public sealed record CsatSurveyRules
{
    /// <summary>比较运算符（例如 contains）</summary>
    [JsonPropertyName("operator")]
    public string? Operator { get; set; }

    /// <summary>匹配值列表</summary>
    [JsonPropertyName("values")]
    public IReadOnlyList<string>? Values { get; set; }
}

/// <summary>WhatsApp 模板类别</summary>
public enum WhatsAppTemplateCategory
{
    /// <summary>实用类</summary>
    [JsonStringEnumMemberName("UTILITY")]
    Utility,
    /// <summary>营销类</summary>
    [JsonStringEnumMemberName("MARKETING")]
    Marketing,
    /// <summary>物流更新</summary>
    [JsonStringEnumMemberName("SHIPPING_UPDATE")]
    ShippingUpdate,
    /// <summary>工单更新</summary>
    [JsonStringEnumMemberName("TICKET_UPDATE")]
    TicketUpdate,
    /// <summary>问题解决</summary>
    [JsonStringEnumMemberName("ISSUE_RESOLUTION")]
    IssueResolution
}

/// <summary>WhatsApp 模板页眉媒体类型</summary>
public enum WhatsAppTemplateMediaType
{
    /// <summary>图片</summary>
    Image,
    /// <summary>视频</summary>
    Video,
    /// <summary>文档</summary>
    Document
}

/// <summary>WhatsApp 模板按钮参数类型</summary>
public enum WhatsAppTemplateButtonType
{
    /// <summary>URL 按钮</summary>
    Url,
    /// <summary>复制验证码按钮</summary>
    [JsonStringEnumMemberName("copy_code")]
    CopyCode
}

/// <summary>发送结构化 WhatsApp 模板消息的参数</summary>
public sealed record WhatsAppTemplateParams
{
    /// <summary>已在 WhatsApp Business Manager 中批准的模板名称</summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>模板类别</summary>
    [JsonPropertyName("category")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<WhatsAppTemplateCategory>))]
    public WhatsAppTemplateCategory? Category { get; set; }

    /// <summary>模板语言代码（BCP 47）</summary>
    [JsonPropertyName("language")]
    public string? Language { get; set; }

    /// <summary>按组件类型组织的已处理模板参数</summary>
    [JsonPropertyName("processed_params")]
    public WhatsAppTemplateProcessedParams? ProcessedParams { get; set; }
}

/// <summary>WhatsApp 模板已处理参数</summary>
public sealed record WhatsAppTemplateProcessedParams
{
    /// <summary>正文变量占位符（键为变量序号）</summary>
    [JsonPropertyName("body")]
    public IDictionary<string, string>? Body { get; set; }

    /// <summary>页眉媒体参数</summary>
    [JsonPropertyName("header")]
    public WhatsAppTemplateHeaderParams? Header { get; set; }

    /// <summary>交互按钮参数</summary>
    [JsonPropertyName("buttons")]
    public IReadOnlyList<WhatsAppTemplateButtonParam>? Buttons { get; set; }
}

/// <summary>WhatsApp 模板页眉参数</summary>
public sealed record WhatsAppTemplateHeaderParams
{
    /// <summary>图片 / 视频 / 文档页眉的公开可访问 URL</summary>
    [JsonPropertyName("media_url")]
    public string? MediaUrl { get; set; }

    /// <summary>页眉媒体类型</summary>
    [JsonPropertyName("media_type")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<WhatsAppTemplateMediaType>))]
    public WhatsAppTemplateMediaType? MediaType { get; set; }
}

/// <summary>WhatsApp 模板按钮参数</summary>
public sealed record WhatsAppTemplateButtonParam
{
    /// <summary>按钮参数类型</summary>
    [JsonPropertyName("type")]
    [JsonConverter(typeof(ChatWootStringEnumConverter<WhatsAppTemplateButtonType>))]
    public WhatsAppTemplateButtonType? Type { get; set; }

    /// <summary>按钮动态参数值</summary>
    [JsonPropertyName("parameter")]
    public string? Parameter { get; set; }
}

/// <summary>创建会话时发送的初始消息</summary>
public sealed record ConversationCreateMessage
{
    /// <summary>消息正文（必填）</summary>
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    /// <summary>WhatsApp 渠道下的模板参数</summary>
    [JsonPropertyName("template_params")]
    public WhatsAppTemplateParams? TemplateParams { get; set; }
}

/// <summary>账号设置（响应 <c>account_detail.settings</c>）</summary>
public sealed record AccountSettings
{
    /// <summary>指定分钟后自动解决会话</summary>
    [JsonPropertyName("auto_resolve_after")]
    public long? AutoResolveAfter { get; init; }

    /// <summary>自动解决时发送的消息</summary>
    [JsonPropertyName("auto_resolve_message")]
    public string? AutoResolveMessage { get; init; }

    /// <summary>自动解决时是否忽略等待中的会话</summary>
    [JsonPropertyName("auto_resolve_ignore_waiting")]
    public bool? AutoResolveIgnoreWaiting { get; init; }

    /// <summary>Swagger 未显式建模的附加 JSON 字段</summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>WhatsApp 渠道提供商配置（Cloud 与旧版 360dialog 共用字段）</summary>
public sealed record WhatsAppProviderConfig
{
    /// <summary>提供商 API Key</summary>
    [JsonPropertyName("api_key")]
    public string? ApiKey { get; init; }

    /// <summary>WhatsApp Cloud 电话号码 ID</summary>
    [JsonPropertyName("phone_number_id")]
    public string? PhoneNumberId { get; init; }

    /// <summary>WhatsApp Cloud 企业账号 ID</summary>
    [JsonPropertyName("business_account_id")]
    public string? BusinessAccountId { get; init; }

    /// <summary>Swagger 未显式建模的附加 JSON 字段</summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>联系人附加属性（响应）</summary>
public sealed record ContactAdditionalAttributes
{
    /// <summary>城市</summary>
    [JsonPropertyName("city")]
    public string? City { get; init; }

    /// <summary>国家</summary>
    [JsonPropertyName("country")]
    public string? Country { get; init; }

    /// <summary>国家代码</summary>
    [JsonPropertyName("country_code")]
    public string? CountryCode { get; init; }

    /// <summary>创建联系人时的 IP</summary>
    [JsonPropertyName("created_at_ip")]
    public string? CreatedAtIp { get; init; }

    /// <summary>Swagger 未显式建模的附加 JSON 字段</summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>会话附加属性中的浏览器信息</summary>
public sealed record ConversationBrowserInfo
{
    /// <summary>设备名称</summary>
    [JsonPropertyName("device_name")]
    public string? DeviceName { get; init; }

    /// <summary>浏览器名称</summary>
    [JsonPropertyName("browser_name")]
    public string? BrowserName { get; init; }

    /// <summary>平台名称</summary>
    [JsonPropertyName("platform_name")]
    public string? PlatformName { get; init; }

    /// <summary>浏览器版本</summary>
    [JsonPropertyName("browser_version")]
    public string? BrowserVersion { get; init; }

    /// <summary>平台版本</summary>
    [JsonPropertyName("platform_version")]
    public string? PlatformVersion { get; init; }

    /// <summary>Swagger 未显式建模的附加 JSON 字段</summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>会话发起时间信息</summary>
public sealed record ConversationInitiatedAt
{
    /// <summary>发起时间戳</summary>
    [JsonPropertyName("timestamp")]
    public string? Timestamp { get; init; }

    /// <summary>Swagger 未显式建模的附加 JSON 字段</summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>会话附加属性（响应）</summary>
public sealed record ConversationAdditionalAttributes
{
    /// <summary>浏览器信息</summary>
    [JsonPropertyName("browser")]
    public ConversationBrowserInfo? Browser { get; init; }

    /// <summary>来源 URL</summary>
    [JsonPropertyName("referer")]
    public string? Referer { get; init; }

    /// <summary>会话发起时间</summary>
    [JsonPropertyName("initiated_at")]
    public ConversationInitiatedAt? InitiatedAt { get; init; }

    /// <summary>浏览器语言</summary>
    [JsonPropertyName("browser_language")]
    public string? BrowserLanguage { get; init; }

    /// <summary>会话语言</summary>
    [JsonPropertyName("conversation_language")]
    public string? ConversationLanguage { get; init; }

    /// <summary>Swagger 未显式建模的附加 JSON 字段</summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>账号自定义属性（响应 <c>account_detail.custom_attributes</c>）</summary>
public sealed record AccountCustomAttributes
{
    /// <summary>订阅计划名称</summary>
    [JsonPropertyName("plan_name")]
    public string? PlanName { get; init; }

    /// <summary>订阅数量</summary>
    [JsonPropertyName("subscribed_quantity")]
    public long? SubscribedQuantity { get; init; }

    /// <summary>订阅状态</summary>
    [JsonPropertyName("subscription_status")]
    public string? SubscriptionStatus { get; init; }

    /// <summary>订阅结束日期</summary>
    [JsonPropertyName("subscription_ends_on")]
    public string? SubscriptionEndsOn { get; init; }

    /// <summary>行业</summary>
    [JsonPropertyName("industry")]
    public string? Industry { get; init; }

    /// <summary>公司规模</summary>
    [JsonPropertyName("company_size")]
    public string? CompanySize { get; init; }

    /// <summary>时区</summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    /// <summary>Logo URL</summary>
    [JsonPropertyName("logo")]
    public string? Logo { get; init; }

    /// <summary>当前入驻步骤</summary>
    [JsonPropertyName("onboarding_step")]
    public string? OnboardingStep { get; init; }

    /// <summary>标记删除时间</summary>
    [JsonPropertyName("marked_for_deletion_at")]
    public string? MarkedForDeletionAt { get; init; }

    /// <summary>标记删除原因</summary>
    [JsonPropertyName("marked_for_deletion_reason")]
    public string? MarkedForDeletionReason { get; init; }

    /// <summary>Swagger 未显式建模的附加 JSON 字段</summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>消息 content_attributes（至少文档了 in_reply_to）</summary>
public sealed record MessageContentAttributes
{
    /// <summary>所回复消息的 ID</summary>
    [JsonPropertyName("in_reply_to")]
    public string? InReplyTo { get; init; }

    /// <summary>随 content_type 变化的其它字段</summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>门户允许的区域设置项（响应）</summary>
public sealed record PortalLocaleConfig
{
    /// <summary>语言代码</summary>
    [JsonPropertyName("code")]
    public string? Code { get; init; }

    /// <summary>该区域设置下的文章数</summary>
    [JsonPropertyName("articles_count")]
    public int? ArticlesCount { get; init; }

    /// <summary>该区域设置下的分类数</summary>
    [JsonPropertyName("categories_count")]
    public int? CategoriesCount { get; init; }

    /// <summary>Swagger 未显式建模的附加 JSON 字段</summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>创建/更新门户时的 config 载荷（example 形态）</summary>
public sealed record PortalCreateUpdateConfig
{
    /// <summary>允许的区域设置代码列表</summary>
    [JsonPropertyName("allowed_locales")]
    public IReadOnlyList<string>? AllowedLocales { get; set; }

    /// <summary>默认区域设置</summary>
    [JsonPropertyName("default_locale")]
    public string? DefaultLocale { get; set; }

    /// <summary>Swagger 未显式建模的附加 JSON 字段</summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? ExtensionData { get; set; }
}
