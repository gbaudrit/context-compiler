using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Abstractions.Pipelines.DataPart
{
    public interface IDataPartPipelineRunner
    {
        ValueTask<IPipelineRunResult> RunAsync(IDocumentContext ctx,IDataPart part, CancellationToken ct);
    }
}
