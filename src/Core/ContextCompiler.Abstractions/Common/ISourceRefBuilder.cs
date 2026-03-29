using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Abstractions.Common
{
    public interface ISourceRefBuilder
    {
        ISourceRefBuilder InitNew();
        ISourceRef Build();
        ISourceRefBuilder WithLocator(string locator);
        ISourceRefBuilder WithPath(string path);
    }
}
