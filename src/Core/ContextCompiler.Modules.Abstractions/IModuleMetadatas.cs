namespace ContextCompiler.Modules.Abstractions;

public interface IModuleMetadatas
{
    string Id { get; }

    string[] Authors { get; }

    Uri? RepositoryUrl { get; }

    IEnumerable<IModuleDependency> Dependencies { get; }

    IEnumerable<string> Files { get; }

    IModuleSignature Signature { get; }
    IModuleVersion Version { get; }

    string Checksum { get; }
    string Source { get; init; }
}
