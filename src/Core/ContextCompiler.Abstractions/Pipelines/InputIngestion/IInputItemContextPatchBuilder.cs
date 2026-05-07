using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Pipelines.InputIngestion
{
    public interface IInputItemContextPatchBuilder
    {
        IInputItemContextPatchBuilder InitFrom(IInputItemContextData data);
        IInputItemContextPatchBuilder Combine(IInputItemContextPatch p);

        IInputItemContextPatch Build();
        Task<IInputItemContextPatch> BuildAsTask();
        ValueTask<IInputItemContextPatch> BuildAsValueTask();

        IInputItemContextPatchBuilder WithFindings(IEnumerable<IPipelineFinding> findings);
        IInputItemContextPatchBuilder WithFragments(IEnumerable<IFragment> fragments);
        IInputItemContextPatchBuilder WithTags(IEnumerable<ITag> tags);
        IInputItemContextPatchBuilder WithTags(IEnumerable<string> tags);

        IInputItemContextPatchBuilder WithSinglePart(IDataPart part);
        IInputItemContextPatchBuilder WithParts(IEnumerable<IDataPart> parts);

        IInputItemContextPatchBuilder WithDataEnvelope(IDataEnvelope dataEnvelope);

        IInputItemContextPatchBuilder InitNew();

        IInputItemContextPatchBuilder AddFinding(FindingSeverity Severity,
                                    FindingAction Action,
                                    string PassId,
                                    string Message,
                                    ISourceRef? EvidenceRef = null);

        IInputItemContextPatch NoChanges();
        Task<IInputItemContextPatch> NoChangesAsTask();
        IInputItemContextPatchBuilder AddFinding(FindingSeverity Severity, FindingAction Action, string PassId, string Message, Action<ISourceRefBuilder> SourceRefBuild);
        IInputItemContextPatchBuilder WithDataEnvelope(Action<IDataEnvelopeBuilder> builder);
    }
}
