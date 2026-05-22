namespace ContextCompiler.Abstractions.Storage
{
    public interface IStoreConfigurationBuilder
    {
        IStoreConfigurationBuilder InitNew();

        IStoreConfigurationBuilder WithParentId(string parentId);

        IStoreConfigurationBuilder WithRootUri(IStoreResourceUri rootUri);

        IStoreConfiguration Build();

    }
}
