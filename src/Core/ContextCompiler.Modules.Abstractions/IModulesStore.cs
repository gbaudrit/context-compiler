namespace ContextCompiler.Modules.Abstractions
{
    public interface IModulesStore
    {
        Task<IModuleRestoreRequestResult> RestoreAsync(IDeclaredModule req, bool force, CancellationToken ct);
    }
}
