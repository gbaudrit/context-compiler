using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Core.Pipelines.InputIngestion;

internal sealed class InputIngestionPipelineRunResultBuilder : IInputIngestionPipelineRunResultBuilder
{
    private IInputItemContextPatch? _patch;

    public IInputIngestionPipelineRunResultBuilder InitNew()
    {
        _patch = null;
        return this;
    }

    public IInputIngestionPipelineRunResultBuilder WithPatch(IInputItemContextPatch patch)
    {
        _patch = patch;
        return this;
    }

    public IInputIngestionPipelineRunResult Build()
    {
        ArgumentNullException.ThrowIfNull(_patch, nameof(_patch));

        return new InputIngestionPipelineRunResult
        {
            Patch = _patch
        };
    }
}
