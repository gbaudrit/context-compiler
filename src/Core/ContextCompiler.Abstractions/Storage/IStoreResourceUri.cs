namespace ContextCompiler.Abstractions.Storage;

public interface IStoreResourceUri
{
    IStoreResourceUri Combine(string relativePath);

    string AbsolutePath { get; }
}
