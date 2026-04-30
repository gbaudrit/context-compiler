using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Pipelines;

public interface IDocumentContextDataBuilder
{
    IDocumentContextDataBuilder InitFrom(IDocumentContextData data);

    IDocumentContextData Build();
    IDocumentContextDataBuilder WithFindings(IEnumerable<IPipelineFinding> findings);
    IDocumentContextDataBuilder WithFragments(IEnumerable<IFragment> fragments);
    IDocumentContextDataBuilder WithTags(IEnumerable<ITag> tags);
    IDocumentContextDataBuilder WithDataEnvelope(IDataEnvelope dataEnvelope);
    IDocumentContextDataBuilder InitNew();
}
