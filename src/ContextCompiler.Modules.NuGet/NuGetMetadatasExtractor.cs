using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

using NuGet.Packaging;
using NuGet.Packaging.Core;

namespace ContextCompiler.Modules.NuGet;

internal sealed class NuGetMetadatasExtractor(IModuleDependencyBuilder moduleDependencyBuilder,
                                               ILogger<NuGetMetadatasExtractor> logger) : INuGetMetadatasExtractor
{
    public NuGetPackageMetadata ExtractMetadatas(string nupkgPath)
    {
        using PackageArchiveReader reader = new(nupkgPath);
        NuspecReader nuspec = reader.NuspecReader;
        string authors = nuspec.GetAuthors() ?? "";
        string? repoUrl = nuspec.GetRepositoryMetadata()?.Url;

        List<IModuleDependency> dependencies = [];
        foreach (PackageDependencyGroup? group in nuspec.GetDependencyGroups())
        {
            foreach (PackageDependency? dependency in group.Packages)
            {
                logger.LogInformation("Found dependency: {Id} {VersionRange}", dependency.Id, dependency.VersionRange?.OriginalString);

                IModuleDependency moduleDependency = moduleDependencyBuilder
                    .InitNew()
                    .WithId(dependency.Id)
                    .WithVersion(dependency.VersionRange?.OriginalString ?? "")
                    .Build();

                dependencies.Add(moduleDependency);
            }
        }

        List<string> files = [.. reader.GetFiles()];

        return new NuGetPackageMetadata
        {
            Authors = authors,
            RepositoryUrl = repoUrl,
            Dependencies = dependencies,
            Files = files
        };
    }
}
