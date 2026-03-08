namespace ContextCompiler.Abstractions.Output
{
    public interface IOutputArtifact
    {

        string FileName { get; init; }
        string Content { get; init; }
        string Description { get; init; }
    }
}
