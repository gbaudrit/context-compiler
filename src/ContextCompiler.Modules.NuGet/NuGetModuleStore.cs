using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Loader;

using Microsoft.Extensions.Logging;

using NuGet.Frameworks;
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

        if (cfg.Current.Offline || string.Equals(cfg.Current.Mode, "Offline", StringComparison.OrdinalIgnoreCase))
        {
            string nupkgPath = FindCachedNupkg(req.PackageId.Id, req.Version.Raw)
                ?? throw new InvalidOperationException($"Offline mode: package not found in cache: {req.PackageId.Id} {req.Version.Raw}");
            return BuildRestoreResult(nupkgPath, req.PackageId.Id, req.Version.Raw, req.PackageId.Checksum, validateSignature: !cfg.Current.Offline);
        }

        PackageDownloadResult downloadResult = await packageDownloader.DownloadPackageAsync(req, source, installRootAbs, ct);

        foreach (DownloadedPackageInfo depInfo in downloadResult.AllPackages)
        {
            if (!string.Equals(depInfo.PackageId, req.PackageId.Id, StringComparison.OrdinalIgnoreCase) ||
                !string.Equals(depInfo.Version, req.Version.Raw, StringComparison.OrdinalIgnoreCase))
            {
                logger.LogInformation("Extracting dependency {PackageId} {Version}", depInfo.PackageId, depInfo.Version);
                NuGetPackageMetadata depMetadata = metadatasExtractor.ExtractMetadatas(depInfo.NupkgPath);
                string depChecksum = Integrity.ComputeSha256Base64(depInfo.NupkgPath);
                _ = ExtractToImmutableCache(depInfo.NupkgPath, depInfo.PackageId, depInfo.Version, depChecksum);
            }
        }

        return BuildRestoreResult(downloadResult.MainPackagePath, req.PackageId.Id, req.Version.Raw, req.PackageId.Checksum, validateSignature: !cfg.Current.Offline);
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
            return dest;
        }

        if (Directory.Exists(packageDir))
        {
            Directory.Delete(packageDir, recursive: true);
        }

        _ = Directory.CreateDirectory(dest);

        using PackageArchiveReader reader = new(nupkgPath);

        // .NET 10 target
        NuGetFramework target = NuGetFramework.ParseFolder("net10.0");
        FrameworkReducer reducer = new();

        // 1) On prend d'abord lib/, car c'est ce qui sert le plus souvent au chargement runtime
        List<FrameworkSpecificGroup> libGroups = [.. reader.GetLibItems().Where(g => g.Items != null && g.Items.Any())];

        NuGetFramework? bestLibFramework = reducer.GetNearest(
            target,
            libGroups.Select(g => g.TargetFramework));

        FrameworkSpecificGroup? bestLibGroup = libGroups.FirstOrDefault(g => g.TargetFramework.Equals(bestLibFramework));

        // 2) Optionnel : fallback sur ref/ si jamais le package n'a pas de lib/
        List<FrameworkSpecificGroup> refGroups = [.. reader.GetReferenceItems().Where(g => g.Items != null && g.Items.Any())];

        NuGetFramework? bestRefFramework = reducer.GetNearest(
            target,
            refGroups.Select(g => g.TargetFramework));

        FrameworkSpecificGroup? bestRefGroup = refGroups.FirstOrDefault(g => g.TargetFramework.Equals(bestRefFramework));

        List<FrameworkSpecificGroup> contentGroups = [.. reader.GetContentItems().Where(g => g.Items != null && g.Items.Any())];
        NuGetFramework? bestContentFramework = reducer.GetNearest(target, contentGroups.Select(g => g.TargetFramework)); // juste pour logguer un warning si jamais on trouve un content/ compatible (pas de fallback prévu mais ça peut arriver que des assets soient mis là)
        FrameworkSpecificGroup? bestContentGroup = contentGroups.FirstOrDefault(g => g.TargetFramework.Equals(bestContentFramework));

        // 3) Construire la liste exacte des fichiers à extraire
        HashSet<string> filesToExtract = [];

        if (bestLibGroup is not null)
        {
            foreach (string file in bestLibGroup.Items)
            {
                _ = filesToExtract.Add(file);
            }
        }

        // Garde ref/ seulement si tu en as besoin
        // Si tu veux un cache minimal pour chargement runtime pur, commente ce bloc.
        if (bestRefGroup is not null)
        {
            foreach (string file in bestRefGroup.Items)
            {
                _ = filesToExtract.Add(file);
            }
        }

        if (bestContentGroup is not null)
        {
            foreach (string file in bestContentGroup.Items)
            {
                _ = filesToExtract.Add(file);
            }
        }

        // Optionnel : garder le nuspec
        string? nuspecPath = reader.GetNuspecFile();
        if (!string.IsNullOrEmpty(nuspecPath))
        {
            _ = filesToExtract.Add(nuspecPath);
        }

        // 4) Si aucun groupe compatible n'a été trouvé, fallback minimal :
        // on extrait tout, ou on lève une exception selon ton besoin.
        if (filesToExtract.Count == 0)
        {
            throw new InvalidOperationException(
                $"Aucun asset compatible avec net10.0 n'a été trouvé dans {packageId} {version}.");
        }

        // 5) Extraction ciblée
        foreach (string file in filesToExtract)
        {
            string normalized = file.Replace('/', Path.DirectorySeparatorChar);
            string outPath = Path.Combine(dest, normalized);

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
