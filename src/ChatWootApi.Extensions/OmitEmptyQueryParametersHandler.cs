using System.Text;

namespace ChatWootApi.Extensions;

/// <summary>
/// Removes query parameters whose values are empty (e.g. <c>team_id=</c>).
/// Refit path templates substitute null optional parameters as empty strings;
/// Chatwoot treats those empty values as real filters and can return 404.
/// </summary>
public sealed class OmitEmptyQueryParametersHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        OmitEmptyQueryParameters(request);
        return base.SendAsync(request, cancellationToken);
    }

    internal static void OmitEmptyQueryParameters(HttpRequestMessage request)
    {
        var uri = request.RequestUri;
        if (uri is null)
        {
            return;
        }

        var original = uri.IsAbsoluteUri ? uri.PathAndQuery : uri.OriginalString;
        var queryStart = original.IndexOf('?');
        if (queryStart < 0 || queryStart == original.Length - 1)
        {
            return;
        }

        var path = original[..queryStart];
        var query = original[(queryStart + 1)..];
        var rebuilt = RebuildQueryWithoutEmptyValues(query);
        if (rebuilt is null)
        {
            return;
        }

        var pathAndQuery = rebuilt.Length == 0 ? path : $"{path}?{rebuilt}";
        if (uri.IsAbsoluteUri)
        {
            request.RequestUri = new Uri(uri.GetLeftPart(UriPartial.Path) + (rebuilt.Length == 0 ? string.Empty : "?" + rebuilt));
            return;
        }

        request.RequestUri = new Uri(pathAndQuery, UriKind.Relative);
    }

    /// <summary>
    /// Returns rebuilt query without leading <c>?</c>, or <see langword="null"/> when nothing changed.
    /// </summary>
    private static string? RebuildQueryWithoutEmptyValues(string query)
    {
        var changed = false;
        StringBuilder? builder = null;
        var start = 0;

        while (start <= query.Length)
        {
            var amp = query.IndexOf('&', start);
            var end = amp < 0 ? query.Length : amp;
            var length = end - start;

            if (length > 0)
            {
                var segment = query.AsSpan(start, length);
                var eq = segment.IndexOf('=');
                var omit = eq >= 0 && eq == segment.Length - 1;

                if (omit)
                {
                    changed = true;
                }
                else
                {
                    builder ??= new StringBuilder(query.Length);
                    if (builder.Length > 0)
                    {
                        builder.Append('&');
                    }

                    builder.Append(segment);
                }
            }

            if (amp < 0)
            {
                break;
            }

            start = amp + 1;
        }

        if (!changed)
        {
            return null;
        }

        return builder?.ToString() ?? string.Empty;
    }
}
