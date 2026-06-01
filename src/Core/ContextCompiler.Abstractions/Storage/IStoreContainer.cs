namespace ContextCompiler.Abstractions.Storage;

public interface IStoreContainer
{
    IStoreResourceUri Uri { get; }

    bool Exists();

    IStoreResource GetResource(string relativePath);

    IReadOnlyList<IStoreResource> GetResources(string filter, bool recursive);

    IStoreContainer CreateContainer(string name);
}
