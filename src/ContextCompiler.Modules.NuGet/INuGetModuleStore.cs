
using ContextCompiler.Modules.Abstractions.Configuration;

namespace ContextCompiler.Modules.NuGet
{
    public interface INuGetModuleStore
    {
        (bool isSigned, string? note) CheckSignedBestEffort(string nupkgPath);
        string ComputeAndVerifySha(string nupkgPath, string? expectedShaBase64);
        string ExtractToImmutableCache(string nupkgPath, string packageId, string version, string shaBase64);
        string? FindModuleAssembly(string extractedRoot);
        (string authors, string? repoUrl, List<ModuleLockFile.DependencyInfo> deps, List<string> files) ReadNuspecAndDeps(string nupkgPath);
        Task<string> RestoreAsync(ModulePackageRequest req, CancellationToken ct);
    }
}
