namespace ContextCompiler.Abstractions.Output
{
    public interface IOutputArtifactBuilder
    {
        IOutputArtifactBuilder InitNew();
        IOutputArtifactBuilder WithFileName(string fileName);
        IOutputArtifactBuilder WithContent(string content);
        IOutputArtifactBuilder WithGeneratedBy(Type generatedBy);
        IOutputArtifact Build();
        IOutputArtifactBuilder WithDescription(string description);
        IOutputArtifactBuilder WithMimeType(string mimeType);
        IOutputArtifactBuilder WithSize(long size);
        IOutputArtifactBuilder IsStreamedContent();
    }
}
