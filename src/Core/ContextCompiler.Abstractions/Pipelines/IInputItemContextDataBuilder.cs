using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Pipelines;

public interface IInputItemContextDataBuilder
{
    IInputItemContextDataBuilder InitFrom(IInputItemContextData data);

    IInputItemContextData Build();
    IInputItemContextDataBuilder WithFindings(IEnumerable<IPipelineFinding> findings);
    IInputItemContextDataBuilder WithFragments(IEnumerable<IFragment> fragments);
    IInputItemContextDataBuilder WithTags(IEnumerable<ITag> tags);
    IInputItemContextDataBuilder WithDataEnvelope(IDataEnvelope dataEnvelope);
    IInputItemContextDataBuilder InitNew();
}
