using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.ReasoningIR;

public interface IReasoningIr
{
    IReadOnlyList<IFragment> Fragments { get; }

    void Add(IFragment fragment);
}
