using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Abstractions.Pipelines.Compile
{
    public interface ICompilePipeline : IPipeline
    {
        ValueTask RunAsync(string rootPath,
                           string outputPath,
                           bool cleanOutput,
                           IOutput output,
                           CancellationToken ct);
    }
}
