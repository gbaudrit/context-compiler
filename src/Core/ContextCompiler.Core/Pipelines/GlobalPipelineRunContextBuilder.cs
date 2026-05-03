using ContextCompiler.Abstractions.Pipelines;

namespace ContextCompiler.Core.Pipelines;

internal sealed class GlobalPipelineRunContextBuilder(
    IGlobalPipelineRunResultBuilder resultBuilder) : IGlobalPipelineRunContextBuilder
{
    private IPipeline? _pipeline;

    public IGlobalPipelineRunContextBuilder InitNew()
    {
        _pipeline = null;
        return this;
    }

    public IGlobalPipelineRunContextBuilder WithPipeline(IPipeline pipeline)
    {
        _pipeline = pipeline;
        return this;
    }

    public IGlobalPipelineRunContext Build()
    {
        ArgumentNullException.ThrowIfNull(_pipeline, nameof(_pipeline));

        return new GlobalPipelineRunContext(_pipeline, resultBuilder);
    }
}
