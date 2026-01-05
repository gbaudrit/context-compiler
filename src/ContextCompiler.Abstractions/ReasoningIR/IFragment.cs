using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Abstractions.ReasoningIR;

public interface IFragment
{
    string Content { get; init; }
    IEvidence Evidence { get; init; }
    ISourceRef Source { get; init; }
    IReadOnlyList<ITag> Tags { get; init; }
}
