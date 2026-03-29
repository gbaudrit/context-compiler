using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Core.Output
{
    internal sealed class OutputArtifact : IOutputArtifact
    {
        public required string FileName { get; init; }
        public required string Content { get; init; }
        public required string Description { get; init; }
        public required string MimeType { get; init; }
        public required Type GeneratedBy { get; init; }
        public required long Size { get; init; }
    }
}
