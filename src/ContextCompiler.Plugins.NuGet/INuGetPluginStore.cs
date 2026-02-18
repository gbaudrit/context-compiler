
using ContextCompiler.Plugins.Abstractions.Configuration;

namespace ContextCompiler.Plugins.NuGet
{
    public interface INuGetPluginStore
    {
        (bool isSigned, string? note) CheckSignedBestEffort(string nupkgPath);
        string ComputeAndVerifySha(string nupkgPath, string? expectedShaBase64);
        string ExtractToImmutableCache(string nupkgPath, string packageId, string version, string shaBase64);
        string? FindPluginAssembly(string extractedRoot);
        (string authors, string? repoUrl, List<PluginLockFile.DependencyInfo> deps, List<string> files) ReadNuspecAndDeps(string nupkgPath);
        Task<string> RestoreAsync(PluginPackageRequest req, CancellationToken ct);
    }
}
