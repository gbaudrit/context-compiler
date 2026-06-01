using ContextCompiler.Abstractions.Storage;

namespace ContextCompiler.Core.Storage;

internal sealed class StoreConfigurationBuilder : IStoreConfigurationBuilder
{
    private string _parentId = "root";
    private IStoreResourceUri? _root;
    private IStoreResourceUri? _uri;
    private string _name = string.Empty;

    public IStoreConfigurationBuilder InitNew()
    {
        _parentId = "root";
        _root = null;
        _name = string.Empty;
        return this;
    }

    public IStoreConfigurationBuilder WithParentId(string parentId)
    {
        _parentId = parentId;
        return this;
    }

    public IStoreConfigurationBuilder WithRootUri(IStoreResourceUri root)
    {
        _root = root;
        return this;
    }

    public IStoreConfigurationBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IStoreConfiguration Build()
    {
        ArgumentNullException.ThrowIfNull(_root, nameof(_root));
        _uri = _root;
        if (!string.IsNullOrEmpty(_name))
        {
            _uri = _root.Combine(new Uri(_name + "/", UriKind.Relative));
        }

        return new StoreConfiguration
        {
            ParentId = _parentId,
            Root = _root,
            Uri = _uri,
            Name = _name,
        };
    }
}
