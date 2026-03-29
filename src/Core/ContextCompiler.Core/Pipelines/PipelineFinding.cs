using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Core.Pipelines
{
    public sealed record PipelineFinding(
        FindingSeverity Severity,
        FindingAction Action,
        string PassId,
        string Message,
        ISourceRef? EvidenceRef = null
    ) : IPipelineFinding;
}
