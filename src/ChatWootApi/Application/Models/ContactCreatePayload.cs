using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatWootApi.Application.Models;

/// <summary>
/// Chatwoot 应用模型：联系人创建载荷。
/// </summary>
public sealed record ContactCreatePayload : JsonExtensionDataPayload
{
    /// <summary>
    /// 联系人所属收件箱ID
    /// </summary>
    [JsonPropertyName("inbox_id")]
    public long? InboxId { get; set; }

    /// <summary>
    /// 联系人姓名
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 联系人的电子邮件
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// 联系人是否被屏蔽
    /// </summary>
    [JsonPropertyName("blocked")]
    public bool? Blocked { get; set; }

    /// <summary>
    /// 联系人的电话号码
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// 使用头像图像二进制文件发送表单数据或使用 avatar_url
    /// </summary>
    [JsonPropertyName("avatar")]
    public string? Avatar { get; set; }

    /// <summary>
    /// 联系人头像的 jpeg、png 文件的 url
    /// </summary>
    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; set; }

    /// <summary>
    /// 联系人在外部系统中的唯一标识符
    /// </summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    /// <summary>
    /// 您可以在其中存储联系人的附加属性的对象。示例{“类型”：“客户”，“年龄”：30}
    /// </summary>
    [JsonPropertyName("additional_attributes")]
    public IDictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>
    /// 您可以在其中存储联系人的自定义属性的对象。例如 {"type":"customer", "age":30}，这应该具有有效的自定义属性定义。
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IDictionary<string, object>? CustomAttributes { get; set; }
}
