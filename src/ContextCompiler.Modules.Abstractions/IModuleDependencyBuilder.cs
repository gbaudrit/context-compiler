namespace ContextCompiler.Modules.Abstractions;

public interface IModuleDependencyBuilder
{
    IModuleDependency Build();
    IModuleDependencyBuilder InitNew();
    IModuleDependencyBuilder WithId(string id);
    IModuleDependencyBuilder WithVersion(string version);
}
