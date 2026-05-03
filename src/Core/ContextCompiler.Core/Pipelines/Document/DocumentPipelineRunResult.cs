using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Core.Pipelines.Document;

internal sealed class DocumentPipelineRunResult : IDocumentPipelineRunResult
{
    public required IDocumentContextPatch Patch { get; init; }
}
