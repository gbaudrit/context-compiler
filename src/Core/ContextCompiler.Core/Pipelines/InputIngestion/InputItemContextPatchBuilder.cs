using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Tags;

namespace ContextCompiler.Core.Pipelines.InputIngestion;

internal sealed class InputItemContextPatchBuilder(ITagBuilder tagBuilder, ISourceRefBuilder sourceRefBuilder, IDataEnvelopeBuilder dataEnvelopeBuilder) : IInputItemContextPatchBuilder
{
    private IDataEnvelope? _dataEnvelope;
    private List<IPipelineFinding> _findings = [];
    private List<IFragment> _fragments = [];
    private List<ITag> _tags = [];
    private List<IDataPart> _parts = [];

    public IInputItemContextPatchBuilder InitNew()
    {
        _dataEnvelope = null;
        _findings = [];
        _fragments = [];
        _tags = [];
        _parts = [];
        return this;
    }

    public IInputItemContextPatchBuilder InitFrom(IInputItemContextData data)
    {
        _dataEnvelope = data.DataEnvelope;
        _findings = [.. data.Findings];
        _fragments = [.. data.Fragments];
        _tags = [.. data.Tags];
        _parts = data.DataEnvelope?.Parts?.ToList() ?? [];
        return this;
    }

    public IInputItemContextPatchBuilder Combine(IInputItemContextPatch p)
    {
        if (p is not InputItemContextPatch patch)
        {
            return this;
        }

        if (patch.DataEnvelope is not null)
        {
            _dataEnvelope = patch.DataEnvelope;
        }

        _findings.AddRange(patch.Findings);
        _fragments.AddRange(patch.Fragments);
        _tags.AddRange(patch.Tags);
        _parts.AddRange(patch.Parts);

        return this;
    }

    public IInputItemContextPatchBuilder WithFindings(IEnumerable<IPipelineFinding> findings)
    {
        _findings = [.. findings];
        return this;
    }

    public IInputItemContextPatchBuilder WithFragments(IEnumerable<IFragment> fragments)
    {
        _fragments = [.. fragments];
        return this;
    }

    public IInputItemContextPatchBuilder WithTags(IEnumerable<ITag> tags)
    {
        _tags = [.. tags];
        return this;
    }

    public IInputItemContextPatchBuilder WithTags(IEnumerable<string> tags)
    {
        _tags = [.. tags.Select(t => tagBuilder.Build(t, string.Empty))];
        return this;
    }

    public IInputItemContextPatchBuilder WithSinglePart(IDataPart part)
    {
        _parts = [part];
        return this;
    }

    public IInputItemContextPatchBuilder WithParts(IEnumerable<IDataPart> parts)
    {
        _parts = [.. parts];
        return this;
    }

    public IInputItemContextPatchBuilder WithDataEnvelope(IDataEnvelope dataEnvelope)
    {
        _dataEnvelope = dataEnvelope;
        return this;
    }

    public IInputItemContextPatchBuilder WithDataEnvelope(Action<IDataEnvelopeBuilder> builder)
    {
        builder(dataEnvelopeBuilder.InitNew());
        _dataEnvelope = dataEnvelopeBuilder.Build();
        return this;
    }

    public IInputItemContextPatchBuilder AddFinding(
        FindingSeverity Severity,
        FindingAction Action,
        string PassId,
        string Message,
        ISourceRef? EvidenceRef = null)
    {
        _findings.Add(new PipelineFinding(Severity, Action, PassId, Message, EvidenceRef));
        return this;
    }

    public IInputItemContextPatchBuilder AddFinding(
        FindingSeverity Severity,
        FindingAction Action,
        string PassId,
        string Message,
        Action<ISourceRefBuilder> SourceRefBuild)
    {
        SourceRefBuild(sourceRefBuilder.InitNew());

        _findings.Add(new PipelineFinding(Severity, Action, PassId, Message, sourceRefBuilder.Build()));
        return this;
    }

    public IInputItemContextPatch Build()
    {
        return new InputItemContextPatch
        {
            DataEnvelope = _dataEnvelope,
            Findings = _findings.AsReadOnly(),
            Fragments = _fragments.AsReadOnly(),
            Tags = _tags.AsReadOnly(),
            Parts = _parts.AsReadOnly()
        };
    }

    public Task<IInputItemContextPatch> BuildAsTask()
    {
        return Task.FromResult(Build());
    }

    public ValueTask<IInputItemContextPatch> BuildAsValueTask()
    {
        return ValueTask.FromResult(Build());
    }

    public IInputItemContextPatch NoChanges()
    {
        return new InputItemContextPatch
        {
            DataEnvelope = null,
            Findings = [],
            Fragments = [],
            Tags = [],
            Parts = []
        };
    }

    public Task<IInputItemContextPatch> NoChangesAsTask()
    {
        return Task.FromResult(NoChanges());
    }
}
