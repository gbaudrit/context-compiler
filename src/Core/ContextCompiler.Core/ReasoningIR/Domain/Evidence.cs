using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Core.ReasoningIR.Domain
{
    internal sealed record Evidence(string EvidenceKey, string EvidenceRevision, string RelativeEvidenceKey, string RelativeEvidenceRevision) : IEvidence;

}
