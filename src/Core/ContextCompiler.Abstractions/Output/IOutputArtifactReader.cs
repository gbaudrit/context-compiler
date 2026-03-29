namespace ContextCompiler.Abstractions.Output;

public interface IOutputArtifactReader
{

    Task<string> ReadAllText(string filename, CancellationToken cancellationToken);

}
