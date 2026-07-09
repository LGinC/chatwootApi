using Refit;
using ChatWootApi.Application.Models;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot 应用 API：应用会话分配API
/// </summary>
public interface IApplicationConversationAssignmentsApi
{
    /// <summary>
    /// 调用 Chatwoot 应用 API：Assign会话
    /// </summary>
    /// <param name="accountId">账号 ID</param>
    /// <param name="conversationId">会话 ID</param>
    /// <param name="payload">请求载荷</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>用户信息</returns>
    [Post("/api/v1/accounts/{accountId}/conversations/{conversationId}/assignments")]
    Task<User> AssignAConversationAsync(long accountId, long conversationId, [Body] ConversationAssignmentPayload payload, CancellationToken cancellationToken = default);
}