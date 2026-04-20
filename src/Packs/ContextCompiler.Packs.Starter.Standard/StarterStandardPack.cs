using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Packs.Starter.Standard;

public class StarterStandardPack : IPackModule
{
    public IEnumerable<Assembly> Discover()
    {
        return
        [
            typeof(Artifacts.Standard.Pack).Assembly,
            typeof(Prompt.Standard.Pack).Assembly,
            typeof(Readers.Standard.Pack).Assembly,
            typeof(Views.Standard.Pack).Assembly,
            typeof(Datas.Transcoders.Standard.Pack).Assembly,
        ];
    }
}
