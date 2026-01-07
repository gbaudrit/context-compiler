using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Core.Pipelines.Document
{
    internal sealed class DocumentsContext : IDocumentsContext
    {
        private readonly List<IDocumentContext> _documents = new();

        public required string RootPath { get; init; }

        public IReadOnlyList<IDocumentContext> Documents => _documents;

        public void AddDocument(IDocumentContext doc)
        {
            _documents.Add(doc);
        }

    }
}
