using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：会话创建载荷。
/// </summary>
public sealed record ConversationCreatePayload : JsonExtensionDataPayload
{
    /// <summary>
    /// 对话源 ID
    /// </summary>
    [JsonPropertyName("source_id")]
    public string? SourceId { get; set; }

    /// <summary>
    /// 创建对话的收件箱 ID &lt;br/&gt; 允许的收件箱类型：网站、电话、Api、电子邮件
    /// </summary>
    [JsonPropertyName("inbox_id")]
    public long? InboxId { get; set; }

    /// <summary>
    /// 为其创建对话的联系人 ID
    /// </summary>
    [JsonPropertyName("contact_id")]
    public long? ContactId { get; set; }

    /// <summary>
    /// 允许您指定浏览器信息等属性
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>
    /// 保存对话自定义属性的对象，接受自定义属性键和值
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, object>? CustomAttributes { get; set; }

    /// <summary>
    /// 指定对话是否处于待处理、打开、关闭状态
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// 用于将对话分配给代理的代理 ID
    /// </summary>
    [JsonPropertyName("assignee_id")]
    public long? AssigneeId { get; set; }

    /// <summary>
    /// 用于将对话分配给团队的团队 ID\
    /// </summary>
    [JsonPropertyName("team_id")]
    public long? TeamId { get; set; }

    /// <summary>
    /// 推迟到日期时间
    /// </summary>
    [JsonPropertyName("snoozed_until")]
    public string? SnoozedUntil { get; set; }

    /// <summary>
    /// 要发送到对话的初始消息
    /// </summary>
    [JsonPropertyName("message")]
    public IDictionary<string, object>? Message { get; set; }
}
