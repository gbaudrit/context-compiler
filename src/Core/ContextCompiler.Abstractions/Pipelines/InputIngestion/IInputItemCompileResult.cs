using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Diagnostics;

namespace ContextCompiler.Abstractions.Pipelines.InputIngestion
{
    public interface IInputItemCompileResult
    {

        string Path { get; }
        IReadOnlyList<IFragment> Fragments { get; }
        IReadOnlyList<GuardFinding> Findings { get; }

    }
}
