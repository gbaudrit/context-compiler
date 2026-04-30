using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Tags;

namespace ContextCompiler.Core.Pipelines.Document;

internal sealed class DocumentContextPatchBuilder(ITagBuilder tagBuilder) : IDocumentContextPatchBuilder
{
    private IDataEnvelope? _dataEnvelope;
    private List<IPipelineFinding> _findings = [];
    private List<IFragment> _fragments = [];
    private List<ITranscodedFragment> _transcodedFragments = [];
    private List<ITag> _tags = [];
    private List<IDataPart> _parts = [];

    public IDocumentContextPatchBuilder InitNew()
    {
        _dataEnvelope = null;
        _findings = [];
        _fragments = [];
        _transcodedFragments = [];
        _tags = [];
        _parts = [];
        return this;
    }

    public IDocumentContextPatchBuilder InitFrom(IDocumentContextData data)
    {
        _dataEnvelope = data.DataEnvelope;
        _findings = [.. data.Findings];
        _fragments = [.. data.Fragments];
        _transcodedFragments = [];
        _tags = [.. data.Tags];
        _parts = data.DataEnvelope?.Parts?.ToList() ?? [];
        return this;
    }

    public IDocumentContextPatchBuilder Combine(IDocumentContextPatch p)
    {
        if (p is not DocumentContextPatch patch)
        {
            return this;
        }

        if (patch.DataEnvelope is not null)
        {
            _dataEnvelope = patch.DataEnvelope;
        }

        _findings.AddRange(patch.Findings);
        _fragments.AddRange(patch.Fragments);
        _transcodedFragments.AddRange(patch.TranscodedFragments);
        _tags.AddRange(patch.Tags);
        _parts.AddRange(patch.Parts);

        return this;
    }

    public IDocumentContextPatchBuilder WithFindings(IEnumerable<IPipelineFinding> findings)
    {
        _findings = [.. findings];
        return this;
    }

    public IDocumentContextPatchBuilder WithFragments(IEnumerable<IFragment> fragments)
    {
        _fragments = [.. fragments];
        return this;
    }

    public IDocumentContextPatchBuilder WithTranscodedFragments(IEnumerable<ITranscodedFragment> fragments)
    {
        _transcodedFragments = [.. fragments];
        return this;
    }

    public IDocumentContextPatchBuilder WithTags(IEnumerable<ITag> tags)
    {
        _tags = [.. tags];
        return this;
    }

    public IDocumentContextPatchBuilder WithTags(IEnumerable<string> tags)
    {
        _tags = [.. tags.Select(t => tagBuilder.Build(t, string.Empty))];
        return this;
    }

    public IDocumentContextPatchBuilder WithSinglePart(IDataPart part)
    {
        _parts = [part];
        return this;
    }

    public IDocumentContextPatchBuilder WithParts(IEnumerable<IDataPart> parts)
    {
        _parts = [.. parts];
        return this;
    }

    public IDocumentContextPatchBuilder WithDataEnvelope(IDataEnvelope dataEnvelope)
    {
        _dataEnvelope = dataEnvelope;
        return this;
    }

    public IDocumentContextPatchBuilder AddFinding(
        FindingSeverity Severity,
        FindingAction Action,
        string PassId,
        string Message,
        ISourceRef? EvidenceRef = null)
    {
        _findings.Add(new PipelineFinding(Severity, Action, PassId, Message, EvidenceRef));
        return this;
    }

    public IDocumentContextPatch Build()
    {
        return new DocumentContextPatch
        {
            DataEnvelope = _dataEnvelope,
            Findings = _findings.AsReadOnly(),
            Fragments = _fragments.AsReadOnly(),
            TranscodedFragments = _transcodedFragments.AsReadOnly(),
            Tags = _tags.AsReadOnly(),
            Parts = _parts.AsReadOnly()
        };
    }

    public Task<IDocumentContextPatch> BuildAsTask()
    {
        return Task.FromResult(Build());
    }

    public ValueTask<IDocumentContextPatch> BuildAsValueTask()
    {
        return ValueTask.FromResult(Build());
    }

    public IDocumentContextPatch NoChanges()
    {
        return new DocumentContextPatch
        {
            DataEnvelope = null,
            Findings = [],
            Fragments = [],
            TranscodedFragments = [],
            Tags = [],
            Parts = []
        };
    }

    public Task<IDocumentContextPatch> NoChangesAsTask()
    {
        return Task.FromResult(NoChanges());
    }
}
