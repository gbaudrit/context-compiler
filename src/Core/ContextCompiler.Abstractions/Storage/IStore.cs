namespace ContextCompiler.Abstractions.Storage;

public interface IStore
{
    string Key { get; }

    IStoreResourceUri Uri { get; }

    IStoreResourceUri Combine(string relativePath);

    IStore CreateContainer(string relativePath);
    IStore GetContainer(string relativePath);

    bool Contains(string relativePath);
    bool Contains(IStoreResourceUri uri);

    IStoreResource GetResource(string relativePath);
}
