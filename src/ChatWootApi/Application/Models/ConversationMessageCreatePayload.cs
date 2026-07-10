using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：会话消息创建载荷。
/// </summary>
public sealed record ConversationMessageCreatePayload : JsonExtensionDataPayload
{
    /// <summary>
    /// 消息内容
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    /// <summary>
    /// 消息类型
    /// </summary>
    [JsonPropertyName("message_type")]
    public string? MessageType { get; set; }

    /// <summary>
    /// 标记以识别它是否是私人笔记
    /// </summary>
    [JsonPropertyName("private")]
    public bool? Private { get; set; }

    /// <summary>
    /// 消息的内容类型
    /// </summary>
    [JsonPropertyName("content_type")]
    public string? ContentType { get; set; }

    /// <summary>
    /// 基于内容类型的属性
    /// </summary>
    [JsonPropertyName("content_attributes")]
    public IDictionary<string, object>? ContentAttributes { get; set; }

    /// <summary>
    /// 消息所属的活动 ID
    /// </summary>
    [JsonPropertyName("campaign_id")]
    public long? CampaignId { get; set; }

    /// <summary>
    /// 用于发送结构化消息的 WhatsApp 模板参数
    /// </summary>
    [JsonPropertyName("template_params")]
    public IDictionary<string, object>? TemplateParams { get; set; }
}
