using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Compile;

namespace ContextCompiler.Core.Pipelines.Compile;

internal sealed class CompilePipelineRunContextBuilder(
    ICompilePipelineRunResultBuilder resultBuilder) : ICompilePipelineRunContextBuilder
{
    private IPipeline? _pipeline;
    private string? _currentPhaseKey;

    public ICompilePipelineRunContextBuilder InitNew()
    {
        _pipeline = null;
        _currentPhaseKey = null;
        return this;
    }

    public ICompilePipelineRunContextBuilder WithPipeline(IPipeline pipeline)
    {
        _pipeline = pipeline;
        return this;
    }

    public ICompilePipelineRunContextBuilder WithPhaseKey(string phaseKey)
    {
        _currentPhaseKey = phaseKey;
        return this;
    }

    public ICompilePipelineRunContext Build()
    {
        ArgumentNullException.ThrowIfNull(_pipeline, nameof(_pipeline));
        ArgumentNullException.ThrowIfNull(_currentPhaseKey, nameof(_currentPhaseKey));

        return new CompilePipelineRunContext(_pipeline, _currentPhaseKey, resultBuilder);
    }
}
