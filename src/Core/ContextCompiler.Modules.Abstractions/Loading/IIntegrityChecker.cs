namespace ContextCompiler.Modules.Abstractions.Loading;

public interface IIntegrityChecker
{
    string ComputeSha256Base64(string filePath);
}
