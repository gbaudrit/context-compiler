namespace ContextCompiler.Abstractions.Storage;

public interface IStoreConfiguration
{

    string ParentId { get; }
    string Name { get; }

    IStoreResourceUri Root { get; }
    IStoreResourceUri Uri { get; }

}
