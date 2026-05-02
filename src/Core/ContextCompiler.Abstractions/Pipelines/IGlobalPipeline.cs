using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Abstractions.Pipelines
{
    public interface IGlobalPipeline : IPipeline
    {
        ValueTask RunAsync(string rootPath,
                           string outputPath,
                           bool cleanOutput,
                           IOutput output,
                           CancellationToken ct);
    }
}
