using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;

namespace ContextCompiler.Modules.NuGet;

public interface IPackageDownloader
{
    Task<PackageDownloadResult> DownloadPackageAsync(IDeclaredModule req, ModuleSource source, string installRootAbs, bool force, CancellationToken ct);
}

public record PackageDownloadResult(string MainPackagePath, string ResolvedVersion, List<DownloadedPackageInfo> AllPackages);

public record DownloadedPackageInfo(string PackageId, string Version, string NupkgPath);
