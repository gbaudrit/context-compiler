using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IDocumentsContext
    {
        string RootPath { get; init; }
        IReadOnlyList<IDocumentContext> Documents { get; }

        public void AddDocument(IDocumentContext doc);
    }
}
