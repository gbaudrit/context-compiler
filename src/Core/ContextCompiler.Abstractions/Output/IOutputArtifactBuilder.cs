using ContextCompiler.Abstractions.Storage;

namespace ContextCompiler.Abstractions.Output
{
    public interface IOutputArtifactBuilder
    {
        IOutputArtifactBuilder InitNew();
        IOutputArtifactBuilder WithStoreResource(IStoreResource storeUri);
        IOutputArtifactBuilder InStore(string storeKey);
        IOutputArtifactBuilder WithName(string name);
        IOutputArtifactBuilder WithContent(string content);
        IOutputArtifactBuilder WithGeneratedBy(Type generatedBy);
        IOutputArtifact Build();
        IOutputArtifactBuilder WithDescription(string description);
        IOutputArtifactBuilder WithMimeType(string mimeType);
        IOutputArtifactBuilder WithSize(long size);
        IOutputArtifactBuilder IsStreamedContent();
    }
}
