using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.Pipelines
{
    public interface IDocumentPipelineRunner
    {
        Task<IReadOnlyList<IDocumentCompileResult>> RunAsync(string rootPath, CancellationToken ct);
    }
}
