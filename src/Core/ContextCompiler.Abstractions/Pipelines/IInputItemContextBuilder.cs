using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Abstractions.Sources;

namespace ContextCompiler.Abstractions.Pipelines
{
    public interface IInputItemContextBuilder
    {
        IInputItemContext Build();
        IInputItemContextBuilder InitNew();
        IInputItemContextBuilder InitFrom(IInputItemContext context);
        IInputItemContextBuilder FromSource(ISource source);
        IInputItemContextBuilder WithFullPath(string fullPath);
        IInputItemContextBuilder WithInputRoot(string inputRoot);
        IInputItemContextBuilder WithRelativePath(string relativePath);
        IInputItemContextBuilder WithData(IInputItemContextData data);
    }
}
