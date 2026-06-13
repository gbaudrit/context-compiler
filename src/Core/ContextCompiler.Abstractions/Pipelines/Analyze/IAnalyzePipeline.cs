using ContextCompiler.Abstractions.Models.Analyze;

namespace ContextCompiler.Abstractions.Pipelines.Analyze;

public interface IAnalyzePipeline : IPipeline
{
    ValueTask RunAsync(AnalyzeRequest request, CancellationToken ct);
}
