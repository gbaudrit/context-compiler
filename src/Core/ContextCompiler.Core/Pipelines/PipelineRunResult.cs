using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Core.Pipelines
{

    public sealed record PipelineRunResult(
        bool Ok,
        int ExitCode, // 0 ok, 1 error, 2 blocked
        IReadOnlyList<IPipelineFinding> Findings
    ) : IPipelineRunResult;
}
