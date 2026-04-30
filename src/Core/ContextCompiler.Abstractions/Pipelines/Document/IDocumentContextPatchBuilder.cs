using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IDocumentContextPatchBuilder
    {
        IDocumentContextPatchBuilder InitFrom(IDocumentContextData data);
        IDocumentContextPatchBuilder Combine(IDocumentContextPatch p);

        IDocumentContextPatch Build();
        Task<IDocumentContextPatch> BuildAsTask();
        ValueTask<IDocumentContextPatch> BuildAsValueTask();

        IDocumentContextPatchBuilder WithFindings(IEnumerable<IPipelineFinding> findings);
        IDocumentContextPatchBuilder WithFragments(IEnumerable<IFragment> fragments);
        IDocumentContextPatchBuilder WithTags(IEnumerable<ITag> tags);
        IDocumentContextPatchBuilder WithTags(IEnumerable<string> tags);

        IDocumentContextPatchBuilder WithSinglePart(IDataPart part);
        IDocumentContextPatchBuilder WithParts(IEnumerable<IDataPart> parts);

        IDocumentContextPatchBuilder WithDataEnvelope(IDataEnvelope dataEnvelope);

        IDocumentContextPatchBuilder InitNew();

        IDocumentContextPatchBuilder AddFinding(FindingSeverity Severity,
                                    FindingAction Action,
                                    string PassId,
                                    string Message,
                                    ISourceRef? EvidenceRef = null);

        IDocumentContextPatch NoChanges();
        Task<IDocumentContextPatch> NoChangesAsTask();
    }
}
