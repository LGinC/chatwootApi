using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace ChatWootApi.Extensions;

/// <summary>
/// Logs Chatwoot HTTP requests and responses when enabled by <see cref="ChatWootApiOptions"/>.
/// </summary>
public sealed class HttpLoggingDelegatingHandler(
    string apiName,
    string? apiFullName,
    IOptionsMonitor<ChatWootApiOptions> options,
    ILogger logger) : DelegatingHandler
{
    private const int MaximumLoggedBodyLength = 16 * 1024;

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var currentOptions = options.CurrentValue;
        if (!currentOptions.IsLoggingEnabled(apiName, apiFullName))
        {
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        var stopwatch = Stopwatch.StartNew();
        var requestUri = SensitiveDataRedactor.RedactUri(request.RequestUri);
        var requestHeaders = SensitiveDataRedactor.FormatHeaders(request.Headers, request.Content?.Headers);
        var requestBody = currentOptions.IncludeBodyInLogs
            ? await ReadAndRedactBodyAsync(request.Content).ConfigureAwait(false)
            : "<omitted>";

        logger.LogInformation(
            "ChatWoot API request started. Api={ApiName}, Method={Method}, Uri={Uri}, Headers={Headers}, Body={Body}",
            apiName,
            request.Method.Method,
            requestUri,
            requestHeaders,
            requestBody);

        try
        {
            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            stopwatch.Stop();

            var responseHeaders = SensitiveDataRedactor.FormatHeaders(response.Headers, response.Content?.Headers);
            var responseBody = currentOptions.IncludeBodyInLogs
                ? await ReadAndRedactBodyAsync(response.Content).ConfigureAwait(false)
                : "<omitted>";

            logger.LogInformation(
                "ChatWoot API response received. Api={ApiName}, Method={Method}, Uri={Uri}, StatusCode={StatusCode}, ReasonPhrase={ReasonPhrase}, DurationMs={DurationMs}, Headers={Headers}, Body={Body}",
                apiName,
                request.Method.Method,
                requestUri,
                (int)response.StatusCode,
                response.ReasonPhrase ?? "<none>",
                stopwatch.Elapsed.TotalMilliseconds,
                responseHeaders,
                responseBody);

            return response;
        }
        catch (Exception exception)
        {
            stopwatch.Stop();

            logger.LogError(
                "ChatWoot API request failed. Api={ApiName}, Method={Method}, Uri={Uri}, DurationMs={DurationMs}, ExceptionType={ExceptionType}",
                apiName,
                request.Method.Method,
                requestUri,
                stopwatch.Elapsed.TotalMilliseconds,
                exception.GetType().Name);

            throw;
        }
    }

    private static async Task<string> ReadAndRedactBodyAsync(HttpContent? content)
    {
        if (content is null)
        {
            return "<none>";
        }

        if (content.Headers.ContentLength is > MaximumLoggedBodyLength)
        {
            return $"<omitted; content length exceeds {MaximumLoggedBodyLength} bytes>";
        }

        var mediaType = content.Headers.ContentType?.MediaType;
        if (!SensitiveDataRedactor.IsSupportedBodyMediaType(mediaType))
        {
            return $"<omitted; unsupported content type: {mediaType ?? "unknown"}>";
        }

        try
        {
            var body = await content.ReadAsStringAsync().ConfigureAwait(false);
            if (body.Length > MaximumLoggedBodyLength)
            {
                return $"<omitted; content length exceeds {MaximumLoggedBodyLength} characters>";
            }

            return SensitiveDataRedactor.RedactBody(body, mediaType);
        }
        catch (Exception)
        {
            return "<unavailable>";
        }
    }
}

internal static class SensitiveDataRedactor
{
    internal const string RedactedValue = "[REDACTED]";

    internal static string FormatHeaders(
        HttpHeaders headers,
        HttpContentHeaders? contentHeaders = null)
    {
        var formattedHeaders = new List<string>();
        AddHeaders(headers, formattedHeaders);

        if (contentHeaders is not null)
        {
            AddHeaders(contentHeaders, formattedHeaders);
        }

        return formattedHeaders.Count == 0
            ? "<none>"
            : string.Join("; ", formattedHeaders);
    }

    internal static string RedactUri(Uri? uri)
    {
        if (uri is null)
        {
            return "<none>";
        }

        try
        {
            var originalUri = uri.OriginalString;
            var queryStart = originalUri.IndexOf('?');
            if (queryStart < 0)
            {
                return originalUri;
            }

            var fragmentStart = originalUri.IndexOf('#', queryStart);
            var queryEnd = fragmentStart >= 0 ? fragmentStart : originalUri.Length;
            var query = originalUri[(queryStart + 1)..queryEnd];
            var parameters = query.Split('&', StringSplitOptions.None);

            for (var index = 0; index < parameters.Length; index++)
            {
                var parameter = parameters[index];
                var separatorIndex = parameter.IndexOf('=');
                var key = separatorIndex >= 0 ? parameter[..separatorIndex] : parameter;
                var decodedKey = Uri.UnescapeDataString(key.Replace('+', ' '));

                if (separatorIndex >= 0 && IsSensitiveName(decodedKey))
                {
                    parameters[index] = parameter[..(separatorIndex + 1)] + RedactedValue;
                }
            }

            return originalUri[..(queryStart + 1)] +
                string.Join('&', parameters) +
                originalUri[queryEnd..];
        }
        catch (UriFormatException)
        {
            return "<unavailable>";
        }
    }

    internal static bool IsSupportedBodyMediaType(string? mediaType)
    {
        return mediaType?.Equals("application/json", StringComparison.OrdinalIgnoreCase) == true ||
            mediaType?.EndsWith("+json", StringComparison.OrdinalIgnoreCase) == true ||
            mediaType?.Equals("application/x-www-form-urlencoded", StringComparison.OrdinalIgnoreCase) == true;
    }

    internal static string RedactBody(string body, string? mediaType)
    {
        if (mediaType?.Equals("application/x-www-form-urlencoded", StringComparison.OrdinalIgnoreCase) == true)
        {
            return RedactFormBody(body);
        }

        try
        {
            using var document = JsonDocument.Parse(body);
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                WriteRedactedJson(document.RootElement, writer);
            }

            return Encoding.UTF8.GetString(stream.ToArray());
        }
        catch (JsonException)
        {
            return "<omitted; invalid JSON>";
        }
    }

    private static void AddHeaders(HttpHeaders headers, ICollection<string> formattedHeaders)
    {
        foreach (var header in headers)
        {
            var value = IsSensitiveName(header.Key)
                ? RedactedValue
                : string.Join(", ", header.Value);

            formattedHeaders.Add($"{header.Key}={value}");
        }
    }

    private static string RedactFormBody(string body)
    {
        var parameters = body.Split('&', StringSplitOptions.None);
        for (var index = 0; index < parameters.Length; index++)
        {
            var parameter = parameters[index];
            var separatorIndex = parameter.IndexOf('=');
            if (separatorIndex < 0)
            {
                continue;
            }

            var key = parameter[..separatorIndex];
            var decodedKey = Uri.UnescapeDataString(key.Replace('+', ' '));
            if (IsSensitiveName(decodedKey))
            {
                parameters[index] = parameter[..(separatorIndex + 1)] + RedactedValue;
            }
        }

        return string.Join('&', parameters);
    }

    private static void WriteRedactedJson(JsonElement element, Utf8JsonWriter writer)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                writer.WriteStartObject();
                foreach (var property in element.EnumerateObject())
                {
                    writer.WritePropertyName(property.Name);
                    if (IsSensitiveName(property.Name))
                    {
                        writer.WriteStringValue(RedactedValue);
                    }
                    else
                    {
                        WriteRedactedJson(property.Value, writer);
                    }
                }

                writer.WriteEndObject();
                break;

            case JsonValueKind.Array:
                writer.WriteStartArray();
                foreach (var item in element.EnumerateArray())
                {
                    WriteRedactedJson(item, writer);
                }

                writer.WriteEndArray();
                break;

            default:
                element.WriteTo(writer);
                break;
        }
    }

    private static bool IsSensitiveName(string name)
    {
        var normalizedName = name.Replace("-", string.Empty, StringComparison.Ordinal)
            .Replace("_", string.Empty, StringComparison.Ordinal)
            .ToLowerInvariant();

        return normalizedName.Contains("authorization", StringComparison.Ordinal) ||
            normalizedName.Contains("cookie", StringComparison.Ordinal) ||
            normalizedName.Contains("password", StringComparison.Ordinal) ||
            normalizedName.Contains("secret", StringComparison.Ordinal) ||
            normalizedName.Contains("token", StringComparison.Ordinal) ||
            normalizedName.Contains("apikey", StringComparison.Ordinal) ||
            normalizedName.Contains("signature", StringComparison.Ordinal) ||
            normalizedName is "auth" or "email" or "key" or "phonenumber";
    }
}
