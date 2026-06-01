using ContextCompiler.Abstractions.Compilation;

namespace ContextCompiler.Core.Compilation;

internal sealed class InputFilesDefinition : IInputFilesDefinition
{
    public required string[] Includes { get; init; }
    public required string[] Excludes { get; init; }
    public required string[] Tags { get; init; }
}
