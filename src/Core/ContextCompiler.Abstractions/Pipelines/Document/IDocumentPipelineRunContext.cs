using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Abstractions.Pipelines.Document;

public interface IDocumentPipelineRunContext : IPipelineRunContext
{

    IDocumentContext Document { get; }


    IDocumentPipelineRunContext Patch(Func<IDocumentContextPatchBuilder, IDocumentContextPatchBuilder> b);
    IDocumentPipelineRunContext Patch(Action<IDocumentContextPatchBuilder> b);

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
                b => b.WithPath(Document.FullPath));
        });
    }

    Task<IResult<IDocumentPipelineRunResult>> Failure(string message);
    Task<IResult<IDocumentPipelineRunResult>> Failure(string message, Exception ex);
    Task<IResult<IDocumentPipelineRunResult>> Success();

    Task<IResult<IDocumentPipelineRunResult>> NothingToDo();
    Task<IResult<IDocumentPipelineRunResult>> NoChanges();
    Task<IResult<IDocumentPipelineRunResult>> Failure(Exception ex);
}
