namespace ContextCompiler.Abstractions.Output
{
    public interface IOutputArtifactBuilder
    {
        IOutputArtifactBuilder InitNew();
        IOutputArtifactBuilder WithFileName(string fileName);
        IOutputArtifactBuilder WithContent(string content);
        IOutputArtifact Build();
    }
}
