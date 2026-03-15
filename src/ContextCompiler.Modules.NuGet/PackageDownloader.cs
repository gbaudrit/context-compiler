using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Loader;

using Microsoft.Extensions.Logging;

using NuGet.Common;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace ContextCompiler.Modules.NuGet;

internal sealed class PackageDownloader(ILogger<PackageDownloader> logger) : IPackageDownloader
{
    public async Task<string> DownloadPackageAsync(IModuleRestoreRequest req, ModuleSource source, string installRootAbs, CancellationToken ct)
    {
        SourceRepository repo = Repository.Factory.GetCoreV3(source.Url);
        FindPackageByIdResource resource = await repo.GetResourceAsync<FindPackageByIdResource>(ct);
        NuGetVersion version = NuGetVersion.Parse(req.Version.Raw);
        string nupkgPath = Path.Combine(installRootAbs, "_nupkg", req.PackageId.Id, req.Version.Raw, $"{req.PackageId.Id}.{req.Version.Raw}.nupkg");

        _ = Directory.CreateDirectory(Path.GetDirectoryName(nupkgPath)!);

        using SourceCacheContext cache = new();

        if (File.Exists(nupkgPath))
        {
            if (!string.IsNullOrEmpty(req.PackageId.Checksum))
            {
                if (VerifyChecksum(nupkgPath, req.PackageId.Checksum))
                {
                    logger.LogInformation("Package already exists at {Path} with matching checksum {Sha}. Skipping download.", nupkgPath, req.PackageId.Checksum);
                    return nupkgPath;
                }

                logger.LogWarning("Package exists at {Path} but checksum mismatch. Re-downloading.", nupkgPath);
                File.Delete(nupkgPath);
            }
            else
            {
                logger.LogWarning("Package already exists at {Path} but no checksum provided for verification. Skipping download.", nupkgPath);
                return nupkgPath;
            }
        }

        await using FileStream fs = File.Create(nupkgPath);
        bool ok = await resource.CopyNupkgToStreamAsync(req.PackageId.Id, version, fs, cache, NullLogger.Instance, ct);

        return nupkgPath;
    }

    private static bool VerifyChecksum(string nupkgPath, string? expectedShaBase64)
    {
        string sha = Integrity.ComputeSha256Base64(nupkgPath);
        return string.IsNullOrWhiteSpace(expectedShaBase64) || string.Equals(sha, expectedShaBase64, StringComparison.Ordinal);
    }
}
