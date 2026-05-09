using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Abstractions.Pipelines;

public interface IInputItemContextData
{
    IDataEnvelope DataEnvelope { get; }
    IReadOnlyList<IPipelineFinding> Findings { get; }
    IReadOnlyList<IFragment> Fragments { get; }
    IReadOnlyList<ITag> Tags { get; }
}
