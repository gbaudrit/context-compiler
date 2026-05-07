using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Packs.Starter.Standard;

public class StarterStandardPack : IPackModule
{
    public IEnumerable<Assembly> Discover()
    {
        return
        [
            typeof(Output.Packs.Standard.Pack).Assembly,
            typeof(Prompting.Packs.Standard.Pack).Assembly,
            typeof(Readers.Packs.Standard.Pack).Assembly,
            typeof(Views.Packs.Standard.Pack).Assembly,
            typeof(InputIngestion.Packs.Transcoders.Standard.Pack).Assembly,
            typeof(Security.Packs.Standard.Pack).Assembly,
        ];
    }
}
