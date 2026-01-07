using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Pipelines
{
    public interface IGlobalPipelineRunner
    {
        ValueTask RunAsync(string rootPath,
                           string outputPath,
                           IReasoningIr ir,
                           IReadOnlyList<IPipelineFinding> findings,
                           CompileOptions options,
                           IPlugins<IOutputPlugin> outputPlugins,
                           CancellationToken ct);
    }
}
