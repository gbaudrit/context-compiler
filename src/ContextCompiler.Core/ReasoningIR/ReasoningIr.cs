using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Core.ReasoningIR;

public sealed record EvidenceKey(string Value) : IEvidenceKey;
public sealed record EvidenceRevision(string Value) : IEvidenceRevision;

public sealed record Fragment(
    IEvidenceKey Key,
    IEvidenceRevision Revision,
    string Content,
    SourceRef Source,
    IReadOnlyDictionary<string, string>? Tags = null
) : IFragment;

public sealed class ReasoningIr : IReasoningIr
{
    private readonly List<IFragment> _fragments = new();
    public IReadOnlyList<IFragment> Fragments => _fragments;

    public void Add(IFragment fragment) => _fragments.Add(fragment);
}
