namespace ContextCompiler.Abstractions.Storage;

public interface IStoreResourceUri
{
    IStoreResourceUri Combine(Uri relativeUri);

    string AbsolutePath { get; }

    string Name { get; }

    Uri MakeRelativeOf(IStoreResourceUri storeResourceUri);
}
