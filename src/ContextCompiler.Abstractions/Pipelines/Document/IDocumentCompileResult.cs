using ContextCompiler.Abstractions.Diagnostics;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IDocumentCompileResult
    {

        string Path { get; }
        IReadOnlyList<IFragment> Fragments { get; }
        IReadOnlyList<GuardFinding> Findings { get; }

    }
}
