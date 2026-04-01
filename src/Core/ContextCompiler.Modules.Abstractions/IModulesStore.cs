namespace ContextCompiler.Modules.Abstractions
{
    public interface IModulesStore
    {
        Task<IModuleRestoreRequestResult> RestoreAsync(IModuleRestoreRequest req, bool force, CancellationToken ct);
    }
}
