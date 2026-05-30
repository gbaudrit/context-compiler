namespace ContextCompiler.Abstractions.Storage;

public interface IStore
{
    string Key { get; }

    IStoreContainer Container { get; }

    IStoreResourceUri Uri { get; }

    IStoreResourceUri Combine(Uri relativeUri);

    IStoreContainer CreateContainer(string relativePath);
    IStoreContainer CreateContainer(Uri relativeUri);
    IStoreContainer GetContainer(string relativePath);
    IStoreContainer GetContainer(Uri relativeUri);

    bool Contains(string relativePath);
    bool Contains(IStoreResourceUri uri);

    bool Exists();

    Task Init();
}
