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
            typeof(ContextCompiler.Prompting.Packs.Standard.Pack).Assembly,
            typeof(Readers.Standard.Pack).Assembly,
            typeof(Views.Standard.ViewsStandardPack).Assembly,
            typeof(Datas.Transcoders.Standard.Pack).Assembly,
            typeof(Security.Standard.Pack).Assembly,
        ];
    }
}
