using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Core.Pipelines
{

    public sealed record DataPartPipelineRunResult(
        bool Ok,
        int ExitCode, // 0 ok, 1 error, 2 blocked
        IReadOnlyList<IPipelineFinding> Findings
    ) : IDataPartPipelineRunResult;
}
