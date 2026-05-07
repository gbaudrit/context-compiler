using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Core.Pipelines.InputIngestion;

internal sealed class InputIngestionPipelineRunContextBuilder(
    IInputIngestionPipelineRunResultBuilder resultBuilder) : IInputIngestionPipelineRunContextBuilder
{
    private IPipeline? _pipeline;
    private IInputItemContext? _InputItemContext;
    private IInputItemContextPatchBuilder? _patchContext;

    public IInputIngestionPipelineRunContextBuilder InitNew()
    {
        _pipeline = null;
        _InputItemContext = null;
        _patchContext = null;
        return this;
    }

    public IInputIngestionPipelineRunContextBuilder WithPipeline(IPipeline pipeline)
    {
        _pipeline = pipeline;
        return this;
    }

    public IInputIngestionPipelineRunContextBuilder WithInputItemContext(IInputItemContext InputItemContext)
    {
        _InputItemContext = InputItemContext;
        return this;
    }

    public IInputIngestionPipelineRunContextBuilder WithPatchContext(IInputItemContextPatchBuilder patchContext)
    {
        _patchContext = patchContext;
        return this;
    }

    public IInputIngestionPipelineRunContext Build()
    {
        ArgumentNullException.ThrowIfNull(_pipeline, nameof(_pipeline));
        ArgumentNullException.ThrowIfNull(_InputItemContext, nameof(_InputItemContext));
        ArgumentNullException.ThrowIfNull(_patchContext, nameof(_patchContext));

        return new InputIngestionPipelineRunContext(_pipeline, _InputItemContext, _patchContext, resultBuilder);
    }
}
