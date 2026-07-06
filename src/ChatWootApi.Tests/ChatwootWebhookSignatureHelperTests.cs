using ChatWootApi.Application;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace ChatWootApi.Tests;

public sealed class ChatwootWebhookSignatureHelperTests
{
    private static readonly DateTimeOffset Now = DateTimeOffset.FromUnixTimeSeconds(1_700_000_000);
    private static readonly TimeSpan Tolerance = TimeSpan.FromMinutes(5);

    [Fact]
    public void VerifySignatureReturnsTrueForMatchingTimestampAndRawBodyHmac()
    {
        var timestamp = Now.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);
        var rawBody = Encoding.UTF8.GetBytes("{\"event\":\"message_created\",\"content\":\"hello 世界\"}");
        var signature = CreateSignature(timestamp, rawBody);

        var verified = ChatwootWebhookSignatureHelper.VerifySignature(
            signature,
            timestamp,
            rawBody,
            Secret,
            Now,
            Tolerance);

        Assert.True(verified);
    }

    [Fact]
    public void VerifySignatureReturnsFalseWhenRawBodyBytesDoNotMatchSignature()
    {
        var timestamp = Now.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);
        var signedBody = Encoding.UTF8.GetBytes("{\"event\":\"message_created\",\"content\":\"approved\"}");
        var tamperedBody = Encoding.UTF8.GetBytes("{\"event\":\"message_created\",\"content\":\"denied\"}");
        var signature = CreateSignature(timestamp, signedBody);

        var verified = ChatwootWebhookSignatureHelper.VerifySignature(
            signature,
            timestamp,
            tamperedBody,
            Secret,
            Now,
            Tolerance);

        Assert.False(verified);
    }

    [Fact]
    public void VerifySignatureReturnsFalseWhenTimestampIsOlderThanTolerance()
    {
        var timestamp = Now.Subtract(Tolerance).AddSeconds(-1).ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);
        var rawBody = Encoding.UTF8.GetBytes("{\"event\":\"conversation_updated\"}");
        var signature = CreateSignature(timestamp, rawBody);

        var verified = ChatwootWebhookSignatureHelper.VerifySignature(
            signature,
            timestamp,
            rawBody,
            Secret,
            Now,
            Tolerance);

        Assert.False(verified);
    }

    [Theory]
    [MemberData(nameof(MalformedSignatureOrTimestampCases))]
    public void VerifySignatureReturnsFalseForMalformedSignatureOrTimestamp(string? receivedSignature, string? timestamp)
    {
        var rawBody = Encoding.UTF8.GetBytes("{\"event\":\"message_created\"}");

        var verified = ChatwootWebhookSignatureHelper.VerifySignature(
            receivedSignature,
            timestamp,
            rawBody,
            Secret,
            Now,
            Tolerance);

        Assert.False(verified);
    }

    [Fact]
    public void VerifySignatureReturnsFalseWhenTimestampIsFartherInFutureThanTolerance()
    {
        var timestamp = Now.Add(Tolerance).AddSeconds(1).ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);
        var rawBody = Encoding.UTF8.GetBytes("{\"event\":\"conversation_created\"}");
        var signature = CreateSignature(timestamp, rawBody);

        var verified = ChatwootWebhookSignatureHelper.VerifySignature(
            signature,
            timestamp,
            rawBody,
            Secret,
            Now,
            Tolerance);

        Assert.False(verified);
    }

    public static TheoryData<string?, string?> MalformedSignatureOrTimestampCases()
    {
        var timestamp = Now.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);
        var signature = CreateSignature(timestamp, Encoding.UTF8.GetBytes("{\"event\":\"message_created\"}"));

        return new TheoryData<string?, string?>
        {
            { null, timestamp },
            { string.Empty, timestamp },
            { "sha1=4f6d", timestamp },
            { "sha256=not-hex", timestamp },
            { "sha256=", timestamp },
            { signature, null },
            { signature, string.Empty },
            { signature, "not-a-unix-timestamp" },
            { signature, "1700000000.5" },
        };
    }

    private const string Secret = "whsec_test_secret";

    private static string CreateSignature(string timestamp, byte[] rawBody)
    {
        var timestampBytes = Encoding.UTF8.GetBytes(timestamp);
        var message = new byte[timestampBytes.Length + 1 + rawBody.Length];
        Buffer.BlockCopy(timestampBytes, 0, message, 0, timestampBytes.Length);
        message[timestampBytes.Length] = (byte)'.';
        Buffer.BlockCopy(rawBody, 0, message, timestampBytes.Length + 1, rawBody.Length);

        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(Secret));
        return "sha256=" + Convert.ToHexString(hmac.ComputeHash(message)).ToLowerInvariant();
    }
}
