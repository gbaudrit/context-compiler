using System.Security.Cryptography;

using ContextCompiler.Modules.Abstractions.Loading;
namespace ContextCompiler.Modules.Loader;

public class IntegrityChecker : IIntegrityChecker
{
    public string ComputeSha256Base64(string filePath)
    {
        using SHA256 sha = SHA256.Create();
        using FileStream fs = File.OpenRead(filePath);
        return Convert.ToBase64String(sha.ComputeHash(fs));
    }
}
