using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>Chatwoot 应用模型：带收件箱列表的响应</summary>
public sealed record InboxesListResponse
{
    /// <summary>收件箱列表</summary>
    [JsonPropertyName("payload")] public IReadOnlyList<Inbox> Payload { get; init; } = [];
}

/// <summary>Chatwoot 应用模型：带集成应用列表的响应</summary>
public sealed record IntegrationsAppsResponse
{
    /// <summary>集成应用列表</summary>
    [JsonPropertyName("payload")] public IReadOnlyList<IntegrationsApp> Payload { get; init; } = [];
}

/// <summary>Chatwoot 应用模型：带标签列表的响应</summary>
public sealed record LabelsListResponse
{
    /// <summary>标签列表</summary>
    [JsonPropertyName("payload")] public IReadOnlyList<Label> Payload { get; init; } = [];
}

/// <summary>Chatwoot 应用模型：账户会话指标</summary>
public sealed record AccountConversationMetrics
{
    /// <summary>打开会话数</summary>
    [JsonPropertyName("open")] public long? Open { get; init; }
    /// <summary>未处理会话数</summary>
    [JsonPropertyName("unattended")] public long? Unattended { get; init; }
    /// <summary>未分配会话数</summary>
    [JsonPropertyName("unassigned")] public long? Unassigned { get; init; }
}

/// <summary>Chatwoot 应用模型：审计日志分页响应</summary>
public sealed record AuditLogsResponse
{
    /// <summary>每页条目数</summary>
    [JsonPropertyName("per_page")] public long? PerPage { get; init; }
    /// <summary>审计日志总数</summary>
    [JsonPropertyName("total_entries")] public long? TotalEntries { get; init; }
    /// <summary>当前页码</summary>
    [JsonPropertyName("current_page")] public long? CurrentPage { get; init; }
    /// <summary>审计日志列表</summary>
    [JsonPropertyName("audit_logs")] public IReadOnlyList<AuditLog> AuditLogs { get; init; } = [];
}

/// <summary>Chatwoot 应用模型：会话列表计数响应</summary>
public sealed record ConversationListMetaResponse
{
    /// <summary>会话计数元数据</summary>
    [JsonPropertyName("meta")] public ConversationListMeta Meta { get; init; } = new();
}

/// <summary>Chatwoot 应用模型：会话列表计数元数据</summary>
public sealed record ConversationListMeta
{
    /// <summary>当前用户负责的会话数</summary>
    [JsonPropertyName("mine_count")] public long? MineCount { get; init; }
    /// <summary>未分配会话数</summary>
    [JsonPropertyName("unassigned_count")] public long? UnassignedCount { get; init; }
    /// <summary>已分配会话数</summary>
    [JsonPropertyName("assigned_count")] public long? AssignedCount { get; init; }
    /// <summary>全部会话数</summary>
    [JsonPropertyName("all_count")] public long? AllCount { get; init; }
}

/// <summary>Chatwoot 应用模型：新建会话响应</summary>
public sealed record ConversationCreateResponse
{
    /// <summary>会话 ID</summary>
    [JsonPropertyName("id")] public long? Id { get; init; }
    /// <summary>账户 ID</summary>
    [JsonPropertyName("account_id")] public long? AccountId { get; init; }
    /// <summary>收件箱 ID</summary>
    [JsonPropertyName("inbox_id")] public long? InboxId { get; init; }
}

/// <summary>Chatwoot 应用模型：会话状态更新响应</summary>
public sealed record ConversationStatusUpdateResponse
{
    /// <summary>响应元数据</summary>
    [JsonPropertyName("meta")] public IDictionary<string, JsonElement>? Meta { get; init; }
    /// <summary>状态更新结果</summary>
    [JsonPropertyName("payload")] public ConversationStatusUpdateResult? Payload { get; init; }
}

/// <summary>Chatwoot 应用模型：会话状态更新结果</summary>
public sealed record ConversationStatusUpdateResult
{
    /// <summary>操作是否成功</summary>
    [JsonPropertyName("success")] public bool? Success { get; init; }
    /// <summary>当前会话状态</summary>
    [JsonPropertyName("current_status")] [JsonConverter(typeof(ChatWootStringEnumConverter<ConversationStatus>))] public ConversationStatus? CurrentStatus { get; init; }
    /// <summary>会话 ID</summary>
    [JsonPropertyName("conversation_id")] public long? ConversationId { get; init; }
}

/// <summary>Chatwoot 应用模型：会话自定义属性更新响应</summary>
public sealed record ConversationCustomAttributesResponse
{
    /// <summary>会话自定义属性</summary>
    [JsonPropertyName("custom_attributes")] public IDictionary<string, JsonElement> CustomAttributes { get; init; } = new Dictionary<string, JsonElement>();
}

/// <summary>Chatwoot 应用模型：按日期统计的会话指标</summary>
public sealed record ConversationStatistic
{
    /// <summary>指标值</summary>
    [JsonPropertyName("value")] public string? Value { get; init; }
    /// <summary>统计时间戳</summary>
    [JsonPropertyName("timestamp")] public long? Timestamp { get; init; }
}
