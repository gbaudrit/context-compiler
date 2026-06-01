using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Core.Pipelines.InputIngestion;

internal sealed class InputIngestionPipelineRunResult : IInputIngestionPipelineRunResult
{
    public required IInputItemContextPatch Patch { get; init; }
}
