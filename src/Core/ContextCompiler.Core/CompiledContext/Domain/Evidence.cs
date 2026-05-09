using ContextCompiler.Abstractions.Compiled;

namespace ContextCompiler.Core.CompiledContext.Domain
{
    internal sealed record Evidence(string EvidenceKey, string EvidenceRevision, string RelativeEvidenceKey, string RelativeEvidenceRevision) : IEvidence;

}
