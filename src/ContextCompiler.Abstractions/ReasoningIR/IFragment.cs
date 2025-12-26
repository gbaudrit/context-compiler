using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Abstractions.ReasoningIR;

public interface IFragment
{
    string Content { get; init; }
    IEvidenceKey Key { get; init; }
    IEvidenceRevision Revision { get; init; }
    SourceRef Source { get; init; }
    IReadOnlyDictionary<string, string>? Tags { get; init; }
}
