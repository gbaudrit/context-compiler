using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Pipelines;

public interface IDocumentContextData
{
    IDataEnvelope DataEnvelope { get; }
    IReadOnlyList<IPipelineFinding> Findings { get; }
    IReadOnlyList<IFragment> Fragments { get; }
    IReadOnlyList<ITag> Tags { get; }
}
