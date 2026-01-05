using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Core.ReasoningIR.Domain
{
    internal sealed record Evidence(string EvidenceKey, string EvidenceRevision) : IEvidence;

}
