using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationAuditLogsApi
{
    [Get("/api/v1/accounts/{accountId}/audit_logs")]
    Task<JsonElement> GetAccountAuditLogsAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);
}
