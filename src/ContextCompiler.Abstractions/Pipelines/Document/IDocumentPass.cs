using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IDocumentPass
    {
        string Id { get; }
        int Priority { get; }               // deterministic ordering inside a stage
        DocumentStage Stage { get; }
        ValueTask ExecuteAsync(IDocumentContext ctx, CancellationToken ct);
    }
}
