using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Core.Pipelines.InputIngestion;

internal sealed class InputItemContextDataBuilder(IDataEnvelopeBuilder dataEnvelopeBuilder) : IInputItemContextDataBuilder
{
    private IDataEnvelope? _dataEnvelope;
    private IReadOnlyList<IPipelineFinding> _findings = [];
    private IReadOnlyList<IFragment> _fragments = [];
    private IReadOnlyList<ITag> _tags = [];

    public IInputItemContextDataBuilder InitNew()
    {
        _dataEnvelope = null;
        _findings = [];
        _fragments = [];
        _tags = [];
        return this;
    }

    public IInputItemContextDataBuilder InitFrom(IInputItemContextData data)
    {
        _dataEnvelope = data.DataEnvelope;
        _findings = data.Findings;
        _fragments = data.Fragments;
        _tags = data.Tags;
        return this;
    }

    public IInputItemContextDataBuilder WithFindings(IEnumerable<IPipelineFinding> findings)
    {
        _findings = findings.ToList().AsReadOnly();
        return this;
    }

    public IInputItemContextDataBuilder WithTags(IEnumerable<ITag> tags)
    {
        _tags = tags.ToList().AsReadOnly();
        return this;
    }

    public IInputItemContextDataBuilder WithFragments(IEnumerable<IFragment> fragments)
    {
        _fragments = fragments.ToList().AsReadOnly();
        return this;
    }

    public IInputItemContextDataBuilder WithDataEnvelope(IDataEnvelope dataEnvelope)
    {
        _dataEnvelope = dataEnvelope;
        return this;
    }

    public IInputItemContextData Build()
    {
        return new InputItemContextData
        {
            Tags = _tags,
            DataEnvelope = _dataEnvelope ?? dataEnvelopeBuilder.InitNew().Build(),
            Fragments = _fragments,
            Findings = _findings
        };
    }
}
