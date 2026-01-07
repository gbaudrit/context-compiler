using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IPipelineRunResult
    {
        bool Ok { get; }
        int ExitCode { get; } // 0 ok, 1 error, 2 blocked
        IReadOnlyList<IPipelineFinding> Findings { get; }
    }
}
