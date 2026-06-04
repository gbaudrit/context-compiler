using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Prepare;

namespace ContextCompiler.Core.Pipelines.Prepare;

internal sealed class PreparePipelineRunContextBuilder(
    IPreparePipelineRunResultBuilder resultBuilder) : IPreparePipelineRunContextBuilder
{
    private IPipeline? _pipeline;
    private string? _phaseKey;
    private PrepareRequest? _request;

    public IPreparePipelineRunContextBuilder InitNew()
    {
        _pipeline = null;
        _phaseKey = null;
        _request = null;
        return this;
    }

    public IPreparePipelineRunContextBuilder WithPipeline(IPipeline pipeline)
    {
        _pipeline = pipeline;
        return this;
    }

    public IPreparePipelineRunContextBuilder WithPhaseKey(string phaseKey)
    {
        _phaseKey = phaseKey;
        return this;
    }

    public IPreparePipelineRunContextBuilder WithRequest(PrepareRequest request)
    {
        _request = request;
        return this;
    }

    public IPreparePipelineRunContext Build()
    {
        ArgumentNullException.ThrowIfNull(_pipeline, nameof(_pipeline));
        ArgumentNullException.ThrowIfNull(_phaseKey, nameof(_phaseKey));
        ArgumentNullException.ThrowIfNull(_request, nameof(_request));

        return new PreparePipelineRunContext(_pipeline, _phaseKey, _request, resultBuilder);
    }
}
