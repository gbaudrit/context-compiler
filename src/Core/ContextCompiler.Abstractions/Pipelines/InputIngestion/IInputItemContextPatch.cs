using ContextCompiler.Abstractions.Compiled;

namespace ContextCompiler.Abstractions.Pipelines.InputIngestion
{
    public interface IInputItemContextPatch
    {
        IDataEnvelope? DataEnvelope { get; init; }
        IReadOnlyList<IPipelineFinding> Findings { get; init; }
        IReadOnlyList<IFragment> Fragments { get; init; }
        IReadOnlyList<IDataPart> Parts { get; init; }
        IReadOnlyList<ITag> Tags { get; init; }
    }
}
