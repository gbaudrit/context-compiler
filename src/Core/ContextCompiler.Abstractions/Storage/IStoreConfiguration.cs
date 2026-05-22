namespace ContextCompiler.Abstractions.Storage;

public interface IStoreConfiguration
{

    string ParentId { get; }

    IStoreResourceUri Root { get; }

}
