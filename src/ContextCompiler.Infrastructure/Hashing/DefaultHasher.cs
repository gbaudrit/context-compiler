using System.Security.Cryptography;
using System.Text;
using ContextCompiler.Abstractions.Ports;

namespace ContextCompiler.Infrastructure.Hashing;

public sealed class DefaultHasher : IHasher
{
    public string Sha256Hex(string input) => Sha256Hex(Encoding.UTF8.GetBytes(input));

    public string Sha256Hex(byte[] bytes)
    {
        var hash = SHA256.HashData(bytes);
        return Convert.ToHexString(hash).ToLowerInvariant();
    }

    public ulong SimHash64(string normalizedText)
    {
        var tokens = normalizedText.Split([' ', '\n', '\r', '\t'], StringSplitOptions.RemoveEmptyEntries);
        var v = new int[64];
        foreach (var t in tokens)
        {
            var h = SHA256.HashData(Encoding.UTF8.GetBytes(t));
            ulong u = BitConverter.ToUInt64(h, 0);
            for (int i=0;i<64;i++)
            {
                v[i] += ((u >> i) & 1UL) == 1UL ? 1 : -1;
            }
        }
        ulong outHash = 0;
        for (int i=0;i<64;i++)
            if (v[i] >= 0) outHash |= 1UL << i;
        return outHash;
    }
}
