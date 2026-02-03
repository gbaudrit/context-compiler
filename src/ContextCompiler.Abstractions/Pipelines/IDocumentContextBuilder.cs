using System.Text.Json;

using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Abstractions.Pipelines
{
    public interface IDocumentContextBuilder
    {
        IDocumentContext Build();
        IDocumentContextBuilder InitNew();
        IDocumentContextBuilder WithExtractOptions(JsonElement extractOptions);
        IDocumentContextBuilder WithFullPath(string fullPath);
        IDocumentContextBuilder WithInputRoot(string inputRoot);
        IDocumentContextBuilder WithRelativePath(string relativePath);
    }
}
