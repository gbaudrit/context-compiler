using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Sources;

namespace ContextCompiler.Abstractions.Pipelines
{
    public interface IDocumentContextBuilder
    {
        IDocumentContext Build();
        IDocumentContextBuilder InitNew();
        IDocumentContextBuilder FromSource(ISource source);
        IDocumentContextBuilder WithFullPath(string fullPath);
        IDocumentContextBuilder WithInputRoot(string inputRoot);
        IDocumentContextBuilder WithRelativePath(string relativePath);
    }
}
