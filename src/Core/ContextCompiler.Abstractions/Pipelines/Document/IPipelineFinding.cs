using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IPipelineFinding
    {

        FindingSeverity Severity { get; }
        FindingAction Action { get; }
        string PassId { get; }
        string Message { get; }
        ISourceRef? EvidenceRef { get; }
    }
}
