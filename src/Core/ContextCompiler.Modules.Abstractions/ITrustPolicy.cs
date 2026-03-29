using ContextCompiler.Modules.Abstractions.Configuration;

namespace ContextCompiler.Modules.Abstractions;

public interface ITrustPolicy
{
    void ValidateAuthorsAndRepositoryUrl(string authors, string? repoUrl);
    void ValidatePackageId(string packageId);
    void ValidateSignature(bool isSigned, string? note = null);
    void ValidateSource(ModuleSource source);
}
