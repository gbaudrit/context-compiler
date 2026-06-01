using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules.NuGet;

public sealed class NuGetPackageMetadata
{
    public required string Authors { get; init; }
    public string? RepositoryUrl { get; init; }
    public required List<IModuleDependency> Dependencies { get; init; }
    public required List<string> Files { get; init; }
}
