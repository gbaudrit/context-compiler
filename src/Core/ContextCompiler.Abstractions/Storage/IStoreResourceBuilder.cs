namespace ContextCompiler.Abstractions.Storage;

public interface IStoreResourceBuilder
{
    IStoreResourceBuilder InitNew();
    IStoreResourceBuilder WithUri(IStoreResourceUri uri);
    IStoreResourceBuilder WithEncoding(System.Text.Encoding encoding);
    IStoreResource Build();
}
