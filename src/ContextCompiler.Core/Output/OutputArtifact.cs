using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Core.Output
{
    internal sealed class OutputArtifact : IOutputArtifact
    {
        public required string FileName { get; init; }
        public required string Content { get; init; }
        public required string Description { get; init; }
    }
}
