namespace ContextCompiler.Modules.Abstractions;

public interface IModuleDependency
{
    string Id { get; }
    string Version { get; }
}
