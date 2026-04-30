using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Core.Pipelines.Document;

internal sealed class DocumentContextPatch : IDocumentContextPatch
{
    public required IDataEnvelope? DataEnvelope { get; init; }
    public required IReadOnlyList<IPipelineFinding> Findings { get; init; }
    public required IReadOnlyList<IFragment> Fragments { get; init; }
    public required IReadOnlyList<ITag> Tags { get; init; }
    public required IReadOnlyList<IDataPart> Parts { get; init; }
}
