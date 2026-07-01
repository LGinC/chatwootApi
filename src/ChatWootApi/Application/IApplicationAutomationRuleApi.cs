using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationAutomationRuleApi
{
    [Get("/api/v1/accounts/{accountId}/automation_rules")]
    Task<AutomationRule> GetAccountAutomationRuleAsync(long accountId, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/automation_rules")]
    Task<AutomationRule> AddNewAutomationRuleToAccountAsync(long accountId, [Body] AutomationRuleCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Get("/api/v1/accounts/{accountId}/automation_rules/{id}")]
    Task<AutomationRule> GetDetailsOfASingleAutomationRuleAsync(long accountId, long id, CancellationToken cancellationToken = default);

    [Patch("/api/v1/accounts/{accountId}/automation_rules/{id}")]
    Task<AutomationRule> UpdateAutomationRuleInAccountAsync(long accountId, long id, [Body] AutomationRuleCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Delete("/api/v1/accounts/{accountId}/automation_rules/{id}")]
    Task DeleteAutomationRuleFromAccountAsync(long accountId, long id, CancellationToken cancellationToken = default);
}
