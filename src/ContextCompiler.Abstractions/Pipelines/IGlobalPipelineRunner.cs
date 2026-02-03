using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Pipelines
{
    public interface IGlobalPipelineRunner
    {
        ValueTask RunAsync(string rootPath,
                           string outputPath,
                           bool cleanOutput,
                           IReasoningIr ir,
                           IReadOnlyList<IPipelineFinding> findings,
                           CompileOptions options,
                           IOutput output,
                           CancellationToken ct);
    }
}
