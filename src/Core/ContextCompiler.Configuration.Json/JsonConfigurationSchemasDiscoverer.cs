using ContextCompiler.Abstractions.Configuration;

namespace ContextCompiler.Configuration.Json;

internal sealed class JsonConfigurationSchemasDiscoverer : IConfigurationSchemasDiscoverer
{
    public Task<IEnumerable<string>> Discover(string rootPath)
    {
        List<string> schemaPaths = [.. Directory.GetFiles(rootPath, "ctxc.config.schema.json", SearchOption.AllDirectories)];
        return Task.FromResult(schemaPaths.AsEnumerable());
    }
}
