namespace ContextCompiler.Modules.Abstractions
{
    public interface IModuleRestoreRequest
    {
        IModuleRestoreId PackageId { get; init; }
        IModuleRestoreVersion Version { get; init; }

        string ExtractPath { get; init; }
    }
}
