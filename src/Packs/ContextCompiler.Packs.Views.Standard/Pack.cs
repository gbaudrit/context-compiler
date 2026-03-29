using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Packs.Views.Standard
{
    public class Pack : IPack
    {
        public IEnumerable<Assembly> Discover()
        {
            return [
                typeof(Modules.Views.DependencyInjection).Assembly,
                typeof(Modules.Views.View.Index.Json.DependencyInjection).Assembly
                ];
        }
    }
}
