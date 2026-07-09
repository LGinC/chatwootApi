using System.Net.Http;
using Refit;

namespace ChatWootApi.Other;

/// <summary>
/// Chatwoot 其他 API 中的 CSAT 调查页面接口
/// </summary>
public interface IOtherCsatSurveyPageApi
{
    /// <summary>
    /// 获取可直接重定向给客户的 CSAT 调查页面响应
    /// </summary>
    /// <param name="conversationUuid">会话 UUIDChatwoot OpenAPI 当前将该路径参数声明为整数</param>
    /// <param name="cancellationToken">用于取消异步操作的令牌</param>
    /// <returns>CSAT 调查页面的 HTTP 响应</returns>
    [Get("/survey/responses/{conversation_uuid}")]
    Task<HttpResponseMessage> GetCsatSurveyPageAsync([AliasAs("conversation_uuid")] long conversationUuid, CancellationToken cancellationToken = default);
}
