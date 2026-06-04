namespace ContextCompiler.Modules.Abstractions
{
    public interface IDeclaredModule
    {
        IModuleRestoreId PackageId { get; init; }
        IModuleRestoreVersion Version { get; init; }

        string ExtractPath { get; init; }
    }
}
