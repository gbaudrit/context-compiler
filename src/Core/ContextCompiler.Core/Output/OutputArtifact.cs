using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Storage;

namespace ContextCompiler.Core.Output
{
    internal sealed class OutputArtifact : IOutputArtifact
    {
        public required IStoreResource StoreResource { get; init; }
        public required string Content { get; init; }
        public required string Description { get; init; }
        public required string MimeType { get; init; }
        public required Type GeneratedBy { get; init; }
        public required long Size { get; init; }
        public required ArtifactCategory Category { get; init; }
        public required IReadOnlyDictionary<string, string> Metadata { get; init; }
    }
}
