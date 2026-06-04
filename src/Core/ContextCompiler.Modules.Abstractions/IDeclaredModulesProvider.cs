
namespace ContextCompiler.Modules.Abstractions
{
    public interface IDeclaredModulesProvider
    {
        IEnumerable<IDeclaredModule> GetDeclaredModules();
    }
}
