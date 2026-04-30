using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Core.Pipelines;

internal sealed class DocumentContextDataBuilder(IDataEnvelopeBuilder dataEnvelopeBuilder) : IDocumentContextDataBuilder
{
    private IDataEnvelope? _dataEnvelope;
    private IReadOnlyList<IPipelineFinding> _findings = [];
    private IReadOnlyList<IFragment> _fragments = [];
    private IReadOnlyList<ITag> _tags = [];

    public IDocumentContextDataBuilder InitNew()
    {
        _dataEnvelope = null;
        _findings = [];
        _fragments = [];
        _tags = [];
        return this;
    }

    public IDocumentContextDataBuilder InitFrom(IDocumentContextData data)
    {
        _dataEnvelope = data.DataEnvelope;
        _findings = data.Findings;
        _fragments = data.Fragments;
        _tags = data.Tags;
        return this;
    }

    public IDocumentContextDataBuilder WithFindings(IEnumerable<IPipelineFinding> findings)
    {
        _findings = findings.ToList().AsReadOnly();
        return this;
    }

    public IDocumentContextDataBuilder WithTags(IEnumerable<ITag> tags)
    {
        _tags = tags.ToList().AsReadOnly();
        return this;
    }

    public IDocumentContextDataBuilder WithFragments(IEnumerable<IFragment> fragments)
    {
        _fragments = fragments.ToList().AsReadOnly();
        return this;
    }

    public IDocumentContextDataBuilder WithDataEnvelope(IDataEnvelope dataEnvelope)
    {
        _dataEnvelope = dataEnvelope;
        return this;
    }

    public IDocumentContextData Build()
    {
        return new DocumentContextData
        {
            Tags = _tags,
            DataEnvelope = _dataEnvelope ?? dataEnvelopeBuilder.InitNew().Build(),
            Fragments = _fragments,
            Findings = _findings
        };
    }
}
