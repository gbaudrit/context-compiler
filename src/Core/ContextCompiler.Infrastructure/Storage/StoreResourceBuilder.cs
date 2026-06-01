using System.Text;

using ContextCompiler.Abstractions.Storage;

namespace ContextCompiler.Infrastructure.Storage;

internal sealed class StoreResourceBuilder : IStoreResourceBuilder
{
    private IStoreResourceUri? _uri;
    private Encoding _encoding = Encoding.UTF8;

    public IStoreResourceBuilder InitNew()
    {
        _uri = null;
        _encoding = Encoding.UTF8;
        return this;
    }

    public IStoreResourceBuilder WithUri(IStoreResourceUri uri)
    {
        _uri = uri;
        return this;
    }

    public IStoreResourceBuilder WithEncoding(Encoding encoding)
    {
        _encoding = encoding;
        return this;
    }

    public IStoreResource Build()
    {
        ArgumentNullException.ThrowIfNull(_uri);

        return new FileSystemStoreResource
        {
            Uri = _uri,
            Encoding = _encoding
        };
    }
}
