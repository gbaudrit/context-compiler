using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Packs.Datas.Transcoders.Standard;

public class Pack : IPackModule
{
    public IEnumerable<Assembly> Discover()
    {
        return [
            typeof(Modules.Datas.Transcoders.Linear.DependencyInjection).Assembly,
            typeof(Modules.Datas.Transcoders.Tabular.DependencyInjection).Assembly
        ];
    }
}
