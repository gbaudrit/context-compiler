using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Loader;

using Microsoft.Extensions.Logging;

using NuGet.Common;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace ContextCompiler.Modules.NuGet;

public sealed class NuGetModuleStore(IModulesLoadConfigProvider cfg,
                                     IModuleMetadatasBuilder moduleMetadatasBuilder,
                                     IModuleDependencyBuilder moduleDependencyBuilder,
                                     IModuleRestoreRequestResultBuilder resultBuilder,
                                     ITrustPolicy trustPolicy,
                                     ILogger<NuGetModuleStore> logger) : IModulesStore
{
    private readonly ITrustPolicy _policy = trustPolicy;

    public async Task<IModuleRestoreRequestResult> RestoreAsync(IModuleRestoreRequest req, CancellationToken ct)
    {
        ModuleSource source = cfg.Current.Sources.Single(s => string.Equals(s.Name, req.PackageId.Source.Id, StringComparison.OrdinalIgnoreCase));
        _policy.ValidateSource(source); _policy.ValidatePackageId(req.PackageId.Id);
        string installRootAbs = Path.GetFullPath(cfg.Current.InstallRoot); _ = Directory.CreateDirectory(installRootAbs);
        if (cfg.Current.Offline || string.Equals(cfg.Current.Mode, "Offline", StringComparison.OrdinalIgnoreCase))
        {
            string? cached = FindCachedNupkg(req.PackageId.Id,
                                             req.Version.Raw) ?? throw new InvalidOperationException($"Offline mode: package not found in cache: {req.PackageId.Id} {req.Version.Raw}");

            (string? authors, string? repoUrl, List<IModuleDependency>? deps, List<string>? files) = ReadNuspecAndDeps(cached);
            (bool isSigned, string? note) = CheckSignedBestEffort(cached);
            string extractedRoot = ExtractToImmutableCache(cached, req.PackageId.Id, req.Version.Raw, req.PackageId.Checksum);

            IModuleMetadatas metadatas = moduleMetadatasBuilder
                .InitNew()
                .WithAuthors(authors?.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries) ?? [])
                .WithRepositoryUrl(string.IsNullOrWhiteSpace(repoUrl) ? null : new Uri(repoUrl))
                .WithDependencies(deps ?? [])
                .WithFiles(files ?? [])
                .WithIsSigned(isSigned)
                .WithSignatureNote(note ?? "")
                .Build();

            return resultBuilder
                .InitNew()
                .WithSuccess(true)
                .WithRestoredPath(extractedRoot)
                .WithMetadatas(metadatas)
                .Build();
        }
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
                }
                else
                {
                    logger.LogWarning("Package exists at {Path} but checksum mismatch. Re-downloading.", nupkgPath);
                    File.Delete(nupkgPath);
                }
            }
            else
            {
                logger.LogWarning("Package already exists at {Path} but no checksum provided for verification. Skipping download.", nupkgPath);
            }
        }

        if (!File.Exists(nupkgPath))
        {
            await using FileStream fs = File.Create(nupkgPath);
            bool ok = await resource.CopyNupkgToStreamAsync(req.PackageId.Id, version, fs, cache, NullLogger.Instance, ct);

            if (!ok)
            {
                throw new InvalidOperationException($"Failed to download package: {req.PackageId.Id} {req.Version.Raw}");
            }
        }

        (string? authors2, string? repoUrl2, List<IModuleDependency>? deps2, List<string>? files2) = ReadNuspecAndDeps(nupkgPath);
        (bool isSigned2, string? note2) = CheckSignedBestEffort(nupkgPath);
        _policy.ValidateSignature(isSigned2, note2);
        string extractedRoot2 = ExtractToImmutableCache(nupkgPath, req.PackageId.Id, req.Version.Raw, req.PackageId.Checksum);

        IModuleMetadatas metadatas2 = moduleMetadatasBuilder
            .InitNew()
            .WithAuthors(authors2?.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries) ?? [])
            .WithRepositoryUrl(string.IsNullOrWhiteSpace(repoUrl2) ? null : new Uri(repoUrl2))
            .WithDependencies(deps2 ?? [])
            .WithFiles(files2 ?? [])
            .WithIsSigned(isSigned2)
            .WithSignatureNote(note2 ?? "")
            .Build();

        return resultBuilder
            .InitNew()
            .WithSuccess(true)
            .WithRestoredPath(extractedRoot2)
            .WithMetadatas(metadatas2)
            .Build();
    }


    private static bool VerifyChecksum(string nupkgPath, string? expectedShaBase64)
    {
        string sha = Integrity.ComputeSha256Base64(nupkgPath);
        return string.IsNullOrWhiteSpace(expectedShaBase64) || string.Equals(sha, expectedShaBase64, StringComparison.Ordinal);
    }

    private (string authors, string? repoUrl, List<IModuleDependency> deps, List<string> files) ReadNuspecAndDeps(string nupkgPath)
    {
        using PackageArchiveReader reader = new(nupkgPath);
        NuspecReader nuspec = reader.NuspecReader;
        string authors = nuspec.GetAuthors() ?? "";
        string? repo = nuspec.GetRepositoryMetadata()?.Url;
        List<IModuleDependency> deps = [];
        foreach (PackageDependencyGroup? g in nuspec.GetDependencyGroups())
        {
            foreach (PackageDependency? d in g.Packages)
            {
                logger.LogInformation("Found dependency: {Id} {VersionRange}", d.Id, d.VersionRange?.OriginalString);
                deps.Add(moduleDependencyBuilder.InitNew().WithId(d.Id).WithVersion(d.VersionRange?.OriginalString ?? "").Build());
            }
        }

        List<string> files = [.. reader.GetFiles()];
        return (authors, repo, deps, files);
    }

    private static (bool isSigned, string? note) CheckSignedBestEffort(string nupkgPath)
    {
        using PackageArchiveReader reader = new(nupkgPath);
        bool hasSig = reader.GetFiles().Any(f => f.EndsWith(".signature.p7s", StringComparison.OrdinalIgnoreCase));
        return (hasSig, hasSig ? null : "No .signature.p7s found (best-effort check).");
    }

    private string ExtractToImmutableCache(string nupkgPath, string packageId, string version, string shaBase64)
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

    private string? FindCachedNupkg(string packageId, string version)
    {
        string p = Path.Combine(Path.GetFullPath(cfg.Current.InstallRoot), "_nupkg", packageId, version, $"{packageId}.{version}.nupkg");
        return File.Exists(p) ? p : null;
    }
}
