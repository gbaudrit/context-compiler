using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Views.Packs.Standard
{
    public class Pack : IPackModule
    {
        public IEnumerable<Assembly> Discover()
        {
            return [
                typeof(DependencyInjection).Assembly,
                typeof(Modules.View.Index.Json.DependencyInjection).Assembly
                ];
        }
    }
}
