using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.ReasoningIR
{
    public interface IReasoningIrGraphComputer
    {

        ValueTask<IGraph> Compute(IReasoningIr inputGraph, CancellationToken ct);

    }
}
