using ContextCompiler.Abstractions.Pipelines;

namespace ContextCompiler.Core.Pipelines;

internal sealed class GlobalPipelineRunContextBuilder(
    IGlobalPipelineRunResultBuilder resultBuilder) : IGlobalPipelineRunContextBuilder
{
    private IPipeline? _pipeline;
    private string? _currentPhaseKey;

    public IGlobalPipelineRunContextBuilder InitNew()
    {
        _pipeline = null;
        _currentPhaseKey = null;
        return this;
    }

    public IGlobalPipelineRunContextBuilder WithPipeline(IPipeline pipeline)
    {
        _pipeline = pipeline;
        return this;
    }

    public IGlobalPipelineRunContextBuilder WithPhaseKey(string phaseKey)
    {
        _currentPhaseKey = phaseKey;
        return this;
    }

    public IGlobalPipelineRunContext Build()
    {
        ArgumentNullException.ThrowIfNull(_pipeline, nameof(_pipeline));
        ArgumentNullException.ThrowIfNull(_currentPhaseKey, nameof(_currentPhaseKey));

        return new GlobalPipelineRunContext(_pipeline, _currentPhaseKey, resultBuilder);
    }
}
