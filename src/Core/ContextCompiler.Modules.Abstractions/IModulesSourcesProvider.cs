namespace ContextCompiler.Modules.Abstractions;

public interface IModulesSourcesProvider
{
    bool Exists(string id);
    IModuleSource GetById(string id);

    IEnumerable<IModuleSource> GetAllOrdered();
}
