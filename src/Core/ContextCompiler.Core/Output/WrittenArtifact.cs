using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Core.Output
{
    internal sealed record WrittenArtifact : IWrittenArtifact
    {
        public required string Path { get; init; }
    }
}
