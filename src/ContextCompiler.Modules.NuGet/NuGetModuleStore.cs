using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;

using Microsoft.Extensions.Logging;

using NuGet.Packaging;

namespace ContextCompiler.Modules.NuGet;

public sealed class NuGetModuleStore(IModulesLoadConfigProvider cfg,
                                     IModuleMetadatasBuilder moduleMetadatasBuilder,
                                     IModuleRestoreRequestResultBuilder resultBuilder,
                                     ITrustPolicy trustPolicy,
                                     IPackageDownloader packageDownloader,
                                     INuGetMetadatasExtractor metadatasExtractor,
                                     ILogger<NuGetModuleStore> logger) : IModulesStore
{
    private readonly ITrustPolicy _policy = trustPolicy;

    public async Task<IModuleRestoreRequestResult> RestoreAsync(IModuleRestoreRequest req, CancellationToken ct)
    {
        ModuleSource source = cfg.Current.Sources.Single(s => string.Equals(s.Name, req.PackageId.Source.Id, StringComparison.OrdinalIgnoreCase));
        _policy.ValidateSource(source);
        _policy.ValidatePackageId(req.PackageId.Id);

        string installRootAbs = Path.GetFullPath(cfg.Current.InstallRoot);
        _ = Directory.CreateDirectory(installRootAbs);

        string nupkgPath = cfg.Current.Offline || string.Equals(cfg.Current.Mode, "Offline", StringComparison.OrdinalIgnoreCase)
            ? FindCachedNupkg(req.PackageId.Id, req.Version.Raw)
                ?? throw new InvalidOperationException($"Offline mode: package not found in cache: {req.PackageId.Id} {req.Version.Raw}")
            : await packageDownloader.DownloadPackageAsync(req, source, installRootAbs, ct);
        return BuildRestoreResult(nupkgPath, req.PackageId.Id, req.Version.Raw, req.PackageId.Checksum, validateSignature: !cfg.Current.Offline);
    }

    private IModuleRestoreRequestResult BuildRestoreResult(string nupkgPath, string packageId, string version, string checksum, bool validateSignature)
    {
        NuGetPackageMetadata packageMetadata = metadatasExtractor.ExtractMetadatas(nupkgPath);
        (bool isSigned, string? note) = CheckSignedBestEffort(nupkgPath);

        if (validateSignature)
        {
            _policy.ValidateSignature(isSigned, note);
        }

        string extractedRoot = ExtractToImmutableCache(nupkgPath, packageId, version, checksum);

        IModuleMetadatas metadatas = moduleMetadatasBuilder
            .InitNew()
            .WithAuthors(packageMetadata.Authors.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            .WithRepositoryUrl(string.IsNullOrWhiteSpace(packageMetadata.RepositoryUrl) ? null : new Uri(packageMetadata.RepositoryUrl))
            .WithDependencies(packageMetadata.Dependencies)
            .WithFiles(packageMetadata.Files)
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

    private static (bool isSigned, string? note) CheckSignedBestEffort(string nupkgPath)
    {
        using PackageArchiveReader reader = new(nupkgPath);
        bool hasSig = reader.GetFiles().Any(f => f.EndsWith(".signature.p7s", StringComparison.OrdinalIgnoreCase));
        return (hasSig, hasSig ? null : "No .signature.p7s found (best-effort check).");
    }

    private string ExtractToImmutableCache(string nupkgPath, string packageId, string version, string shaBase64)
    {
        string hashDir = shaBase64.Replace("/", "_").Replace("+", "-");
        string packageDir = Path.Combine(Path.GetFullPath(cfg.Current.InstallRoot), packageId);

        string dest = Path.Combine(packageDir, version, hashDir);
        if (Directory.Exists(dest))
        {
            //Already the good version, no need to extract again
            return dest;
        }

        if (Directory.Exists(packageDir))
        {
            // Another version exists, remove it
            Directory.Delete(packageDir, true);
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
