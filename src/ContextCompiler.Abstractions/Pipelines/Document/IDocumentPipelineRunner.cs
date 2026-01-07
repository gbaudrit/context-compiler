using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IDocumentPipelineRunner
    {
        ValueTask RunAsync(IDocumentsContext documentsContext, CancellationToken ct);
    }
}
