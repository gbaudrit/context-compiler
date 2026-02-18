namespace ContextCompiler.Plugins.Abstractions.Loading
{
    public interface IPluginsDiscoverer
    {
        Task<IEnumerable<Type>> Discover(string rootPath, CancellationToken ct);
    }
}
