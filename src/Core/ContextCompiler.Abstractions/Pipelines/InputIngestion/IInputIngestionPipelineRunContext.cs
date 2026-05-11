using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Abstractions.Pipelines.InputIngestion;

public interface IInputIngestionPipelineRunContext : ISubPipelineRunContext
{
    IInputItemContext InputItem { get; }


    IInputIngestionPipelineRunContext Patch(Func<IInputItemContextPatchBuilder, IInputItemContextPatchBuilder> b);
    IInputIngestionPipelineRunContext Patch(Action<IInputItemContextPatchBuilder> b);

    void AddFinding(
        FindingSeverity Severity,
        FindingAction Action,
        string PassId,
        string Message,
        ISourceRef? EvidenceRef = null)
    {
        _ = Patch(b =>
        {
            return b.AddFinding(
                Severity,
                Action,
                PassId,
                Message,
                EvidenceRef);
        });
    }

    void AddFinding(
        FindingSeverity Severity,
        FindingAction Action,
        string PassId,
        string Message,
        Action<ISourceRefBuilder> SourceRefBuilder)
    {
        _ = Patch(b =>
        {
            return b.AddFinding(
                Severity,
                Action,
                PassId,
                Message,
                SourceRefBuilder);
        });
    }

    void AddFinding(
        FindingSeverity Severity,
        FindingAction Action,
        string PassId,
        string Message)
    {
        _ = Patch(b =>
        {
            return b.AddFinding(
                Severity,
                Action,
                PassId,
                Message,
                b => b.WithPath(InputItem.FullPath));
        });
    }

    Task<IResult<IInputIngestionPipelineRunResult>> Failure(string message);
    Task<IResult<IInputIngestionPipelineRunResult>> Failure(string message, Exception ex);
    Task<IResult<IInputIngestionPipelineRunResult>> Success();

    Task<IResult<IInputIngestionPipelineRunResult>> NothingToDo();
    Task<IResult<IInputIngestionPipelineRunResult>> NoChanges();
    Task<IResult<IInputIngestionPipelineRunResult>> Failure(Exception ex);
}
