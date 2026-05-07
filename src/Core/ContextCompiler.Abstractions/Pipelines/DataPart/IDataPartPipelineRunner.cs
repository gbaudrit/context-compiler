using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Abstractions.Pipelines.DataPart
{
    public interface IDataPartPipelineRunner
    {
        ValueTask<IDataPartPipelineRunResult> RunAsync(IInputItemContext ctx, IDataPart part, CancellationToken ct);
    }
}
