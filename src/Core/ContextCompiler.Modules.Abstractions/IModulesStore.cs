namespace ContextCompiler.Modules.Abstractions
{
    public interface IModulesStore
    {
        Task<IModuleRestoreRequestResult> RestoreAsync(IDeclaredModule req, IModuleSource source, bool force, CancellationToken ct);
    }
}
