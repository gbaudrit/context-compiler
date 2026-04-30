using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IDocumentContextPatch
    {
        IDataEnvelope? DataEnvelope { get; init; }
        IReadOnlyList<IPipelineFinding> Findings { get; init; }
        IReadOnlyList<IFragment> Fragments { get; init; }
        IReadOnlyList<IDataPart> Parts { get; init; }
        IReadOnlyList<ITag> Tags { get; init; }
        IReadOnlyList<ITranscodedFragment> TranscodedFragments { get; init; }
    }
}
