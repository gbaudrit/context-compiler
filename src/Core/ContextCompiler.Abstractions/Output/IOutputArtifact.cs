
using ContextCompiler.Abstractions.Storage;

namespace ContextCompiler.Abstractions.Output
{
    public interface IOutputArtifact
    {

        IStoreResource StoreResource { get; init; }
        string Content { get; init; }
        string Description { get; init; }
        Type GeneratedBy { get; init; }
        string MimeType { get; init; }
        long Size { get; init; }
        ArtifactCategory Category { get; init; }
        IReadOnlyDictionary<string, string> Metadata { get; init; }
    }
}
