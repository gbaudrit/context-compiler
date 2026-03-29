namespace ContextCompiler.Abstractions.Output;

public interface IOutputArtifactSerializer
{
    bool CanProcess(string name);
}

public interface IOutputArtifactSerializer<T>
{
    string Serialize(T index);

    T Deserialize(string value);
}
