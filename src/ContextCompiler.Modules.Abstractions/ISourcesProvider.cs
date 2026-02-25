namespace ContextCompiler.Modules.Abstractions;

public interface ISourcesProvider
{
    bool Exists(string id);
    ISource GetById(string id);
}
