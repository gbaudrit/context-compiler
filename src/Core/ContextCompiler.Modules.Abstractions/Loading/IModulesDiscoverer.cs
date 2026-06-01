namespace ContextCompiler.Modules.Abstractions.Loading
{
    public interface IModulesDiscoverer
    {
        Task<IEnumerable<Type>> Discover(string rootPath, string packageId, CancellationToken ct);
    }
}
