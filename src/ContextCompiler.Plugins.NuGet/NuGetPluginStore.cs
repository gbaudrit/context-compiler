using ContextCompiler.Plugins.Abstractions.Configuration;
using ContextCompiler.Plugins.Loader;

using Microsoft.Extensions.Logging;

using NuGet.Common;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;
namespace ContextCompiler.Plugins.NuGet;

public sealed class NuGetPluginStore(IPluginsLoadConfigProvider cfg, ILogger<NuGetPluginStore> logger) : INuGetPluginStore
{
    private readonly TrustPolicy _policy = new(cfg);

    public async Task<string> RestoreAsync(PluginPackageRequest req, CancellationToken ct)
    {
        PluginSource source = cfg.Current.Sources.Single(s => string.Equals(s.Name, req.Source, StringComparison.OrdinalIgnoreCase));
        _policy.ValidateSource(source); _policy.ValidatePackageId(req.Id);
        string installRootAbs = Path.GetFullPath(cfg.Current.InstallRoot); _ = Directory.CreateDirectory(installRootAbs);
        if (cfg.Current.Offline || string.Equals(cfg.Current.Mode, "Offline", StringComparison.OrdinalIgnoreCase))
        {
            string? cached = FindCachedNupkg(req.Id, req.Version);
            return cached is null
                ? throw new InvalidOperationException($"Offline mode: package not found in cache: {req.Id} {req.Version}")
                : cached;
        }
        SourceRepository repo = Repository.Factory.GetCoreV3(source.Url);
        FindPackageByIdResource resource = await repo.GetResourceAsync<FindPackageByIdResource>(ct);
        NuGetVersion version = NuGetVersion.Parse(req.Version);
        string nupkgPath = Path.Combine(installRootAbs, "_nupkg", req.Id, req.Version, $"{req.Id}.{req.Version}.nupkg");
        _ = Directory.CreateDirectory(Path.GetDirectoryName(nupkgPath)!);
        using SourceCacheContext cache = new();
        if (File.Exists(nupkgPath))
        {
            return nupkgPath;
        }

        await using FileStream fs = File.Create(nupkgPath);
        bool ok = await resource.CopyNupkgToStreamAsync(req.Id, version, fs, cache, NullLogger.Instance, ct);
        return !ok ? throw new InvalidOperationException($"Failed to download package: {req.Id} {req.Version}") : nupkgPath;
    }

    public string ComputeAndVerifySha(string nupkgPath, string? expectedShaBase64)
    {
        string sha = Integrity.ComputeSha256Base64(nupkgPath);
        return !string.IsNullOrWhiteSpace(expectedShaBase64) && !string.Equals(sha, expectedShaBase64, StringComparison.Ordinal)
            ? throw new InvalidOperationException("SHA256 mismatch for nupkg.")
            : sha;
    }

    public (string authors, string? repoUrl, List<PluginLockFile.DependencyInfo> deps, List<string> files) ReadNuspecAndDeps(string nupkgPath)
    {
        using PackageArchiveReader reader = new(nupkgPath);
        NuspecReader nuspec = reader.NuspecReader;
        string authors = nuspec.GetAuthors() ?? "";
        string? repo = nuspec.GetRepositoryMetadata()?.Url;
        List<PluginLockFile.DependencyInfo> deps = [];
        foreach (PackageDependencyGroup? g in nuspec.GetDependencyGroups())
        {
            foreach (PackageDependency? d in g.Packages)
            {
                logger.LogInformation("Found dependency: {Id} {VersionRange}", d.Id, d.VersionRange?.OriginalString);
                deps.Add(new PluginLockFile.DependencyInfo { Id = d.Id, Version = d.VersionRange?.OriginalString ?? "" });
            }
        }

        List<string> files = [.. reader.GetFiles()];
        return (authors, repo, deps, files);
    }

    public (bool isSigned, string? note) CheckSignedBestEffort(string nupkgPath)
    {
        using PackageArchiveReader reader = new(nupkgPath);
        bool hasSig = reader.GetFiles().Any(f => f.EndsWith(".signature.p7s", StringComparison.OrdinalIgnoreCase));
        return (hasSig, hasSig ? null : "No .signature.p7s found (best-effort check).");
    }

    public string ExtractToImmutableCache(string nupkgPath, string packageId, string version, string shaBase64)
    {
        string hashDir = shaBase64.Replace("/", "_").Replace("+", "-");
        string dest = Path.Combine(Path.GetFullPath(cfg.Current.InstallRoot), packageId, version, hashDir);
        if (Directory.Exists(dest))
        {
            return dest;
        }

        _ = Directory.CreateDirectory(dest);
        using PackageArchiveReader reader = new(nupkgPath);
        foreach (string? file in reader.GetFiles())
        {
            string outPath = Path.Combine(dest, file.Replace('/', Path.DirectorySeparatorChar));
            _ = Directory.CreateDirectory(Path.GetDirectoryName(outPath)!);
            using Stream inStream = reader.GetStream(file);
            using FileStream outStream = File.Create(outPath);
            inStream.CopyTo(outStream);
        }
        return dest;
    }
    public string? FindPluginAssembly(string extractedRoot)
    {
        string lib = Path.Combine(extractedRoot, "lib", "net10.0");
        if (Directory.Exists(lib))
        {
            string? dll = Directory.GetFiles(lib, "*.dll").FirstOrDefault();
            if (dll != null)
            {
                return dll;
            }
        }
        return Directory.GetFiles(extractedRoot, "*.dll", SearchOption.AllDirectories).FirstOrDefault();
    }
    private string? FindCachedNupkg(string packageId, string version)
    {
        string p = Path.Combine(Path.GetFullPath(cfg.Current.InstallRoot), "_nupkg", packageId, version, $"{packageId}.{version}.nupkg");
        return File.Exists(p) ? p : null;
    }
}
