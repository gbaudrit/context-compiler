namespace ContextCompiler.Abstractions.Output
{
    public interface IOutputJsonArtifactWriter
    {

        Task Write<T>(string name, T health);

    }
}
