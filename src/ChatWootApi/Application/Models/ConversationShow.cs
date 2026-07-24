using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：会话详情（会话字段 + meta）
/// </summary>
public sealed record ConversationShow : Conversation
{
    /// <summary>
    /// 会话元数据（发送者、渠道、负责人等）
    /// </summary>
    [JsonPropertyName("meta")]
    public ConversationListItemMeta? Meta { get; init; }
}
