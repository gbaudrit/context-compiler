using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Core.Pipelines.Document;

internal sealed class DocumentPipelineRunResultBuilder : IDocumentPipelineRunResultBuilder
{
    private IDocumentContextPatch? _patch;

    public IDocumentPipelineRunResultBuilder InitNew()
    {
        _patch = null;
        return this;
    }

    public IDocumentPipelineRunResultBuilder WithPatch(IDocumentContextPatch patch)
    {
        _patch = patch;
        return this;
    }

    public IDocumentPipelineRunResult Build()
    {
        ArgumentNullException.ThrowIfNull(_patch, nameof(_patch));

        return new DocumentPipelineRunResult
        {
            Patch = _patch
        };
    }
}
