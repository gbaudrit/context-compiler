using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Loading;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using NuGet.Frameworks;
using NuGet.Packaging;

namespace ContextCompiler.Modules.NuGet;

public sealed class NuGetModuleStore(IOptions<ModulesConfig> cfgOptions,
                                     IModuleMetadatasBuilder moduleMetadatasBuilder,
                                     IModuleRestoreRequestResultBuilder resultBuilder,
                                     ITrustPolicy trustPolicy,
                                     IPackageDownloader packageDownloader,
                                     INuGetMetadatasExtractor metadatasExtractor,
                                     IIntegrityChecker integrityChecker,
                                     ILogger<NuGetModuleStore> logger) : IModulesStore
{
    private readonly ITrustPolicy _policy = trustPolicy;
    private ModulesConfig Cfg => cfgOptions.Value;

    public async Task<IModuleRestoreRequestResult> RestoreAsync(IModuleRestoreRequest req, bool force, CancellationToken ct)
    {
        ModuleSource source = Cfg.Sources.Single(s => string.Equals(s.Name, req.PackageId.Source.Id, StringComparison.OrdinalIgnoreCase));
        _policy.ValidateSource(source);
        _policy.ValidatePackageId(req.PackageId.Id);

        string installRootAbs = Path.GetFullPath(Cfg.InstallRoot);
        _ = Directory.CreateDirectory(installRootAbs);

        if (Cfg.Offline || string.Equals(Cfg.Mode, "Offline", StringComparison.OrdinalIgnoreCase))
        {
            string nupkgPath = FindCachedNupkg(req.PackageId.Id, req.Version.Raw)
                ?? throw new InvalidOperationException($"Offline mode: package not found in cache: {req.PackageId.Id} {req.Version.Raw}");
            return BuildRestoreResult(nupkgPath, req.PackageId.Id, req.Version.Raw, req.PackageId.Checksum, validateSignature: !Cfg.Offline, force);
        }

        PackageDownloadResult downloadResult = await packageDownloader.DownloadPackageAsync(req, source, installRootAbs, force, ct);

        foreach (DownloadedPackageInfo depInfo in downloadResult.AllPackages)
        {
            if (force || !string.Equals(depInfo.PackageId, req.PackageId.Id, StringComparison.OrdinalIgnoreCase) ||
                !string.Equals(depInfo.Version, req.Version.Raw, StringComparison.OrdinalIgnoreCase))
            {
                logger.LogInformation("Extracting dependency {PackageId} {Version}", depInfo.PackageId, depInfo.Version);
                NuGetPackageMetadata depMetadata = metadatasExtractor.ExtractMetadatas(depInfo.NupkgPath);
                string depChecksum = integrityChecker.ComputeSha256Base64(depInfo.NupkgPath);
                _ = ExtractToImmutableCache(depInfo.NupkgPath, depInfo.PackageId, depInfo.Version, depChecksum, force);
            }
        }

        return BuildRestoreResult(downloadResult.MainPackagePath, req.PackageId.Id, req.Version.Raw, req.PackageId.Checksum, validateSignature: !Cfg.Offline, force);
    }

    private IModuleRestoreRequestResult BuildRestoreResult(string nupkgPath, string packageId, string version, string checksum, bool validateSignature, bool force)
    {
        NuGetPackageMetadata packageMetadata = metadatasExtractor.ExtractMetadatas(nupkgPath);
        (bool isSigned, string? note) = CheckSignedBestEffort(nupkgPath);

        if (validateSignature)
        {
            _policy.ValidateSignature(isSigned, note);
        }

        string extractedRoot = ExtractToImmutableCache(nupkgPath, packageId, version, checksum, force);

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

    private string ExtractToImmutableCache(string nupkgPath, string packageId, string version, string shaBase64, bool force)
    {
        string hashDir = shaBase64.Replace("/", "_").Replace("+", "-");
        string packageDir = Path.Combine(Path.GetFullPath(Cfg.InstallRoot), packageId);
        string dest = Path.Combine(packageDir, version, hashDir);

        if (!force && Directory.Exists(dest))
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
        NuGetFramework? bestContentFramework = reducer.GetNearest(target, contentGroups.Select(g => g.TargetFramework));
        FrameworkSpecificGroup? bestContentGroup = contentGroups.FirstOrDefault(g => g.TargetFramework.Equals(bestContentFramework));

        // 3) Construire la liste exacte des fichiers à extraire
        HashSet<string> filesToExtract = [];

        // lib/ - Assemblies runtime (obligatoire)
        if (bestLibGroup is not null)
        {
            foreach (string file in bestLibGroup.Items)
            {
                _ = filesToExtract.Add(file);
            }
        }

        // ref/ - Reference assemblies (optionnel)
        if (bestRefGroup is not null)
        {
            foreach (string file in bestRefGroup.Items)
            {
                _ = filesToExtract.Add(file);
            }
        }

        // content/ - Assets génériques (optionnel)
        if (bestContentGroup is not null)
        {
            foreach (string file in bestContentGroup.Items)
            {
                _ = filesToExtract.Add(file);
            }
        }

        // contentFiles/ - Modern content convention (tout extraire, indépendamment du TFM)
        IEnumerable<string> allContentFiles = reader.GetFiles()
            .Where(f => f.StartsWith("contentFiles/", StringComparison.OrdinalIgnoreCase));

        foreach (string file in allContentFiles)
        {
            _ = filesToExtract.Add(file);
        }

        // module-assets/ - Convention personnalisée pour assets de modules (React apps, templates, etc.)
        IEnumerable<string> moduleAssets = reader.GetFiles()
            .Where(f => f.StartsWith("module-assets/", StringComparison.OrdinalIgnoreCase));

        foreach (string file in moduleAssets)
        {
            _ = filesToExtract.Add(file);
        }

        // Optionnel : garder le nuspec
        string? nuspecPath = reader.GetNuspecFile();
        if (!string.IsNullOrEmpty(nuspecPath))
        {
            _ = filesToExtract.Add(nuspecPath);
        }

        // Log des assets extraits par catégorie
        int libCount = bestLibGroup?.Items.Count() ?? 0;
        int refCount = bestRefGroup?.Items.Count() ?? 0;
        int contentCount = bestContentGroup?.Items.Count() ?? 0;
        int contentFilesCount = reader.GetFiles().Count(f => f.StartsWith("contentFiles/", StringComparison.OrdinalIgnoreCase));
        int moduleAssetsCount = reader.GetFiles().Count(f => f.StartsWith("module-assets/", StringComparison.OrdinalIgnoreCase));

        logger.LogInformation(
            "Extracting {PackageId} {Version}: {LibCount} lib/, {RefCount} ref/, {ContentCount} content/, {ContentFilesCount} contentFiles/, {ModuleAssetsCount} module-assets/",
            packageId, version, libCount, refCount, contentCount, contentFilesCount, moduleAssetsCount);

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
        string p = Path.Combine(Path.GetFullPath(Cfg.InstallRoot), "_nupkg", packageId, version, $"{packageId}.{version}.nupkg");
        return File.Exists(p) ? p : null;
    }
}
