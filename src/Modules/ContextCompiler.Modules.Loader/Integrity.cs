using System.Security.Cryptography;
namespace ContextCompiler.Modules.Loader;

public static class Integrity
{
    public static string ComputeSha256Base64(string filePath)
    {
        using SHA256 sha = SHA256.Create();
        using FileStream fs = File.OpenRead(filePath);
        return Convert.ToBase64String(sha.ComputeHash(fs));
    }
}
