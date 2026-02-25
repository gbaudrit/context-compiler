
namespace ContextCompiler.Modules.Abstractions
{
    public interface IModulesToRestoreProvider
    {
        IEnumerable<IModuleRestoreRequest> ModulesToRestore();
    }
}
