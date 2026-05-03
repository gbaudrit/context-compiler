using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Core.Pipelines.Document;

internal sealed class DocumentPipelineRunContextBuilder(
    IDocumentPipelineRunResultBuilder resultBuilder) : IDocumentPipelineRunContextBuilder
{
    private IPipeline? _pipeline;
    private IDocumentContext? _documentContext;
    private IDocumentContextPatchBuilder? _patchContext;

    public IDocumentPipelineRunContextBuilder InitNew()
    {
        _pipeline = null;
        _documentContext = null;
        _patchContext = null;
        return this;
    }

    public IDocumentPipelineRunContextBuilder WithPipeline(IPipeline pipeline)
    {
        _pipeline = pipeline;
        return this;
    }

    public IDocumentPipelineRunContextBuilder WithDocumentContext(IDocumentContext documentContext)
    {
        _documentContext = documentContext;
        return this;
    }

    public IDocumentPipelineRunContextBuilder WithPatchContext(IDocumentContextPatchBuilder patchContext)
    {
        _patchContext = patchContext;
        return this;
    }

    public IDocumentPipelineRunContext Build()
    {
        ArgumentNullException.ThrowIfNull(_pipeline, nameof(_pipeline));
        ArgumentNullException.ThrowIfNull(_documentContext, nameof(_documentContext));
        ArgumentNullException.ThrowIfNull(_patchContext, nameof(_patchContext));

        return new DocumentPipelineRunContext(_pipeline, _documentContext, _patchContext, resultBuilder);
    }
}
