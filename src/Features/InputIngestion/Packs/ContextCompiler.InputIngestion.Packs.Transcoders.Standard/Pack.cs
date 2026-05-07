using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.InputIngestion.Packs.Transcoders.Standard;

public class Pack : IPackModule
{
    public IEnumerable<Assembly> Discover()
    {
        return [
            typeof(InputIngestion.Modules.Transcoders.Linear.DependencyInjection).Assembly,
            typeof(InputIngestion.Modules.Transcoders.Tabular.DependencyInjection).Assembly
        ];
    }
}
