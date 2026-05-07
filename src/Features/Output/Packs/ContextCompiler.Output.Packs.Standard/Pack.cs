using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Output.Packs.Standard
{
    public class Pack : IPackModule
    {
        public IEnumerable<Assembly> Discover()
        {
            return [
                typeof(Modules.Artifacts.Registry.DependencyInjection).Assembly,
                typeof(Modules.Artifacts.Registry.DependencyInjection).Assembly
                ];
        }
    }
}
