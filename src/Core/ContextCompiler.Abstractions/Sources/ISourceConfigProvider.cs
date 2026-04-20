using ContextCompiler.Abstractions.Configuration.Sections;

namespace ContextCompiler.Abstractions.Sources;

public interface ISourceConfigProvider
{
    IReadOnlyList<ISourceConfigSection> GetAll();
    IReadOnlyList<ISourceConfigSection> GetByOptionKey(string optionKey);
}
