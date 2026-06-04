using ContextCompiler.Abstractions.Pipelines.Compile;

namespace ContextCompiler.Core.Pipelines.Compile;

internal sealed class CompilePipelineRunResultBuilder : ICompilePipelineRunResultBuilder
{
    public ICompilePipelineRunResultBuilder InitNew()
    {
        return this;
    }

    public ICompilePipelineRunResult Build()
    {
        return new CompilePipelineRunResult();
    }
}
