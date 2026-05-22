using ContextCompiler.Abstractions.Storage;

namespace ContextCompiler.Core.Storage;

internal sealed class StoreConfigurationBuilder : IStoreConfigurationBuilder
{
    private string _parentId = "root";
    private IStoreResourceUri? _root;

    public IStoreConfigurationBuilder InitNew()
    {
        _parentId = "root";
        _root = null;
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

    public IStoreConfiguration Build()
    {
        ArgumentNullException.ThrowIfNull(_root, nameof(_root));

        return new StoreConfiguration
        {
            ParentId = _parentId,
            Root = _root,
        };
    }
}
