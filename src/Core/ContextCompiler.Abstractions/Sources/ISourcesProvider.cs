namespace ContextCompiler.Abstractions.Sources;

public interface ISourcesProvider
{
    IReadOnlyList<ISource> GetAll();
    IReadOnlyList<ISource> GetByOptionKey(string optionKey);
}
