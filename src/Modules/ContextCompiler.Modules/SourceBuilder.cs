using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules;

internal sealed class SourceBuilder : ISourceBuilder
{

    internal sealed record Source : ISource
    {
        public required string Id { get; init; }
        public required string Provider { get; init; }
        public required Uri Url { get; init; }
    }

    private string _id = string.Empty;
    private string _provider = string.Empty;
    private Uri? _url;

    public ISourceBuilder InitNew()
    {
        _id = string.Empty;
        _provider = string.Empty;
        _url = null;
        return this;
    }

    public ISourceBuilder WithId(string id)
    {
        _id = id;
        return this;
    }

    public ISourceBuilder WithProvider(string provider)
    {
        _provider = provider;
        return this;
    }

    public ISourceBuilder WithUrl(Uri url)
    {
        _url = url;
        return this;
    }

    public ISource Build()
    {
        return string.IsNullOrWhiteSpace(_id)
            ? throw new InvalidOperationException("Id must be set and non-empty.")
            : string.IsNullOrWhiteSpace(_provider)
            ? throw new InvalidOperationException("Provider must be set and non-empty.")
            : _url == null
            ? throw new InvalidOperationException("Url must be set.")
            : (ISource)new Source
            {
                Id = _id,
                Provider = _provider,
                Url = _url
            };
    }

}
