using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Pipelines.InputIngestion
{
    public interface IInputItemCompileResult
    {

        string Path { get; }
        IReadOnlyList<IFragment> Fragments { get; }
        IReadOnlyList<GuardFinding> Findings { get; }

    }
}
