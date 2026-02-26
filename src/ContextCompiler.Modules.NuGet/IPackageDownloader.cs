using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;

namespace ContextCompiler.Modules.NuGet;

public interface IPackageDownloader
{
    Task<string> DownloadPackageAsync(IModuleRestoreRequest req, ModuleSource source, string installRootAbs, CancellationToken ct);
}
