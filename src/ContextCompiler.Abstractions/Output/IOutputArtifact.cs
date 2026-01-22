namespace ContextCompiler.Abstractions.Output
{
    public interface IOutputArtifact
    {

        public string FileName { get; init; }
        public string Content { get; init; }

    }
}
