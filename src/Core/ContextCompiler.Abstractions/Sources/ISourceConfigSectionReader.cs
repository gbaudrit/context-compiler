using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration.Sections;

namespace ContextCompiler.Abstractions.Sources;

public interface ISourceConfigSectionReader
{

    IResult<T> TryRead<T>(ISourceConfigSection source, string key);

    bool CanRead(ISourceConfigSection source, string key);

}
