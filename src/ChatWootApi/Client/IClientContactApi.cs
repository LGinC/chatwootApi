using Refit;

namespace ChatWootApi.Client;

public interface IClientContactApi
{
    [Post("/public/api/v1/inboxes/{inboxIdentifier}/contacts")]
    Task<Contact> CreateContactAsync(string inboxIdentifier, [Body] ContactCreateUpdatePayload payload, CancellationToken cancellationToken = default);

    [Get("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}")]
    Task<Contact> GetContactAsync(string inboxIdentifier, string contactIdentifier, CancellationToken cancellationToken = default);

    [Patch("/public/api/v1/inboxes/{inboxIdentifier}/contacts/{contactIdentifier}")]
    Task<ContactRecord> UpdateContactAsync(string inboxIdentifier, string contactIdentifier, [Body] ContactCreateUpdatePayload payload, CancellationToken cancellationToken = default);
}
