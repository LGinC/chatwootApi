using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationHelpCenterApi
{
    [Post("/api/v1/accounts/{accountId}/portals")]
    Task<Portal> AddNewPortalToAccountAsync(long accountId, [Body] PortalCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Get("/api/v1/accounts/{accountId}/portals")]
    Task<Portal> GetPortalAsync(long accountId, CancellationToken cancellationToken = default);

    [Patch("/api/v1/accounts/{accountId}/portals/{id}")]
    Task<PortalSingle> UpdatePortalToAccountAsync(long accountId, long id, [Body] PortalCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/portals/{id}/categories")]
    Task<Category> AddNewCategoryToAccountAsync(long accountId, long id, [Body] CategoryCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/portals/{id}/articles")]
    Task<Article> AddNewArticleToAccountAsync(long accountId, long id, [Body] ArticleCreateUpdatePayload payload, CancellationToken cancellationToken = default);
}
