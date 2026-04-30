namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IDataPartPipelineRunResult
    {
        bool Ok { get; }
        int ExitCode { get; } // 0 ok, 1 error, 2 blocked
        IReadOnlyList<IPipelineFinding> Findings { get; }
    }
}
