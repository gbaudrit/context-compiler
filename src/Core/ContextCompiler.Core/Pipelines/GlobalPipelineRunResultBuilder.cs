using ContextCompiler.Abstractions.Pipelines;

namespace ContextCompiler.Core.Pipelines;

internal sealed class GlobalPipelineRunResultBuilder : IGlobalPipelineRunResultBuilder
{
    public IGlobalPipelineRunResultBuilder InitNew()
    {
        return this;
    }

    public IGlobalPipelineRunResult Build()
    {
        return new GlobalPipelineRunResult();
    }
}
