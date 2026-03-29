namespace ContextCompiler.Abstractions.ReasoningIR
{
    public interface IEvidence
    {

        string EvidenceKey { get; }
        string EvidenceRevision { get; }

        string RelativeEvidenceKey { get; }
        string RelativeEvidenceRevision { get; }

    }
}
