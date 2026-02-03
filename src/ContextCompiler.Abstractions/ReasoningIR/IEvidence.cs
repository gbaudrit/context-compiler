namespace ContextCompiler.Abstractions.ReasoningIR
{
    public interface IEvidence
    {

        string EvidenceKey { get; }
        string EvidenceRevision { get; }

    }
}
