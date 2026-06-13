using ContextCompiler.Abstractions.Models.Analyze;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Analyze;

namespace ContextCompiler.Core.Pipelines.Analyze;

internal sealed class AnalyzePipelineRunContextBuilder(
    IAnalyzePipelineRunResultBuilder resultBuilder) : IAnalyzePipelineRunContextBuilder
{
    private IPipeline? _pipeline;
    private string? _phaseKey;
    private AnalyzeRequest? _request;

    public IAnalyzePipelineRunContextBuilder InitNew()
    {
        _pipeline = null;
        _phaseKey = null;
        _request = null;
        return this;
    }

    public IAnalyzePipelineRunContextBuilder WithPipeline(IPipeline pipeline)
    {
        _pipeline = pipeline;
        return this;
    }

    public IAnalyzePipelineRunContextBuilder WithPhaseKey(string phaseKey)
    {
        _phaseKey = phaseKey;
        return this;
    }

    public IAnalyzePipelineRunContextBuilder WithRequest(AnalyzeRequest request)
    {
        _request = request;
        return this;
    }

    public IAnalyzePipelineRunContext Build()
    {
        ArgumentNullException.ThrowIfNull(_pipeline, nameof(_pipeline));
        ArgumentNullException.ThrowIfNull(_phaseKey, nameof(_phaseKey));
        ArgumentNullException.ThrowIfNull(_request, nameof(_request));

        return new AnalyzePipelineRunContext(_pipeline, _phaseKey, _request, resultBuilder);
    }
}
