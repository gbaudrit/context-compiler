using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Abstractions.Pipelines.DataPart
{
    public interface IDataPartPipelineRunner
    {
        ValueTask<IDataPartPipelineRunResult> RunAsync(IDocumentContext ctx, IDataPart part, CancellationToken ct);
    }
}
