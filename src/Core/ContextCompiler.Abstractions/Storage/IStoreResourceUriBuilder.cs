namespace ContextCompiler.Abstractions.Storage;

public interface IStoreResourceUriBuilder
{

    IStoreResourceUriBuilder InitNew();

    IStoreResourceUriBuilder WithUri(Uri uri);

    IStoreResourceUri Build();

}
