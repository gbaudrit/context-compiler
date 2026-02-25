namespace ContextCompiler.Modules.Abstractions
{
    public interface IModulesStore
    {
        Task<IModuleRestoreRequestResult> RestoreAsync(IModuleRestoreRequest req, CancellationToken ct);
    }
}
