using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Core.Pipelines.InputIngestion;

internal sealed class InputItemContextPatch : IInputItemContextPatch
{
    public required IDataEnvelope? DataEnvelope { get; init; }
    public required IReadOnlyList<IPipelineFinding> Findings { get; init; }
    public required IReadOnlyList<IFragment> Fragments { get; init; }
    public required IReadOnlyList<ITag> Tags { get; init; }
    public required IReadOnlyList<IDataPart> Parts { get; init; }
}
