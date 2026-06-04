using ContextCompiler.Abstractions.Models.Prepare;

namespace ContextCompiler.Abstractions.Pipelines.Prepare;

public interface IPreparePipeline : IPipeline
{
    ValueTask RunAsync(PrepareRequest request, CancellationToken ct);
}
