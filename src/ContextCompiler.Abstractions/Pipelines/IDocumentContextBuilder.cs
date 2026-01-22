using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Abstractions.Pipelines
{
    public interface IDocumentContextBuilder
    {
        IDocumentContext Build();
        IDocumentContextBuilder InitNew();
        IDocumentContextBuilder WithFullPath(string fullPath);
        IDocumentContextBuilder WithInputRoot(string inputRoot);
        IDocumentContextBuilder WithRelativePath(string relativePath);
    }
}
