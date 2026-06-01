namespace ContextCompiler.Abstractions.Output
{
    public interface IOutputArtifactWriter
    {
        Task Write(string name, string content);
    }
}
