using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace ChatWootApi.Application;

/// <summary>
/// Chatwoot webhook 签名校验辅助方法
/// </summary>
public static class ChatwootWebhookSignatureHelper
{
    private const string SignaturePrefix = "sha256=";
    private static readonly TimeSpan DefaultTimestampTolerance = TimeSpan.FromMinutes(5);

    /// <summary>
    /// 校验 Chatwoot webhook 请求签名是否匹配原始请求体
    /// </summary>
    /// <param name="receivedSignature">来自 <c>X-Chatwoot-Signature</c> 请求头的签名</param>
    /// <param name="timestamp">来自 <c>X-Chatwoot-Timestamp</c> 请求头的 Unix 秒级时间戳</param>
    /// <param name="rawBody">原始 JSON 请求体字节</param>
    /// <param name="secret">Chatwoot webhook secret</param>
    /// <param name="now">用于校验重放窗口的当前时间</param>
    /// <param name="timestampTolerance">允许的时间戳偏差；未指定时为 5 分钟</param>
    /// <returns>签名、时间戳和原始请求体均有效时返回 <see langword="true"/></returns>
    public static bool VerifySignature(
        string? receivedSignature,
        string? timestamp,
        ReadOnlySpan<byte> rawBody,
        string secret,
        DateTimeOffset now,
        TimeSpan? timestampTolerance = null)
    {
        if (string.IsNullOrWhiteSpace(receivedSignature) ||
            string.IsNullOrWhiteSpace(timestamp) ||
            string.IsNullOrEmpty(secret))
        {
            return false;
        }

        if (!IsWellFormedSha256Signature(receivedSignature))
        {
            return false;
        }

        if (!long.TryParse(timestamp, NumberStyles.None, CultureInfo.InvariantCulture, out var unixSeconds))
        {
            return false;
        }

        DateTimeOffset signedAt;
        try
        {
            signedAt = DateTimeOffset.FromUnixTimeSeconds(unixSeconds);
        }
        catch (ArgumentOutOfRangeException)
        {
            return false;
        }
        var tolerance = timestampTolerance ?? DefaultTimestampTolerance;
        if ((now - signedAt).Duration() > tolerance)
        {
            return false;
        }

        var expectedSignature = ComputeSignature(timestamp, rawBody, secret);
        return CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(expectedSignature),
            Encoding.UTF8.GetBytes(receivedSignature));
    }

    private static string ComputeSignature(string timestamp, ReadOnlySpan<byte> rawBody, string secret)
    {
        var secretBytes = Encoding.UTF8.GetBytes(secret);
        var timestampBytes = Encoding.UTF8.GetBytes(timestamp);
        Span<byte> hash = stackalloc byte[32];

        using var hmac = IncrementalHash.CreateHMAC(HashAlgorithmName.SHA256, secretBytes);
        hmac.AppendData(timestampBytes);
        hmac.AppendData("."u8);
        hmac.AppendData(rawBody);
        hmac.GetHashAndReset(hash);

        return SignaturePrefix + Convert.ToHexString(hash).ToLowerInvariant();
    }

    private static bool IsWellFormedSha256Signature(string signature)
    {
        if (!signature.StartsWith(SignaturePrefix, StringComparison.Ordinal) ||
            signature.Length != SignaturePrefix.Length + 64)
        {
            return false;
        }

        for (var i = SignaturePrefix.Length; i < signature.Length; i++)
        {
            var character = signature[i];
            var isHex = character is >= '0' and <= '9' or >= 'a' and <= 'f' or >= 'A' and <= 'F';
            if (!isHex)
            {
                return false;
            }
        }

        return true;
    }
}
