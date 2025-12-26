using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.ReasoningIR;

public interface IEvidenceKey
{
    string Value { get; init; }
}
