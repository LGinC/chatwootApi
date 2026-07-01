using Refit;

namespace ChatWootApi.Client;

public interface IClientInboxApi
{
    [Get("/public/api/v1/inboxes/{inboxIdentifier}")]
    Task<Inbox> GetInboxAsync(string inboxIdentifier, CancellationToken cancellationToken = default);
}
