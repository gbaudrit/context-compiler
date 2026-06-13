namespace ContextCompiler.Modules.Abstractions;

public interface IModuleRestoreRequestResult
{
    bool Success { get; init; }
    string RestoredPath { get; init; }
    string ResolvedVersion { get; init; }

    IModuleMetadatas Metadatas { get; init; }
}
