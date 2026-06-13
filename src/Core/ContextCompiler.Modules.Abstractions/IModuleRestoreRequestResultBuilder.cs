namespace ContextCompiler.Modules.Abstractions;

public interface IModuleRestoreRequestResultBuilder
{
    IModuleRestoreRequestResultBuilder InitNew();
    IModuleRestoreRequestResultBuilder InitNewFrom(IModuleRestoreRequestResult result);
    IModuleRestoreRequestResultBuilder WithSuccess(bool success);
    IModuleRestoreRequestResultBuilder WithRestoredPath(string restoredPath);
    IModuleRestoreRequestResultBuilder WithResolvedVersion(string resolvedVersion);
    IModuleRestoreRequestResultBuilder WithMetadatas(IModuleMetadatas metadatas);
    IModuleRestoreRequestResult Build();
}
