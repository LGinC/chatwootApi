using System.Text.Json;
using Refit;

namespace ChatWootApi.Application;

public interface IApplicationContactsApi
{
    [Get("/api/v1/accounts/{accountId}/contacts")]
    Task<ContactsListResponse> ContactListAsync(long accountId, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/contacts")]
    Task<ExtendedContact> ContactCreateAsync(long accountId, [Body] ContactCreatePayload payload, CancellationToken cancellationToken = default);

    [Get("/api/v1/accounts/{accountId}/contacts/{id}")]
    Task<ContactShowResponse> ContactDetailsAsync(long accountId, long id, CancellationToken cancellationToken = default);

    [Put("/api/v1/accounts/{accountId}/contacts/{id}")]
    Task ContactUpdateAsync(long accountId, long id, [Body] ContactUpdatePayload payload, CancellationToken cancellationToken = default);

    [Delete("/api/v1/accounts/{accountId}/contacts/{id}")]
    Task ContactDeleteAsync(long accountId, long id, CancellationToken cancellationToken = default);

    [Get("/api/v1/accounts/{accountId}/contacts/{id}/conversations")]
    Task<ContactConversationsResponse> ContactConversationsAsync(long accountId, long id, CancellationToken cancellationToken = default);

    [Get("/api/v1/accounts/{accountId}/contacts/search")]
    Task<ContactsListResponse> ContactSearchAsync(long accountId, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/contacts/filter")]
    Task<ContactsListResponse> ContactFilterAsync(long accountId, [Body] JsonElement payload, [Query] IDictionary<string, object?>? query = null, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/contacts/{id}/contact_inboxes")]
    Task<ContactInboxes> ContactInboxCreationAsync(long accountId, long id, [Body] JsonElement payload, CancellationToken cancellationToken = default);

    [Get("/api/v1/accounts/{accountId}/contacts/{id}/contactable_inboxes")]
    Task<ContactableInboxesResponse> ContactableInboxesGetAsync(long accountId, long id, CancellationToken cancellationToken = default);

    [Post("/api/v1/accounts/{accountId}/actions/contact_merge")]
    Task<ContactBase> ContactMergeAsync(long accountId, [Body] JsonElement payload, CancellationToken cancellationToken = default);
}
