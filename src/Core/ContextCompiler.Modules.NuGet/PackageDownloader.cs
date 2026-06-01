using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Loading;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using NuGet.Common;
using NuGet.Frameworks;
using NuGet.Packaging.Core;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace ContextCompiler.Modules.NuGet;

internal sealed class PackageDownloader(IOptions<ModulesConfig> configOptions,
                                        IDependenciesChecker dependenciesChecker,
                                        IIntegrityChecker integrityChecker,
                                        ILogger<PackageDownloader> logger) : IPackageDownloader
{
    private readonly HashSet<string> _downloadedPackages = [];
    private readonly List<DownloadedPackageInfo> _allDownloadedPackages = [];

    public async Task<PackageDownloadResult> DownloadPackageAsync(IModuleRestoreRequest req, ModuleSource source, string installRootAbs, bool force, CancellationToken ct)
    {
        _downloadedPackages.Clear();
        _allDownloadedPackages.Clear();

        SourceRepository repo = Repository.Factory.GetCoreV3(source.Url);

        using SourceCacheContext cache = new();

        string mainPackagePath = await DownloadPackageWithDependenciesAsync(
            repo,
            source,
            req.PackageId.Id,
            req.Version.Raw,
            req.PackageId.Checksum,
            installRootAbs,
            cache,
            force,
            ct);

        return new PackageDownloadResult(mainPackagePath, _allDownloadedPackages);
    }

    private async Task<string> DownloadPackageWithDependenciesAsync(
        SourceRepository repo,
        ModuleSource source,
        string packageId,
        string versionString,
        string? checksum,
        string installRootAbs,
        SourceCacheContext cache,
        bool force,
        CancellationToken ct)
    {
        string packageKey = $"{packageId}.{versionString}";

        if (_downloadedPackages.Contains(packageKey))
        {
            string existingPath = Path.Combine(installRootAbs, "_nupkg", packageId, versionString, $"{packageId}.{versionString}.nupkg");
            logger.LogDebug("Package {PackageId} {Version} already processed. Skipping.", packageId, versionString);
            return existingPath;
        }

        FindPackageByIdResource resource = await repo.GetResourceAsync<FindPackageByIdResource>(ct);
        NuGetVersion version = NuGetVersion.Parse(versionString);
        string nupkgPath = Path.Combine(installRootAbs, "_nupkg", packageId, versionString, $"{packageId}.{versionString}.nupkg");

        _ = Directory.CreateDirectory(Path.GetDirectoryName(nupkgPath)!);

        if (File.Exists(nupkgPath))
        {
            if (!string.IsNullOrEmpty(checksum))
            {
                if (VerifyChecksum(nupkgPath, checksum))
                {
                    logger.LogInformation("Package already exists at {Path} with matching checksum {Sha}. Skipping download.", nupkgPath, checksum);
                    _ = _downloadedPackages.Add(packageKey);
                    _allDownloadedPackages.Add(new DownloadedPackageInfo(packageId, versionString, nupkgPath));
                    await DownloadDependenciesAsync(repo, source, packageId, version, installRootAbs, cache, force, ct);
                    return nupkgPath;
                }

                logger.LogWarning("Package exists at {Path} but checksum mismatch. Re-downloading.", nupkgPath);
                File.Delete(nupkgPath);
            }
            else
            {
                logger.LogWarning("Package already exists at {Path} but no checksum provided for verification. Skipping download.", nupkgPath);
                _ = _downloadedPackages.Add(packageKey);
                _allDownloadedPackages.Add(new DownloadedPackageInfo(packageId, versionString, nupkgPath));
                await DownloadDependenciesAsync(repo, source, packageId, version, installRootAbs, cache, force, ct);
                return nupkgPath;
            }
        }

        await using FileStream fs = File.Create(nupkgPath);
        bool ok = await resource.CopyNupkgToStreamAsync(packageId, version, fs, cache, NullLogger.Instance, ct);

        _ = _downloadedPackages.Add(packageKey);
        _allDownloadedPackages.Add(new DownloadedPackageInfo(packageId, versionString, nupkgPath));

        logger.LogInformation("Downloaded package {PackageId} {Version} to {Path}", packageId, versionString, nupkgPath);

        await DownloadDependenciesAsync(repo, source, packageId, version, installRootAbs, cache, force, ct);

        return nupkgPath;
    }

    private async Task DownloadDependenciesAsync(
        SourceRepository repo,
        ModuleSource currentSource,
        string packageId,
        NuGetVersion version,
        string installRootAbs,
        SourceCacheContext cache,
        bool force,
        CancellationToken ct)
    {
        try
        {
            DependencyInfoResource dependencyInfoResource = await repo.GetResourceAsync<DependencyInfoResource>(ct);

            NuGetFramework targetFramework = NuGetFramework.Parse("net10.0");

            SourcePackageDependencyInfo packageInfo = await dependencyInfoResource.ResolvePackage(
                new PackageIdentity(packageId, version),
                targetFramework,
                cache,
                NullLogger.Instance,
                ct);

            if (packageInfo == null)
            {
                logger.LogWarning("Could not resolve dependency information for {PackageId} {Version}", packageId, version);
                return;
            }

            if (!dependenciesChecker.IsRequired(packageId, version.ToFullString()))
            {
                logger.LogDebug("Skipping download of {PackageId} {Version} because it is a system package.", packageId, version.ToFullString());
                return;
            }

            foreach (PackageDependency dependency in packageInfo.Dependencies)
            {
                logger.LogInformation("Downloading dependency {DependencyId} (version range: {VersionRange}) for {PackageId}",
                    dependency.Id, dependency.VersionRange, packageId);

                await DownloadDependencyFromMultipleSourcesAsync(
                    currentSource,
                    dependency.Id,
                    dependency.VersionRange,
                    installRootAbs,
                    cache,
                    force,
                    ct);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error downloading dependencies for {PackageId} {Version}", packageId, version);
        }
    }

    private async Task DownloadDependencyFromMultipleSourcesAsync(
        ModuleSource preferredSource,
        string dependencyId,
        VersionRange versionRange,
        string installRootAbs,
        SourceCacheContext cache,
        bool force,
        CancellationToken ct)
    {
        if (!dependenciesChecker.IsRequired(dependencyId, versionRange.OriginalString ?? ""))
        {
            logger.LogDebug("Skipping download of {D} {Version} because it is a system package.", dependencyId, versionRange.OriginalString);
            return;
        }

        List<ModuleSource> allSources = configOptions.Value.Sources;

        // Essayer d'abord la source préférée (celle du package parent)
        List<ModuleSource> sourcesToTry = [preferredSource];

        // Ajouter les autres sources
        foreach (ModuleSource source in allSources)
        {
            if (!string.Equals(source.Name, preferredSource.Name, StringComparison.OrdinalIgnoreCase))
            {
                sourcesToTry.Add(source);
            }
        }

        Exception? lastException = null;

        foreach (ModuleSource source in sourcesToTry)
        {
            try
            {
                logger.LogDebug("Trying to download {DependencyId} from source {SourceName} ({SourceUrl})",
                    dependencyId, source.Name, source.Url);

                SourceRepository sourceRepo = Repository.Factory.GetCoreV3(source.Url);

                NuGetVersion? bestVersion = await FindBestVersionAsync(sourceRepo, dependencyId, versionRange, cache, ct);

                if (bestVersion != null)
                {
                    logger.LogInformation("Found {DependencyId} {Version} in source {SourceName}",
                        dependencyId, bestVersion, source.Name);

                    _ = await DownloadPackageWithDependenciesAsync(
                        sourceRepo,
                        source,
                        dependencyId,
                        bestVersion.ToString(),
                        null,
                        installRootAbs,
                        cache,
                        force,
                        ct);

                    return; // Succès, on sort
                }
                else
                {
                    logger.LogDebug("Dependency {DependencyId} not found in source {SourceName}",
                        dependencyId, source.Name);
                }
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, "Failed to download {DependencyId} from source {SourceName}: {Message}",
                    dependencyId, source.Name, ex.Message);
                lastException = ex;
            }
        }

        // Si on arrive ici, aucune source n'a fonctionné
        string sourcesAttempted = string.Join(", ", sourcesToTry.Select(s => s.Name));
        logger.LogError(lastException,
            "Could not download dependency {DependencyId} with version range {VersionRange} from any source. Tried: {Sources}",
            dependencyId, versionRange, sourcesAttempted);
    }

    private static async Task<NuGetVersion?> FindBestVersionAsync(
        SourceRepository repo,
        string packageId,
        VersionRange versionRange,
        SourceCacheContext cache,
        CancellationToken ct)
    {
        try
        {
            IEnumerable<NuGetVersion> allVersions = await GetAllVersionsAsync(repo, packageId, cache, ct);

            return !allVersions.Any() ? null : versionRange.MinVersion ?? versionRange.FindBestMatch(allVersions);
        }
        catch
        {
            return null;
        }
    }

    private static async Task<IEnumerable<NuGetVersion>> GetAllVersionsAsync(
        SourceRepository repo,
        string packageId,
        SourceCacheContext cache,
        CancellationToken ct)
    {
        FindPackageByIdResource resource = await repo.GetResourceAsync<FindPackageByIdResource>(ct);
        return await resource.GetAllVersionsAsync(packageId, cache, NullLogger.Instance, ct);
    }

    private bool VerifyChecksum(string nupkgPath, string? expectedShaBase64)
    {
        string sha = integrityChecker.ComputeSha256Base64(nupkgPath);
        return string.IsNullOrWhiteSpace(expectedShaBase64) || string.Equals(sha, expectedShaBase64, StringComparison.Ordinal);
    }
}
