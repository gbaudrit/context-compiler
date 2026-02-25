
namespace ContextCompiler.Abstractions.Configuration;

public interface IConfigurationSchemasDiscoverer
{
    Task<IEnumerable<string>> Discover(string rootPath);
}
