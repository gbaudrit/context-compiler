namespace ContextCompiler.Abstractions.Output
{
    public interface IOutputArtifactCreator<T>
    {
        IOutputArtifact Create(T input);
    }
}
